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
	public partial class AboutDetail : YiJingWebUI.BaseClasses.ControlBase
	{
		public string RootUrl { get; set; }

		private int CurrentArticleId;
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

			this.CurrentArticleId = CodeStudio.WebRequest.GetQueryInt( "aid", 0 );
			if ( !this.IsPostBack ) {
				if ( CurrentArticleId > 0 ) {
					BindDataToWebUI();
				}
				else {
					Response.Redirect( "/", true );
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
					lnkArticle.NavigateUrl = String.Format( "{0}/?aid={1}", this.RootUrl, item.ArticleId );
					if ( item.ArticleId == this.CurrentArticleId ) {
						lnkArticle.CssClass = "selected";
					}
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			// 当前文章
			Article currItem = Factory.ArticleProvider.Get( this.CurrentArticleId );
			ltrContent.Text = currItem.HtmlContent;
			this.Page.Title = currItem.ArticleTitleLocal;
			// 所有文章
			List<Article> articles = Factory.ArticleProvider.Gets( currItem.CategoryId );
			rptArticles.DataSource = articles;
			rptArticles.DataBind();
			// 设置背景
			foreach ( Article item in articles ) {
				if ( item.ArticleId == this.CurrentArticleId ) {
					base.BgColor = item.BgColor;
					if ( !string.IsNullOrEmpty( item.BgPic ) ) {
						base.BgImage = item.BgPic;
					}
				}
			}
		}
	}
}