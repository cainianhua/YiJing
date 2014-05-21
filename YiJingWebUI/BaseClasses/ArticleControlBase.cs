using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeStudio.YiJing.Entities;

namespace YiJingWebUI.BaseClasses
{
	public class ArticleControlBase : ControlBase
	{
		/// <summary>
		/// 
		/// </summary>
		public Article DataSource { get; set; }
	}
}