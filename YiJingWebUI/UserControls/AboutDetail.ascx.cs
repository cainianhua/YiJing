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
		/// <summary>
		/// 
		/// </summary>
		public SiteSort Sort { get; set; }
		private int CurrArticleId { get; set; }
		private int TotalCount { get; set; }
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

			this.CurrArticleId = CodeStudio.WebRequest.GetQueryInt( "aid", 0 );
			this.CurrPageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 0 );

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
					lnkArticle.NavigateUrl = String.Format( "/{0}/?aid={1}", this.Sort.ToString().ToLower(), item.ArticleId );
					if ( item.ArticleId == this.CurrArticleId ) {
						lnkArticle.CssClass = "selected";
						// 设置背景
						base.BgColor = item.BgColor;
						if ( !string.IsNullOrEmpty( item.BgPic ) ) {
							base.BgImage = item.BgPic;
						}
					}
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			Article item = null;
			Pager<Article> articlePagers = new Pager<Article>();
			if ( this.CurrPageIndex > 0 ) {
				articlePagers = Factory.ArticleProvider.Gets( this.CurrPageIndex, 1, "", ( int )Sort );
			}
			else if ( this.CurrArticleId > 0 ) {
				articlePagers = Factory.ArticleProvider.GetPagedArticle( this.CurrArticleId );
			}

			this.CurrPageIndex = articlePagers.CurrentPageIndex;
			this.TotalCount = articlePagers.Total;
			if ( articlePagers.DataItems.Count > 0 ) {
				item = articlePagers.DataItems.Single();
			}

			if ( item == null ) return;

			this.CurrArticleId = item.ArticleId;
			ltrContent.Text = item.HtmlContent;
			this.Page.Title = item.ArticleTitleLocal;
			// 所有文章
			rptArticles.DataSource = Factory.ArticleProvider.Gets(item.CategoryId);
			rptArticles.DataBind();

			this.Page.ClientScript.RegisterClientScriptBlock( typeof( Page ), "currentPageIndexScript", String.Format( "var currentPageNo = {0}; var currentCategoryId = {1}; var totalCount = {2};", CurrPageIndex, ( int )Sort, this.TotalCount ), true );
		}
	}
}