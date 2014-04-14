using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio.YiJing.Entities
{
    public class Category : Entity
    {
		public int CategoryId { get; set; }
		public String Name { get; set; }
		public String NameLocal { get; set; }
		public String Description { get; set; }
		private string _BgColor = "FFFFFF";
		public String BgColor {
			get { return _BgColor; }
			set { _BgColor = value; }
		}
		public String BgPic { get; set; }
		private int _SortOrder = 9999;
		public int SortOrder {
			get { return _SortOrder; }
			set { _SortOrder = value; }
		}
		public bool AllowToAddSubCategory { get; set; }
		public int ParentId { get; set; }
    }
}
