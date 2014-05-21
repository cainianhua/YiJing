using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;
using YiJingWebUI.UserControls;

namespace YiJingWebUI.News
{
	public partial class Detail : YiJingWebUI.BaseClasses.ArticlePageBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			this.CurrSort = SiteSort.News;
			this.CurrArticleId = CodeStudio.WebRequest.GetQueryInt( "aid", 0 );
			this.CurrPageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 0 );
			if ( !this.IsPostBack ) {
				if ( this.CurrArticleId <=0 && this.CurrPageIndex <= 0 ) {
					Response.Redirect( "/news/", true );
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

			// 背景
			base.BgColor = item.BgColor;
			if ( !string.IsNullOrEmpty( item.BgPic ) ) {
				base.BgImage = item.BgPic;
			}

			this.Page.Title = item.ArticleTitleLocal;

			//AboutDetail1.DataSource = item;
			NewsDetail ctl = ( NewsDetail )LoadControl( "~/UserControls/NewsDetail.ascx" );
			ctl.DataSource = item;
			Containers.Controls.Add( ctl );

			this.ClientScript.RegisterClientScriptBlock( typeof( Page ), "currentPageIndexScript", String.Format( "var currentPageNo = {0}; var currentCategoryId = {1}; var totalCount = {2};", CurrPageIndex, ( int )SiteSort.News, this.TotalCount ), true );
		}
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToPager() {
			ltrCurrPageIndex.Text = this.CurrPageIndex.ToString();
			ltrTotalCount.Text = this.TotalCount.ToString();
			lnkPrevious.NavigateUrl = String.Format( "/news/detail.aspx?pn={0}", Math.Max( 1, this.CurrPageIndex - 1 ) );
			lnkNext.NavigateUrl = String.Format( "/news/detail.aspx?pn={0}", Math.Min( this.CurrPageIndex + 1, this.TotalCount ) );
		}
	}
}