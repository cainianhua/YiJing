using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Entities;
using System.Data;
using System.Data.SqlClient;

namespace CodeStudio.YiJing.Data.Sql
{
    internal class FocusArticleProvider : BaseProvider, IFocusArticleProvider
	{
		#region [ SQL Statements ]
		private const string SQL_GET_ENTITY = "SELECT * FROM FocusArticles WHERE FocusArticleId = @FocusArticleId";
		private const string SQL_GET_ENTITIES = "SELECT * FROM FocusArticles ORDER BY SortOrder";
		private const string SQL_DELETE_ENTITY = "DELETE FROM FocusArticles WHERE FocusArticleId = @FocusArticleId";
		#endregion

		#region [ Stored Procedures ]
		private const string PROC_SAVE_MODEL = "USP_Save_FocusArticle";
		#endregion

		#region [ Fields ]
		private const string FIELD_FOCUS_ARTICLE_ID = "FocusArticleId";
		private const string FIELD_PIC = "Pic";
		private const string FIELD_DESCRIPTION = "Description";
		private const string FIELD_LINKTO = "LinkTo";
		private const string FIELD_SORT_ORDER = "SortOrder";
		#endregion

		public FocusArticle Get(int faId) {
			FocusArticle fa = null;
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader(sqlConnectionString, CommandType.Text, SQL_GET_ENTITY, SqlHelper.MakeInParameter(AT + FIELD_FOCUS_ARTICLE_ID, SqlDbType.Int, 4, faId));
				if (reader.Read()) {
					fa = LoadFocusArticle(reader);
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return fa;
		}

		public List<FocusArticle> Gets() {
			List<FocusArticle> fas = new List<FocusArticle>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader(sqlConnectionString, CommandType.Text, SQL_GET_ENTITIES);
				while (reader.Read()) {
					fas.Add(LoadFocusArticle(reader));
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return fas;
		}

		public int SaveOrUpdate(FocusArticle c) {
			SqlParameter[] p = new SqlParameter[] { 
				SqlHelper.MakeInParameter(AT + FIELD_FOCUS_ARTICLE_ID, SqlDbType.Int, 4, c.FocusArticleId),
				SqlHelper.MakeInParameter(AT + FIELD_PIC, SqlDbType.NVarChar, 255, c.Pic),
				SqlHelper.MakeInParameter(AT + FIELD_DESCRIPTION, SqlDbType.NVarChar, 255, c.Description),
				SqlHelper.MakeInParameter(AT + FIELD_LINKTO, SqlDbType.NVarChar, 255, c.LinkTo),
				SqlHelper.MakeInParameter(AT + FIELD_SORT_ORDER, SqlDbType.Int, 4, c.SortOrder),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, c.ActionDate == DateTime.MinValue ? DateTime.Now : c.ActionDate),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, c.ActionBy ?? String.Empty),
				SqlHelper.MakeParameter(AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1)
			};

			SqlHelper.ExecuteNonQuery(sqlConnectionString, CommandType.StoredProcedure, PROC_SAVE_MODEL, p);

			return Convert.ToInt32(p[p.Length - 1].Value);
		}

		public int Delete(int faId) {
			return SqlHelper.ExecuteNonQuery(sqlConnectionString, CommandType.Text, SQL_DELETE_ENTITY, SqlHelper.MakeInParameter(AT + FIELD_FOCUS_ARTICLE_ID, SqlDbType.Int, 4, faId));
		}

		private FocusArticle LoadFocusArticle(IDataReader reader) {
			FocusArticle fa = new FocusArticle();
			fa.FocusArticleId = ReadInt(reader, FIELD_FOCUS_ARTICLE_ID);
			fa.Pic = ReadString(reader, FIELD_PIC);
			fa.Description = ReadString(reader, FIELD_DESCRIPTION);
			fa.LinkTo = ReadString(reader, FIELD_LINKTO);
			fa.SortOrder = ReadInt(reader, FIELD_SORT_ORDER);

			SetEntityProperties(fa, reader);

			return fa;
		}
	}
}
