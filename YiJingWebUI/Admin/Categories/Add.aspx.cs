using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;
using YiJingWebUI.Admin.UserControls;

namespace YiJingWebUI.Admin.Categories
{
	public partial class Add : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		#region [ 事件处理 ]
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );

			this.BoxTitle = "添加分类";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			int id = CodeStudio.WebRequest.GetQueryInt( "id", 0 );
			string action = CodeStudio.WebRequest.GetQueryString( "action", "add" );

			if ( !this.IsPostBack ) {
				Category item = new Category();

				if ( action.Equals( "add", StringComparison.OrdinalIgnoreCase ) ) {
					parentItem.Visible = true;
					BindDataToDropdownList( id.ToString() );
				}
				else {
					this.BoxTitle = "修改分类";
					if ( id == 0 ) Response.Redirect( "Default.aspx", true );

					item = Factory.CategoryProvider.Get( id );
					if ( item == null ) Response.Redirect( "Default.aspx", true );
					// 修改的时候，当前Category的ParentId不为－1的情况下，
					// 需要显示父级分类下来列表
					if ( item.ParentId > 0 ) {
						parentItem.Visible = true;
						BindDataToDropdownList( item.ParentId.ToString() );
					}
				}
				BindDataToWebUI( item );
			}
		}
		/// <summary>
		/// 保存Category
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSave_Click( object sender, EventArgs e ) {
			if ( Page.IsValid ) {
				Category item = new Category();

				try {
					item.CategoryId = int.Parse( CategoryId.Value );
					item.Name = Name.Text.Trim();
					item.NameLocal = NameLocal.Text.Trim();
					item.Description = Description.Text.Trim();
					item.BgColor = BgColor.Text.Trim();
					item.BgPic = BgPic.Value.Trim();
					item.SortOrder = int.Parse( SortOrder.Text );
					item.AllowToAddSubCategory = bool.Parse( AllToAddSubCategory.Value );
					item.ParentId = int.Parse( ParentId.Value );
					if ( drpParentId.Visible && !string.IsNullOrEmpty( drpParentId.SelectedValue ) ) {
						item.ParentId = int.Parse( drpParentId.SelectedValue );
					}
					item.Logo = Logo.Value.Trim();
					item.Logo2 = Logo2.Value.Trim();
					item.ActionDate = DateTime.Now;
					item.ActionBy = User.Identity.Name;

					item.CategoryId = Factory.CategoryProvider.SaveOrUpdate( item );
					if ( item.CategoryId > 0 ) {
						Response.Redirect( "Default.aspx", true );
					}
				}
				catch ( Exception ex ) {
					MessageTips controlLayer = ( MessageTips )LoadControl( "~/Admin/UserControls/MessageTips.ascx" );
					controlLayer.ID = "MessageContent";
					controlLayer.Text = "保存出错啦，错误是：" + ex.Message;
					controlLayer.Status = OperationStatus.error;

					MessageContainer.Controls.Add( controlLayer );
				}
			}
		}
		#endregion

		#region [ 私有方法 ]
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		private void BindDataToWebUI(Category item) {
			CategoryId.Value = item.CategoryId.ToString();
			Name.Text = item.Name;
			NameLocal.Text = item.NameLocal;
			Description.Text = item.Description;
			BgColor.Text = item.BgColor;
			if ( !string.IsNullOrEmpty( item.BgPic ) ) {
				BgPic.Value = item.BgPic;
				imgBgPic.ImageUrl = item.BgPic;
			}
			if ( !string.IsNullOrEmpty( item.Logo ) ) {
				Logo.Value = item.Logo;
				imgLogo.ImageUrl = item.Logo;
			}
			if ( !string.IsNullOrEmpty( item.Logo2 ) ) {
				Logo2.Value = item.Logo2;
				imgLogo2.ImageUrl = item.Logo2;
			}
			SortOrder.Text = item.SortOrder.ToString();
			AllToAddSubCategory.Value = item.AllowToAddSubCategory.ToString();
			ParentId.Value = item.ParentId.ToString();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="selectedValue"></param>
		private void BindDataToDropdownList( string selectedValue ) {
			List<Category> categories = Factory.CategoryProvider.GetsAllowedChilds( -1 );
			drpParentId.DataTextField = "NameLocal";
			drpParentId.DataValueField = "CategoryId";
			drpParentId.DataSource = categories;
			drpParentId.DataBind();

			//ParentId.Items.Insert( 0, new ListItem( "请选择", "-1" ) );

			drpParentId.ClearSelection();
			drpParentId.SelectedIndex = drpParentId.Items.IndexOf( drpParentId.Items.FindByValue( selectedValue ) );
		}
		#endregion
	}
}