using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.UserControls
{
	public partial class AboutDetail : YiJingWebUI.BaseClasses.ArticleControlBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );

			this.rptArticles.ItemDataBound += new RepeaterItemEventHandler( rptArticles_ItemDataBound );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			//this.CurrArticleId = CodeStudio.WebRequest.GetQueryInt( "aid", 0 );
			//this.CurrPageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 0 );

			if ( !this.IsPostBack ) {
				//if ( CurrArticleId <= 0 && CurrPageIndex <= 0 ) {
				//    Response.Redirect( "/", true );
				//}
				if ( DataSource != null ) {
					BindDataToWebUI();
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptArticles_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.AlternatingItem
				|| e.Item.ItemType == ListItemType.Item ) {
				Article item = ( Article )e.Item.DataItem;
				if ( item == null ) return;

				HyperLink lnkArticle = ( HyperLink )e.Item.FindControl( "lnkArticle" );
				if ( lnkArticle != null ) {
					lnkArticle.Text = item.ArticleTitleLocal;
					lnkArticle.NavigateUrl = String.Format( "/{0}/?aid={1}", ( ( SiteSort )item.CategoryId ).ToString().ToLower(), item.ArticleId );
					if ( item.ArticleId == DataSource.ArticleId ) {
						lnkArticle.CssClass = "selected";
					}
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			Article item = DataSource;
			
			this.ltrContent.Text = item.HtmlContent;
			//this.Page.Title = item.ArticleTitleLocal;
			// 设置背景
			//base.BgColor = item.BgColor;
			//if ( !string.IsNullOrEmpty( item.BgPic ) ) {
			//    base.BgImage = item.BgPic;
			//}
			// 所有文章
			rptArticles.DataSource = Factory.ArticleProvider.Gets(item.CategoryId);
			rptArticles.DataBind();
		}
	}
}