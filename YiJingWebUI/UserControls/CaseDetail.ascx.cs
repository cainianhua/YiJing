using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;

namespace YiJingWebUI.UserControls
{
	public partial class CaseDetail : YiJingWebUI.BaseClasses.ArticleControlBase
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );

			this.rptTags.ItemDataBound += new RepeaterItemEventHandler( rptTags_ItemDataBound );
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
				//if ( this.CurrArticleId <= 0 && this.CurrPageIndex <= 0 ) {
				//    Response.Redirect( "/cases/", true );
				//}
				if ( DataSource != null ) {
					BindDataToWebUI();
				}
			}
		}

		/// <summary>
		/// 关键字绑定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptTags_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.AlternatingItem
				|| e.Item.ItemType == ListItemType.Item ) {
				string tag = ( string )e.Item.DataItem;
				if ( string.IsNullOrEmpty( tag ) ) return;

				HyperLink lnkTag = ( HyperLink )e.Item.FindControl( "lnkTag" );
				if ( lnkTag != null ) {
					lnkTag.Text = tag;
					lnkTag.NavigateUrl = String.Format( "/search/?s={0}&type=tag", tag );
					lnkTag.Attributes.Add( "style", string.Format( "color:#{0}", DataSource.TagsColor ) );
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			Article item = DataSource;

			if ( !string.IsNullOrEmpty( item.Tags ) ) {
				// tag是用空格隔开
				string[] tags = item.Tags.Split( ' ' );
				this.rptTags.DataSource = tags.ToList();
				this.rptTags.DataBind();
			}
			// 文字颜色
			TitleColor.Text = item.TitleColor;
			SubTitleColor.Text = item.SubTitleColor;
			RemarksColor.Text = item.RemarksColor;
			TagsColor.Text = item.TagsColor;

			ArticleTitle.Text = item.ArticleTitleLocal;
			ArticleSubtitle.Text = item.ArticleSubtitle;
			ArticleRemarks.Text = item.Remarks;
			//CreatedDate.Text = item.CreatedDate.ToString( "yyyy-MM-dd" );
			HtmlContent.Text = item.HtmlContent;
		}
	}
}