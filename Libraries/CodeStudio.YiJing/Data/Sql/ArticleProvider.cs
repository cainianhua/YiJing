using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.Data.Sql
{
    internal class ArticleProvider : BaseProvider, IArticleProvider
    {
		#region [ SQL Statements ]
		private const string SQL_GET_ENTITY = "SELECT * FROM Articles WHERE ArticleId = @ArticleId";
		private const string SQL_GET_NEXT = @"
SELECT TOP 1 a.* 
FROM Articles a 
CROSS JOIN (
	SELECT a1.CreatedDate, a1.CategoryId ,c1.ParentId
	FROM Articles a1
	LEFT JOIN Categories c1 on a1.CategoryId = c1.CategoryId
	WHERE ArticleId = @ArticleId
) t 
WHERE a.CreatedDate < t.CreatedDate AND EXISTS (
	SELECT CategoryId FROM Categories WHERE (CategoryId = t.ParentId OR ParentId = t.ParentId) AND CategoryId = a.CategoryId
)";
		private const string SQL_GET_PREVIOUS = @"
SELECT TOP 1 a.* 
FROM Articles a 
CROSS JOIN (
	SELECT a1.CreatedDate, a1.CategoryId ,c1.ParentId
	FROM Articles a1
	LEFT JOIN Categories c1 on a1.CategoryId = c1.CategoryId
	WHERE ArticleId = @ArticleId
) t 
WHERE a.CreatedDate > t.CreatedDate AND a.CategoryId IN (
	SELECT CategoryId FROM Categories WHERE CategoryId = t.ParentId OR ParentId = t.ParentId
)";
		private const string SQL_GET_ENTITIES = "SELECT * FROM Articles WHERE CategoryId = @CategoryId ORDER BY SortOrder, CreatedDate DESC, ArticleId DESC";
		private const string SQL_DELETE_ENTITY = "DELETE FROM Articles WHERE ArticleId = @ArticleId";
		#endregion

		#region [ Stored Procedures ]
		private const string PROC_SAVE_ENTITY = "USP_Save_Article";
		private const string PROC_GET_PAGED_ENTITIES = "USP_GET_Paged_Articles";
		private const string PROC_GET_ARITCLEPAGEINDEX = "USP_GET_ArticlePageIndex_By_ArticleId";
		private const string PROC_GET_PAGED_STATISTICS = "USP_GET_Paged_Articles_Statistics";
		#endregion

		#region [ Fields ]
		private const string FIELD_ArticleId = "ArticleId";
		private const string FIELD_Title = "ArticleTitle";
		private const string FIELD_TitleLocal = "ArticleTitleLocal";
		private const string FIELD_Subtitle = "ArticleSubtitle";
		private const string FIELD_Keywords = "Keywords";
		private const string FIELD_Description = "Description";
		private const string FIELD_Thumbnail = "Thumbnail";
		private const string FIELD_Remarks = "Remarks";
		private const string FIELD_HtmlContent = "HtmlContent";
		private const string FIELD_Tags = "Tags";
		private const string FIELD_BgColor = "BgColor";
		private const string FIELD_BgPic = "BgPic";
		private const string FIELD_SortOrder = "SortOrder";
		private const string FIELD_CategoryId = "CategoryId";
		private const string FIELD_ParentId = "ParentId";
		private const string FIELD_TITLECOLOR = "TitleColor";
		private const string FIELD_SUBTITLE_COLOR = "SubTitleColor";
		private const string FIELD_REMARKS_COLOR = "RemarksColor";
		private const string FIELD_TAGS_COLOR = "TagsColor";
		#endregion

		public Article Get(int articleId) {
			return GetArticleInternal(articleId, SQL_GET_ENTITY);
		}

		public Article GetNext(int articleId) {
			return GetArticleInternal(articleId, SQL_GET_NEXT);
		}

		public Article GetPrevious(int articleId) {
			return GetArticleInternal(articleId, SQL_GET_PREVIOUS);
		}

		public List<Article> Gets(int categoryId) {
			List<Article> articles = new List<Article>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader(sqlConnectionString, CommandType.Text, SQL_GET_ENTITIES, SqlHelper.MakeInParameter(AT + FIELD_CategoryId, SqlDbType.Int, 4, categoryId));
				while (reader.Read()) {
					articles.Add(LoadArticle(reader));
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return articles;
		}

		public Dictionary<int, int> GetStatistics( int pageNo, int pageSize, string searchText, params int[] categoryId ) {
			Dictionary<int, int> statistics = new Dictionary<int, int>();
			IDataReader reader = null;
			try {
				reader = SqlHelper.ExecuteReader( sqlConnectionString, CommandType.StoredProcedure, PROC_GET_PAGED_STATISTICS,
						new SqlParameter[] { 
						SqlHelper.MakeInParameter(AT + FIELD_PAGE_NO, SqlDbType.Int, 4, pageNo),
						SqlHelper.MakeInParameter(AT + FIELD_PAGE_SIZE, SqlDbType.Int, 4, pageSize),
						SqlHelper.MakeInParameter(AT + FIELD_CategoryId, SqlDbType.VarChar, -1, GetIdString(categoryId)),
						SqlHelper.MakeInParameter(AT + FIELD_SEARCH_TEXT, SqlDbType.NVarChar, 50, searchText)
					} );
				while ( reader.Read() ) {
					statistics.Add( reader.GetInt32( 0 ), reader.GetInt32( 1 ) );
				}
			}
			finally {
				if ( reader != null && !reader.IsClosed )
					reader.Close();
			}

			return statistics;
		}

		/// <summary>
		/// 获取当前文章的在整个分类中的分页信息。
		/// </summary>
		/// <param name="articleId"></param>
		/// <returns></returns>
		public Pager<Article> GetPagedArticle( int articleId ) {
			Pager<Article> pager = new Pager<Article>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader( sqlConnectionString, CommandType.StoredProcedure, PROC_GET_ARITCLEPAGEINDEX,
					new SqlParameter[] { 
						SqlHelper.MakeInParameter(AT + FIELD_ArticleId, SqlDbType.Int, 4, articleId),
					} );
				if ( reader.Read() ) {
					pager.DataItems.Add( LoadArticle( reader ) );
					pager.CurrentPageIndex = ReadInt( reader, FIELD_ROW_NO );
				}

				if ( reader.NextResult() ) {
					if ( reader.Read() )
						pager.Total = ReadInt( reader, FIELD_TOTAL );
				}

				pager.PageSize = 1;
			}
			finally {
				if ( reader != null && !reader.IsClosed )
					reader.Close();
			}

			return pager;
		}

		public Pager<Article> Gets( int pageNo, int pageSize, string searchText, params int[] categoryIds ) {
			Pager<Article> pager = new Pager<Article>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader( sqlConnectionString, CommandType.StoredProcedure, PROC_GET_PAGED_ENTITIES,
					new SqlParameter[] { 
						SqlHelper.MakeInParameter(AT + FIELD_PAGE_NO, SqlDbType.Int, 4, pageNo),
						SqlHelper.MakeInParameter(AT + FIELD_PAGE_SIZE, SqlDbType.Int, 4, pageSize),
						SqlHelper.MakeInParameter(AT + FIELD_CategoryId, SqlDbType.VarChar, -1, GetIdString(categoryIds)),
						SqlHelper.MakeInParameter(AT + FIELD_SEARCH_TEXT, SqlDbType.NVarChar, 50, searchText)
					});
				while (reader.Read()) {
					pager.DataItems.Add(LoadArticle(reader));
				}

				if (reader.NextResult()) {
					if (reader.Read())
						pager.Total = ReadInt(reader, FIELD_TOTAL);
				}

				pager.PageSize = pageSize;
				pager.CurrentPageIndex = pageNo;
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return pager;
		}

		public int SaveOrUpdate(Article item) {
			SqlParameter[] p = new SqlParameter[] { 
				SqlHelper.MakeInParameter(AT + FIELD_ArticleId, SqlDbType.Int, 4, item.ArticleId),
				SqlHelper.MakeInParameter(AT + FIELD_Title, SqlDbType.NVarChar, 50, item.ArticleTitle),
				SqlHelper.MakeInParameter(AT + FIELD_TitleLocal, SqlDbType.NVarChar, 50, item.ArticleTitleLocal),
				SqlHelper.MakeInParameter(AT + FIELD_Subtitle, SqlDbType.NVarChar, 50, item.ArticleSubtitle),
				SqlHelper.MakeInParameter(AT + FIELD_Keywords, SqlDbType.NVarChar, 50, item.Keywords),
				SqlHelper.MakeInParameter(AT + FIELD_Description, SqlDbType.NVarChar, 255, item.Description),
				SqlHelper.MakeInParameter(AT + FIELD_Thumbnail, SqlDbType.NVarChar, 255, item.Thumbnail),
				SqlHelper.MakeInParameter(AT + FIELD_Remarks, SqlDbType.NVarChar, 255, item.Remarks),
				SqlHelper.MakeInParameter(AT + FIELD_HtmlContent, SqlDbType.NVarChar, -1, item.HtmlContent),
				SqlHelper.MakeInParameter(AT + FIELD_Tags, SqlDbType.NVarChar, 50, item.Tags),
				SqlHelper.MakeInParameter(AT + FIELD_BgColor, SqlDbType.Char, 6, item.BgColor),
				SqlHelper.MakeInParameter(AT + FIELD_BgPic, SqlDbType.NVarChar, 255, item.BgPic),
				SqlHelper.MakeInParameter(AT + FIELD_SortOrder, SqlDbType.Int, 4, item.SortOrder),
				SqlHelper.MakeInParameter(AT + FIELD_CategoryId, SqlDbType.Int, 4, item.CategoryId),
				SqlHelper.MakeInParameter(AT + FIELD_TITLECOLOR, SqlDbType.Char, 6, item.TitleColor),
				SqlHelper.MakeInParameter(AT + FIELD_SUBTITLE_COLOR, SqlDbType.Char, 6, item.SubTitleColor),
				SqlHelper.MakeInParameter(AT + FIELD_REMARKS_COLOR, SqlDbType.Char, 6, item.RemarksColor),
				SqlHelper.MakeInParameter(AT + FIELD_TAGS_COLOR, SqlDbType.Char, 6, item.TagsColor),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, item.ActionDate == DateTime.MinValue ? DateTime.Now : item.ActionDate),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, item.ActionBy ?? String.Empty),
				SqlHelper.MakeParameter(AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1)
			};

			SqlHelper.ExecuteNonQuery(sqlConnectionString, CommandType.StoredProcedure, PROC_SAVE_ENTITY, p);

			return Convert.ToInt32(p[p.Length - 1].Value);
		}

		public int Delete(int articleId) {
			return SqlHelper.ExecuteNonQuery(sqlConnectionString, CommandType.Text, SQL_DELETE_ENTITY, SqlHelper.MakeInParameter(AT + FIELD_ArticleId, SqlDbType.Int, 4, articleId));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		private Article LoadArticle(IDataReader reader) {
			Article a = new Article();
			a.ArticleId = ReadInt( reader, FIELD_ArticleId );
			a.ArticleTitle = ReadString( reader, FIELD_Title );
			a.ArticleTitleLocal = ReadString( reader, FIELD_TitleLocal );
			a.ArticleSubtitle = ReadString( reader, FIELD_Subtitle );
			a.Keywords = ReadString( reader, FIELD_Keywords );
			a.Description = ReadString( reader, FIELD_Description );
			a.Thumbnail = ReadString( reader, FIELD_Thumbnail );
			a.Remarks = ReadString( reader, FIELD_Remarks );
			a.HtmlContent = ReadString( reader, FIELD_HtmlContent );
			a.Tags = ReadString( reader, FIELD_Tags );
			a.BgColor = ReadString( reader, FIELD_BgColor );
			a.BgPic = ReadString( reader, FIELD_BgPic );
			a.SortOrder = ReadInt( reader, FIELD_SortOrder );
			a.CategoryId = ReadInt( reader, FIELD_CategoryId );
			a.TitleColor = ReadString( reader, FIELD_TITLECOLOR );
			a.SubTitleColor = ReadString( reader, FIELD_SUBTITLE_COLOR );
			a.RemarksColor = ReadString( reader, FIELD_REMARKS_COLOR );
			a.TagsColor = ReadString( reader, FIELD_TAGS_COLOR );

			if ( reader.FieldCount > 23 ) {
				a.ParentId = ReadInt( reader, FIELD_ParentId );
			}

			SetEntityProperties(a, reader);

			return a;
		}

		private Article GetArticleInternal(int articleId, string sql) {
			Article a = null;
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader(sqlConnectionString, CommandType.Text, sql, SqlHelper.MakeInParameter(AT + FIELD_ArticleId, SqlDbType.Int, 4, articleId));
				if (reader.Read()) {
					a = LoadArticle(reader);
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return a;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="categoryIds"></param>
		/// <returns></returns>
		private string GetIdString( params int[] categoryIds ) {
			string idString = "";
			StringBuilder s = new StringBuilder();
			for ( int i = categoryIds.Length - 1; i >= 0; i-- ) {
				if ( categoryIds[i] > 0 ) {
					s.Append( "," );
					s.Append( categoryIds[i] );
				}
			}
			if ( s.Length > 0 )
				idString = s.ToString( 1, s.Length - 1 );

			return idString;
		}
	}
}
