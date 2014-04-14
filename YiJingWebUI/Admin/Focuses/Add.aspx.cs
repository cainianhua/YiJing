using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;
using YiJingWebUI.Admin.UserControls;

namespace YiJingWebUI.Admin.Focuses
{
	public partial class Add : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			this.BoxTitle = "添加焦点图";
		}

		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			int faid = CodeStudio.WebRequest.GetQueryInt( "faid", 0 );
			if ( !this.IsPostBack ) {
				FocusArticle fa = new FocusArticle();
				if ( faid > 0 ) {
					fa = Factory.FocuseArticleProvider.Get( faid );
					BoxTitle = "编辑焦点图";
				}

				BindDateToWebUI( fa );	
			}
		}

		protected void btnSave_Click( object sender, EventArgs e ) {
			if ( Page.IsValid ) {
				FocusArticle fa = new FocusArticle();
				try {
					fa.FocusArticleId = int.Parse( FocusArticleId.Value );
					fa.Pic = Pic.Text.Trim();
					fa.Description = Description.Text.Trim();
					fa.LinkTo = LinkTo.Text.Trim();
					fa.SortOrder = int.Parse( SortOrder.Text.Trim() );
					fa.ActionDate = DateTime.Now;
					fa.ActionBy = User.Identity.Name;

					fa.FocusArticleId = Factory.FocuseArticleProvider.SaveOrUpdate( fa );
					if ( fa.FocusArticleId > 0 ) {
						Response.Redirect( "Default.aspx", true );
					}
				}
				catch ( Exception ex ) {
					MessageContainer.Controls.Add( 
						CreateMessage( "保存出错了，错误是：" + ex.Message, OperationStatus.error ) 
					);
				}
			}
		}

		private void BindDateToWebUI( FocusArticle item ) {
			FocusArticleId.Value = item.FocusArticleId.ToString();
			if ( !string.IsNullOrEmpty( item.Pic ) ) {
				Pic.Text = item.Pic;
				imgPic.ImageUrl = item.Pic;
			}
			Description.Text = item.Description;
			LinkTo.Text = item.LinkTo;
			SortOrder.Text = item.SortOrder.ToString();
		}
	}
}