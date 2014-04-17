using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio.YiJing.Entities
{
    public class Article : Entity
    {
		public int ArticleId { get; set; }
		public String ArticleTitle { get; set; }
		public String ArticleTitleLocal { get; set; }
		public String ArticleSubtitle { get; set; }
		public String TitleColor { get; set; }
		public String Keywords { get; set; }
		public String Description { get; set; }
		public String Thumbnail { get; set; }
		public String Remarks { get; set; }
		public String HtmlContent { get; set; }
		public String Tags { get; set; }
		public String BgColor { get; set; }
		public String BgPic { get; set; }
		public int SortOrder { get; set; }
		public int CategoryId { get; set; }
		/// <summary>
		/// 扩展字段，根分类
		/// </summary>
		public int ParentId { get; set; }

		public Article() {
			this.SortOrder = 9999;
			this.BgColor = this.TitleColor = "FFFFFF";
		}
    }
}
