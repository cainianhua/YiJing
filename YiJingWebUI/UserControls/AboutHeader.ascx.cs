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
	public partial class AboutHeader : System.Web.UI.UserControl
	{
		/// <summary>
		/// 
		/// </summary>
		public SiteSort Sort {
			get;
			set;
		}
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

		private void BindDataToWebUI() {
			if ( Sort != SiteSort.NotSet ) {
				Category item = Factory.CategoryProvider.Get( ( int )Sort );
				if ( item != null ) {
					//Name.Text = HttpUtility.HtmlEncode(item.Name.Trim());
					//NameLocal.Text = HttpUtility.HtmlEncode(item.NameLocal.Trim());
					CategoryLogo.ImageUrl = item.Logo2;
					CategoryLogo.AlternateText = item.NameLocal;
				}
			}
		}
	}
}