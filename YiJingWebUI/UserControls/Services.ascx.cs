using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;

namespace YiJingWebUI.UserControls
{
	public partial class Services : YiJingWebUI.BaseClasses.ControlBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			if ( !this.IsPostBack ) {
				BindDataToWebUI();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			Category c = Factory.CategoryProvider.Get( ( int )SiteSort.Services );
			CategoryLogo.ImageUrl = c.Logo;
			CategoryLogo.AlternateText = c.NameLocal;

			var articles = Factory.ArticleProvider.Gets( (int)SiteSort.Services );

			rptArticles.DataSource = articles;
			rptArticles.DataBind();

			rptArticles2.DataSource = articles;
			rptArticles2.DataBind();
		}
	}
}