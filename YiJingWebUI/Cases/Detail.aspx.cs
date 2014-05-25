using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;
using YiJingWebUI.UserControls;
using System.Collections.Specialized;

namespace YiJingWebUI.Cases
{
	public partial class Detail : YiJingWebUI.BaseClasses.ArticlePageBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			this.CurrSort = SiteSort.Cases;

			if ( !this.IsPostBack ) {
				if ( this.CurrArticleId <= 0 && this.CurrPageIndex <= 0 ) {
					Response.Redirect( "/cases/", true );
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

			BindDataToPager();

			//// 背景
			//base.BgColor = item.BgColor;
			//if ( !string.IsNullOrEmpty( item.BgPic ) ) {
			//    base.BgImage = item.BgPic;
			//}
			
			this.Page.Title = item.ArticleTitleLocal;

			//CaseDetail ctl = ( CaseDetail )LoadControl( "~/UserControls/CaseDetail.ascx" );
			//ctl.DataSource = item;
			//Containers.Controls.Add( ctl );

			//ArticleMetas ctlMetas = ( ArticleMetas )LoadControl( "~/UserControls/ArticleMetas.ascx" );
			//ctlMetas.DataSource = item;
			//MetaString.Controls.Add( ctlMetas );
			ArticleMetas1.DataSource = item;

			this.Page.ClientScript.RegisterClientScriptBlock( typeof( Page ), "currentPageIndexScript", String.Format( "var currentPageNo = {0}; var currentSort = {1}; var totalCount = {2};", CurrPageIndex, ( int )CurrSort, this.TotalCount ), true );
		}
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToPager() {
			ltrCurrPageIndex.Text = this.CurrPageIndex.ToString();
			ltrTotalCount.Text = this.TotalCount.ToString();
			lnkPrevious.NavigateUrl = String.Format( "/cases/detail.aspx?pn={0}", Math.Max( 1, this.CurrPageIndex - 1 ) );
			lnkNext.NavigateUrl = String.Format( "/cases/detail.aspx?pn={0}", Math.Min( this.CurrPageIndex + 1, this.TotalCount ) );
		}
	}
}