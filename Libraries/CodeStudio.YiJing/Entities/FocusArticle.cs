using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio.YiJing.Entities
{
    public class FocusArticle : Entity
    {
		public int FocusArticleId { get; set; }
		public String Pic { get; set; }
		public String Description { get; set; }
		public String LinkTo { get; set; }
		private int _SortOrder = 9999;
		public int SortOrder {
			get { return _SortOrder; }
			set { _SortOrder = value; }
		}
    }
}
