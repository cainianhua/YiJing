using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Entities;
using System.Data;
using System.Data.SqlClient;

namespace CodeStudio.YiJing.Data.Sql
{
    internal class CategoryProvider : BaseProvider, ICategoryProvider
    {
		#region [ SQL Statements ]
		private const string SQL_GET_ENTITY = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";
		private const string SQL_GET_ENTITIES = "SELECT * FROM Categories WHERE ParentId = @ParentId ORDER BY SortOrder, CreatedDate DESC";
		private const string SQL_GET_ALL = "SELECT * FROM Categories ORDER BY SortOrder, CreatedDate DESC";
		private const string SQL_DELETE_ENTITY = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
		#endregion

		#region [ Stored Procedures ]
		private const string PROC_SAVE_MODEL = "USP_Save_Category";
		#endregion

		#region [ Fields ]
		private const string FIELD_CATEGORYID = "CategoryId";
		private const string FIELD_NAME = "Name";
		private const string FIELD_NAMELOCAL = "NameLocal";
		private const string FIELD_DESCRIPTION = "Description";
		private const string FIELD_BGCOLOR = "BgColor";
		private const string FIELD_BGPIC = "BgPic";
		private const string FIELD_SORTORDER = "SortOrder";
		private const string FIELD_ALLOWTOADDSUBCATEGORY = "AllowToAddSubCategory";
		private const string FIELD_PARENTID = "ParentId";
		private const string FIELD_LOGO = "LOGO";
		private const string FIELD_LOGO2 = "LOGO2";
		#endregion

		public Category Get(int categoryId) {
			Category c = null;
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader(sqlConnectionString, CommandType.Text, SQL_GET_ENTITY, SqlHelper.MakeInParameter(AT + FIELD_CATEGORYID, SqlDbType.Int, 4, categoryId));
				if (reader.Read()) {
					c = LoadCategory(reader);
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return c;
		}

		public List<Category> Gets(int parentId) {
			List<Category> cats = new List<Category>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader(sqlConnectionString, CommandType.Text, SQL_GET_ENTITIES, SqlHelper.MakeInParameter(AT + FIELD_PARENTID, SqlDbType.Int, 4, parentId));
				while(reader.Read()) {
					cats.Add(LoadCategory(reader));
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return cats;
		}

		public List<Category> Gets() {
			List<Category> cats = new List<Category>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader( sqlConnectionString, CommandType.Text, SQL_GET_ALL);
				while ( reader.Read() ) {
					cats.Add( LoadCategory( reader ) );
				}
			}
			finally {
				if ( reader != null && !reader.IsClosed )
					reader.Close();
			}

			return cats;
		}

		public int SaveOrUpdate(Category c) {
			SqlParameter[] p = new SqlParameter[] { 
				SqlHelper.MakeInParameter(AT + FIELD_CATEGORYID, SqlDbType.Int, 4, c.CategoryId),
				SqlHelper.MakeInParameter(AT + FIELD_NAME, SqlDbType.NVarChar, 50, c.Name),
				SqlHelper.MakeInParameter(AT + FIELD_NAMELOCAL, SqlDbType.NVarChar, 50, c.NameLocal),
				SqlHelper.MakeInParameter(AT + FIELD_DESCRIPTION, SqlDbType.NVarChar, 255, c.Description),
				SqlHelper.MakeInParameter(AT + FIELD_BGCOLOR, SqlDbType.Char, 6, c.BgColor),
				SqlHelper.MakeInParameter(AT + FIELD_BGPIC, SqlDbType.NVarChar, 255, c.BgPic),
				SqlHelper.MakeInParameter(AT + FIELD_SORTORDER, SqlDbType.Int, 4, c.SortOrder),
				SqlHelper.MakeInParameter(AT + FIELD_ALLOWTOADDSUBCATEGORY, SqlDbType.Bit, 1, c.AllowToAddSubCategory),
				SqlHelper.MakeInParameter(AT + FIELD_PARENTID, SqlDbType.Int, 4, c.ParentId),
				SqlHelper.MakeInParameter(AT + FIELD_LOGO, SqlDbType.NVarChar, 255, c.Logo),
				SqlHelper.MakeInParameter(AT + FIELD_LOGO2, SqlDbType.NVarChar, 255, c.Logo2),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, c.ActionDate == DateTime.MinValue ? DateTime.Now : c.ActionDate),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, c.ActionBy ?? String.Empty),
				SqlHelper.MakeParameter(AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1)
			};

			SqlHelper.ExecuteNonQuery(sqlConnectionString, CommandType.StoredProcedure, PROC_SAVE_MODEL, p);

			return Convert.ToInt32(p[p.Length - 1].Value);
		}

		public int Delete(int categoryId) {
			return SqlHelper.ExecuteNonQuery(sqlConnectionString, CommandType.Text, SQL_DELETE_ENTITY, SqlHelper.MakeInParameter(AT + FIELD_CATEGORYID, SqlDbType.Int, 4, categoryId));
		}

		private Category LoadCategory(IDataReader reader) {
			Category c = new Category();
			c.CategoryId = ReadInt(reader, FIELD_CATEGORYID);
			c.Name = ReadString(reader, FIELD_NAME);
			c.NameLocal = ReadString(reader, FIELD_NAMELOCAL);
			c.Description = ReadString(reader, FIELD_DESCRIPTION);
			c.BgColor = ReadString(reader, FIELD_BGCOLOR);
			c.BgPic = ReadString(reader, FIELD_BGPIC);
			c.SortOrder = ReadInt(reader, FIELD_SORTORDER);
			c.AllowToAddSubCategory = ReadBool(reader, FIELD_ALLOWTOADDSUBCATEGORY);
			c.ParentId = ReadInt(reader, FIELD_PARENTID);
			c.Logo = ReadString( reader, FIELD_LOGO );
			c.Logo2 = ReadString( reader, FIELD_LOGO2 );

			SetEntityProperties(c, reader);

			return c;
		}
	}
}
