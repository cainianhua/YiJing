using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.Data.Sql
{
    internal class BaseProvider
    {
        protected static readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

        protected const string FIELD_CREATED_DATE = "CreatedDate";
        protected const string FIELD_CREATED_BY = "CreatedBy";
        protected const string FIELD_MODIFIED_DATE = "ModifiedDate";
        protected const string FIELD_MODIFIED_BY = "ModifiedBy";
        protected const string FIELD_RETURN_VALUE = "ReturnValue";
        protected const string FIELD_SEARCH_TEXT = "SearchText";
		protected const string FIELD_PAGE_SIZE = "PageSize";
		protected const string FIELD_PAGE_NO = "PageNo";
        protected const string FIELD_TOTAL = "Total";
		protected const string FIELD_ROW_NO = "RowNo";
        protected const string AT = "@";
		// 非数据表字段常量
		protected const string FIELD_ACTION_DATE = "ActionDate";
		protected const string FIELD_ACTION_BY = "ActionBy";

        protected const int TWENTY_FOUR_HOURS = 1440;   // cache duration(minutes)

        protected string ReadString(IDataReader reader, string p) {
            return reader[p] == DBNull.Value ? string.Empty : Convert.ToString(reader[p]);
        }

        protected int ReadInt(IDataReader reader, string p) {
            return reader[p] == DBNull.Value ? 0 : Convert.ToInt32(reader[p]);
        }

        protected long ReadLong(IDataReader reader, string p) {
            return reader[p] == DBNull.Value ? 0 : Convert.ToInt64(reader[p]);
        }

        protected DateTime ReadDate(IDataReader reader, string p) {
            return reader[p] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader[p]);
        }

        protected DateTime? ReadDateNullAble(IDataReader reader, string p) {
            if (reader[p] == DBNull.Value) {
                return null;
            }
            else {
                return Convert.ToDateTime(reader[p]);
            }
        }

        protected bool ReadBool(IDataReader reader, string p) {
            return reader[p] == DBNull.Value ? false : Convert.ToBoolean(reader[p]);
        }

		protected void SetEntityProperties(Entity e, IDataReader reader) {
			if (e != null) {
				e.CreatedDate = ReadDate(reader, FIELD_CREATED_DATE);
				e.CreatedBy = ReadString(reader, FIELD_CREATED_BY);
				e.ModifiedDate = ReadDate(reader, FIELD_MODIFIED_DATE);
				e.ModifiedBy = ReadString(reader, FIELD_MODIFIED_BY);
			}
		}
    }
}
