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
	public partial class News : YiJingWebUI.BaseClasses.ControlBase
	{
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
			Category c = Factory.CategoryProvider.Get( ( int )SiteSort.News );
			//ltrName.Text = c.Name.ToUpper();
			//ltrNameLocal.Text = c.NameLocal;
			CategoryLogo.ImageUrl = c.Logo;
			CategoryLogo.AlternateText = c.NameLocal;

			rptNews.DataSource = CodeStudio.YiJing.Factory.ArticleProvider.Gets( 1, 12, string.Empty, ( int )SiteSort.News ).DataItems;
			rptNews.DataBind();
		}
	}
}