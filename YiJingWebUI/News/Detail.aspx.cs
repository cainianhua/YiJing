using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.News
{
	public partial class Detail : YiJingWebUI.BaseClasses.PageBase
	{
		private int CurrArticleId { get; set; }
		private int TotalCount { get; set; }

		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );

			this.rptTags.ItemDataBound += new RepeaterItemEventHandler( rptTags_ItemDataBound );
		}

		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

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
		/// 关键字绑定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptTags_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.AlternatingItem
				|| e.Item.ItemType == ListItemType.Item ) 
			{
				string tag = ( string )e.Item.DataItem;
				if ( string.IsNullOrEmpty(tag) ) return;

				HyperLink lnkTag = ( HyperLink )e.Item.FindControl( "lnkTag" );
				if ( lnkTag != null ) {
					lnkTag.Text = tag;
					lnkTag.NavigateUrl = String.Format( "/search.aspx?s={0}&type=tag",  tag);
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
				articlePagers = Factory.ArticleProvider.Gets( this.CurrPageIndex, 1, "", ( int )SiteSort.News );
			}
			else if(this.CurrArticleId > 0) {
				articlePagers = Factory.ArticleProvider.GetPagedArticle( this.CurrArticleId );
			}

			this.CurrPageIndex = articlePagers.CurrentPageIndex;
			this.TotalCount = articlePagers.Total;
			if ( articlePagers.DataItems.Count > 0 ) {
				item = articlePagers.DataItems.Single();
			}

			BindDataToPager();

			if ( item == null ) return;

			if ( !string.IsNullOrEmpty( item.Tags ) ) { 
				// tag是用空格隔开
				string[] tags = item.Tags.Split(' ');
				this.rptTags.DataSource = tags.ToList();
				this.rptTags.DataBind();
			}
			// 背景
			base.BgColor = item.BgColor;
			if ( !string.IsNullOrEmpty( item.BgPic ) ) {
				base.BgImage = item.BgPic;
			}

			this.Page.Title = ArticleTitle.Text = item.ArticleTitleLocal;
			CreatedDate.Text = item.CreatedDate.ToString( "yyyy-MM-dd" );
			HtmlContent.Text = item.HtmlContent;
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