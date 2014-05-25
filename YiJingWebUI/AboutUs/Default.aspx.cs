using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;
using YiJingWebUI.UserControls;

namespace YiJingWebUI.AboutUs
{
	public partial class Default : YiJingWebUI.BaseClasses.ArticlePageBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			this.CurrSort = SiteSort.AboutUs;
			
			if ( !this.IsPostBack ) {
				if ( CurrArticleId <= 0 && CurrPageIndex <= 0 ) {
					Response.Redirect( "/", true );
				}

				BindDataToWebUI();
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			Article item = base.CurrArticle;
			if ( item == null ) return;

			this.Page.Title = item.ArticleTitleLocal;
			//// 设置背景
			//base.BgColor = item.BgColor;
			//if ( !string.IsNullOrEmpty( item.BgPic ) ) {
			//    base.BgImage = item.BgPic;
			//}

			//AboutDetail ctlAbout = ( AboutDetail )LoadControl( "~/UserControls/AboutDetail.ascx" );
			//ctlAbout.DataSource = item;
			//ctlAbout.CurrSort = CurrSort;
			//Containers.Controls.Add( ctlAbout );

			//ArticleMetas ctlMetas = ( ArticleMetas )LoadControl( "~/UserControls/ArticleMetas.ascx" );
			//ctlMetas.DataSource = item;
			//Metas.Controls.Add( ctlMetas );

			ArticleMetas1.DataSource = item;

			this.Page.ClientScript.RegisterClientScriptBlock( typeof( Page ), "currentPageIndexScript", String.Format( "var currentPageNo = {0}; var currentSort = {1}; var totalCount = {2};", CurrPageIndex, ( int )CurrSort, this.TotalCount ), true );
		}
	}
}