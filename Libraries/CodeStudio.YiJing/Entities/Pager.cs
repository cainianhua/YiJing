using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace CodeStudio.YiJing.Entities
{
	public class Pager<T> where T : Entity
	{
		private List<T> _DataItems;
		/// <summary>
		/// 当前页的数据列表
		/// </summary>
		public List<T> DataItems {
			get {
				if (_DataItems == null)
					_DataItems = new List<T>();
				return _DataItems;
			}
			set {
				_DataItems = value;
			}
		}

		/// <summary>
		/// 总记录数
		/// </summary>
		public int Total {
			get;
			set;
		}

		/// <summary>
		/// 当前页Index值
		/// </summary>
		public int CurrentPageIndex {
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		public int PageSize {
			get;
			set;
		}
	}
}
