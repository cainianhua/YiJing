using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.Data.Sql
{
	internal class ManagerProvider : BaseProvider, IManagerProvider
	{
		#region [ SQL Statements ]
		private const string SQL_GET_ITEM = "SELECT * FROM [dbo].[Managers] WHERE ManagerId = @ManagerId";
		private const string SQL_GET_ITEM_BY_NAME = "SELECT * FROM [dbo].[Managers] WHERE Name = @Name";
		private const string SQL_GET_ALL = "SELECT * FROM [dbo].[Managers]";
		#endregion

		private const string PROC_SAVE_ITEM = "USP_Save_Manager";

		#region [ Fields ]
		private const string FIELD_ManagerId = "ManagerId";
		private const string FIELD_Name = "Name";
		private const string FIELD_NickName = "NickName";
		private const string FIELD_Pwd = "Pwd";
		#endregion
		/// <summary>
		/// 
		/// </summary>
		/// <param name="managerId"></param>
		/// <returns></returns>
		public Manager Get( int managerId ) {
			Manager c = null;
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader( sqlConnectionString, CommandType.Text, SQL_GET_ITEM, SqlHelper.MakeInParameter( AT + FIELD_ManagerId, SqlDbType.Int, 4, managerId ) );
				if ( reader.Read() ) {
					c = LoadManager( reader );
				}
			}
			finally {
				if ( reader != null && !reader.IsClosed )
					reader.Close();
			}

			return c;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Manager Get( string name ) {
			Manager c = null;
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader( sqlConnectionString, CommandType.Text, SQL_GET_ITEM_BY_NAME, SqlHelper.MakeInParameter( AT + FIELD_Name, SqlDbType.NVarChar, 50, name ) );
				if ( reader.Read() ) {
					c = LoadManager( reader );
				}
			}
			finally {
				if ( reader != null && !reader.IsClosed )
					reader.Close();
			}

			return c;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<Manager> Gets() {
			List<Manager> items = new List<Manager>();
			IDataReader reader = null;

			try {
				reader = SqlHelper.ExecuteReader( sqlConnectionString, CommandType.Text, SQL_GET_ALL );
				while ( reader.Read() ) {
					items.Add( LoadManager( reader ) );
				}
			}
			finally {
				if ( reader != null && !reader.IsClosed )
					reader.Close();
			}

			return items;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public int SaveOrUpdate( Manager c ) {
			SqlParameter[] p = new SqlParameter[] { 
				SqlHelper.MakeInParameter(AT + FIELD_ManagerId, SqlDbType.NVarChar, 50, c.ManagerId),
				SqlHelper.MakeInParameter(AT + FIELD_Name, SqlDbType.NVarChar, 50, c.Name),
				SqlHelper.MakeInParameter(AT + FIELD_NickName, SqlDbType.NVarChar, 50, c.NickName),
				SqlHelper.MakeInParameter(AT + FIELD_Pwd, SqlDbType.NVarChar, 50, c.Pwd),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_DATE, SqlDbType.DateTime, 8, c.ActionDate == DateTime.MinValue ? DateTime.Now : c.ActionDate),
				SqlHelper.MakeInParameter(AT + FIELD_ACTION_BY, SqlDbType.NVarChar, 50, c.ActionBy ?? String.Empty),
				SqlHelper.MakeParameter(AT + FIELD_RETURN_VALUE, SqlDbType.Int, 4, ParameterDirection.Output, -1)
			};

			SqlHelper.ExecuteNonQuery( sqlConnectionString, CommandType.StoredProcedure, PROC_SAVE_ITEM, p );

			return Convert.ToInt32( p[p.Length - 1].Value );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		private Manager LoadManager( IDataReader reader ) {
			Manager c = new Manager();
			c.ManagerId = ReadInt( reader, FIELD_ManagerId );
			c.Name = ReadString( reader, FIELD_Name );
			c.NickName = ReadString( reader, FIELD_NickName );
			c.Pwd = ReadString( reader, FIELD_Pwd );

			SetEntityProperties( c, reader );

			return c;
		}
	}
}
