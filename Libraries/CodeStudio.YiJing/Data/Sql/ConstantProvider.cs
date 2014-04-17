using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Entities;
using System.Data;
using System.Data.SqlClient;

namespace CodeStudio.YiJing.Data.Sql
{
    class ConstantProvider : BaseProvider, IConstantProvider
    {
		#region [ SQL Statements ]
		private const string SQL_GET_ENTITY = "SELECT * FROM Constants WHERE ConstantId = @ConstantId";
		private const string SQL_GET_ENTITIES = "SELECT * FROM Constants WHERE Code = @Code ORDER BY SortOrder";
		private const string SQL_GET_ALL = "SELECT * FROM Constants ORDER BY Code, Seq, SortOrder";
		private const string SQL_DELETE_ENTITY = "DELETE FROM Constants WHERE ConstantId = @ConstantId";
		#endregion

		#region [ Stored Procedures ]
		private const string PROC_SAVE_MODEL = "USP_Save_Constant";
		#endregion

		#region [ Fields ]
		private const string FIELD_CONSTANT_ID = "ConstantId";
		private const string FIELD_CODE = "Code";
		private const string FIELD_SEQ = "Seq";
		private const string FIELD_TEXT_VALUE = "TextValue";
		private const string FIELD_DESCRIPTION = "Description";
		private const string FIELD_TYPE = "Type";
		private const string FIELD_SORT_ORDER = "SortOrder";
		#endregion

		public Constant Get(int constantId) {
			Constant c = null;
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader(sqlConnectionString, CommandType.Text, SQL_GET_ENTITY, SqlHelper.MakeInParameter(AT + FIELD_CONSTANT_ID, SqlDbType.Int, 4, constantId));
				if (reader.Read()) {
					c = LoadConstant(reader);
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return c;
		}

		public List<Constant> Gets(string code) {
			List<Constant> cs = new List<Constant>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader(sqlConnectionString, CommandType.Text, SQL_GET_ENTITIES, SqlHelper.MakeInParameter(AT + FIELD_CODE, SqlDbType.VarChar, 50, code));
				while (reader.Read()) {
					cs.Add(LoadConstant(reader));
				}
			}
			finally {
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}

			return cs;
		}

		public List<Constant> Gets() {
			List<Constant> cs = new List<Constant>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader( sqlConnectionString, CommandType.Text, SQL_GET_ALL );
				while ( reader.Read() ) {
					cs.Add( LoadConstant( reader ) );
				}
			}
			finally {
				if ( reader != null && !reader.IsClosed )
					reader.Close();
			}

			return cs;
		}

		public int SaveOrUpdate(Constant c) {
			SqlParameter[] p = new SqlParameter[] { 
				SqlHelper.MakeInParameter(AT + FIELD_CONSTANT_ID, SqlDbType.Int, 4, c.ConstantId),
				SqlHelper.MakeInParameter(AT + FIELD_CODE, SqlDbType.VarChar, 50, c.Code),
				SqlHelper.MakeInParameter(AT + FIELD_SEQ, SqlDbType.Int, 4, c.Seq),
				SqlHelper.MakeInParameter(AT + FIELD_TEXT_VALUE, SqlDbType.NVarChar, 512, c.TextValue),
				SqlHelper.MakeInParameter(AT + FIELD_DESCRIPTION, SqlDbType.NVarChar, 255, c.Description),
				SqlHelper.MakeInParameter(AT + FIELD_TYPE, SqlDbType.Int, 4, (int)c.Type),
				SqlHelper.MakeInParameter(AT + FIELD_SORT_ORDER, SqlDbType.Int, 4, c.SortOrder),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, c.ActionDate == DateTime.MinValue ? DateTime.Now : c.ActionDate),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, c.ActionBy ?? String.Empty),
				SqlHelper.MakeParameter(AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1)
			};

			SqlHelper.ExecuteNonQuery(sqlConnectionString, CommandType.StoredProcedure, PROC_SAVE_MODEL, p);

			return Convert.ToInt32(p[p.Length - 1].Value);
		}

		public int Delete(int constantId) {
			return SqlHelper.ExecuteNonQuery(sqlConnectionString, CommandType.Text, SQL_DELETE_ENTITY, SqlHelper.MakeInParameter(AT + FIELD_CONSTANT_ID, SqlDbType.Int, 4, constantId));
		}

		private Constant LoadConstant(IDataReader reader) {
			Constant c = new Constant();

			c.ConstantId = ReadInt(reader, FIELD_CONSTANT_ID);
			c.Code = ReadString(reader, FIELD_CODE);
			c.Seq = ReadInt(reader, FIELD_SEQ);
			c.TextValue = ReadString(reader, FIELD_TEXT_VALUE);
			c.Description = ReadString( reader, FIELD_DESCRIPTION );
			c.Type = (ConstantType)ReadInt( reader, FIELD_TYPE );
			c.SortOrder = ReadInt( reader, FIELD_SORT_ORDER );

			SetEntityProperties(c, reader);

			return c;
		}
	}
}
