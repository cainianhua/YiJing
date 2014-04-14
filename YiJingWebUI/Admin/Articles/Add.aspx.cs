using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;
using YiJingWebUI.Admin.UserControls;

namespace YiJingWebUI.Admin.Articles
{
	public partial class Add : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			this.BoxTitle = "添加文章";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			int aid = CodeStudio.WebRequest.GetQueryInt( "aid", 0 );

			if ( !this.IsPostBack ) {
				Article item = new Article();
				if ( aid > 0 ) {
					item = Factory.ArticleProvider.Get( aid );
					if ( item != null ) {
						this.BoxTitle = "编辑文章";
					}
				}
				BindDateToWebUI( item );
			}
		}
		/// <summary>
		/// 验证用户是否选择Category
		/// </summary>
		/// <param name="source"></param>
		/// <param name="args"></param>
		protected void CustomValidator1_ServerValidate( object source, ServerValidateEventArgs args ) {
			args.IsValid = false;
			if ( !string.IsNullOrEmpty( args.Value ) ) {
				int categoryId = 0;
				if ( int.TryParse( args.Value, out categoryId ) && categoryId > 0 ) {
					args.IsValid = true;
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSave_Click( object sender, EventArgs e ) {
			if ( Page.IsValid ) {
				Article item = new Article();
				try {
					item.ArticleId = int.Parse( ArticleId.Value );
					item.ArticleTitle = ArticleTitle.Text.Trim();
					item.ArticleTitleLocal = ArticleTitleLocal.Text.Trim();
					item.ArticleSubtitle = ArticleSubtitle.Text.Trim();
					item.Keywords = Keywords.Text.Trim();
					item.Description = Description.Text.Trim();
					item.Thumbnail = Thumbnail.Text.Trim();
					item.Remarks = Remarks.Text.Trim();
					item.HtmlContent = HtmlContent.Text.Trim();
					item.Tags = Tags.Text.Trim();
					item.BgColor = BgColor.Text.Trim();
					item.BgPic = BgPic.Value.Trim();
					item.SortOrder = int.Parse(SortOrder.Text.Trim());
					item.CategoryId = int.Parse( drpCategoryId.SelectedValue );
					item.ActionDate = DateTime.Now;
					item.ActionBy = User.Identity.Name;

					item.ArticleId = Factory.ArticleProvider.SaveOrUpdate( item );
					if ( item.ArticleId > 0 )
						Response.Redirect( "Default.aspx?cid=" + item.CategoryId, true );
				}
				catch ( Exception ex ) {
					MessageTips tips = ( MessageTips )LoadControl( "~/Admin/UserControls/MessageTips.ascx" );
					tips.ID = "MessageContent";
					tips.Text = "保存出错啦，错误是：" + ex.Message;
					tips.Status = OperationStatus.error;

					MessageContainer.Controls.Add( tips );
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		private void BindDateToWebUI(Article item) {
			if ( item == null ) return;
			
			ArticleId.Value = item.ArticleId.ToString();
			ArticleTitle.Text = item.ArticleTitle;
			ArticleTitleLocal.Text = item.ArticleTitleLocal;
			ArticleSubtitle.Text = item.ArticleSubtitle;
			Keywords.Text = item.Keywords;
			Description.Text = item.Description;
			Thumbnail.Text = item.Thumbnail;
			if ( !string.IsNullOrEmpty( item.Thumbnail ) ) {
				imgThumbnail.ImageUrl = item.Thumbnail;
			}
			Remarks.Text = item.Remarks;
			HtmlContent.Text = item.HtmlContent;
			Tags.Text = item.Tags;
			BgColor.Text = item.BgColor;
			BgPic.Value = item.BgPic;
			if ( !string.IsNullOrEmpty( item.BgPic ) ) {
				imgBgPic.ImageUrl = item.BgPic;
			}
			SortOrder.Text = item.SortOrder.ToString();

			BindDateToDropdownList( item.CategoryId.ToString() );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="selectedValue"></param>
		private void BindDateToDropdownList(string selectedValue) {
			drpCategoryId.DataSource = Factory.CategoryProvider.Gets().Where( item => item.AllowToAddSubCategory == false );
			drpCategoryId.DataTextField = "NameLocal";
			drpCategoryId.DataValueField = "CategoryId";
			drpCategoryId.DataBind();

			drpCategoryId.Items.Insert( 0, new ListItem( "请选择", "0" ) );

			drpCategoryId.ClearSelection();
			drpCategoryId.SelectedIndex = drpCategoryId.Items.IndexOf( drpCategoryId.Items.FindByValue( selectedValue ) );
		}
	}
}