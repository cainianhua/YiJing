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
	public partial class AboutUS : YiJingWebUI.BaseClasses.ControlBase
	{
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			if ( !this.IsPostBack ) {
				BindDataToWebUI();
			}
		}

		private void BindDataToWebUI() {
			Category c = Factory.CategoryProvider.Get( ( int )SiteSort.AboutUs );
			//ltrName.Text = c.Name.ToUpper();
			//ltrNameLocal.Text = c.NameLocal;

			CategoryLogo.ImageUrl = c.Logo;
			CategoryLogo.AlternateText = c.NameLocal;

			rptAboutUs.DataSource = Factory.ArticleProvider.Gets( (int)SiteSort.AboutUs );
			rptAboutUs.DataBind();
		}
	}
}