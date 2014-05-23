using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.BaseClasses
{
	public class ArticleControlBase : ControlBase
	{
		/// <summary>
		/// 
		/// </summary>
		public Article DataSource { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public SiteSort CurrSort { get; set; }
	}
}