using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.Admin.Categories
{
	public partial class Default : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		#region [ 事件处理 ]
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );

			this.BoxTitle = "分类列表";
			this.gvCategories.RowDataBound += new GridViewRowEventHandler( gvCategories_RowDataBound );
			this.gvCategories.PreRender += new EventHandler( gvCategories_PreRender );
			this.gvCategories.RowCommand += new GridViewCommandEventHandler( gvCategories_RowCommand );
			this.gvCategories.RowDeleting += new GridViewDeleteEventHandler( gvCategories_RowDeleting );
		}

		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			if ( !this.IsPostBack ) {
				BindDataToWebUI();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void gvCategories_RowDataBound( object sender, GridViewRowEventArgs e ) {
			if ( e.Row.RowType == DataControlRowType.DataRow ) {
				Category item = e.Row.DataItem as Category;
				if ( item == null ) return;

				TextBox txtName = (TextBox)e.Row.FindControl( "Name" );
				TextBox txtDescription = ( TextBox )e.Row.FindControl( "Description" );
				Literal ltrOthers = ( Literal )e.Row.FindControl( "Others" );
				HtmlAnchor btnAdd = ( HtmlAnchor )e.Row.FindControl( "addButton" );
				if ( txtName != null ) {
					txtName.Text = String.Format( "{0}/{1}", item.NameLocal, item.Name );
				}

				if ( txtDescription != null ) {
					txtDescription.Text = item.Description;
				}

				if ( ltrOthers != null ) {
					ltrOthers.Text = item.ParentId > 0 ? "二级分类" : "一级分类";
				}

				if ( btnAdd != null ) {
					btnAdd.HRef = String.Format( "Add.aspx?action=Add&id={0}", item.CategoryId );
					btnAdd.Visible = item.AllowToAddSubCategory;
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void gvCategories_PreRender( object sender, EventArgs e ) {
			GridView GridView1 = ( GridView )sender;

			if ( GridView1 != null && GridView1.Rows.Count > 0 ) {
				// 使用<TH>替换<TD>
				GridView1.UseAccessibleHeader = true;
				//This will add the <thead> and <tbody> elements
				//HeaderRow将被<thead>包裹，数据行将被<tbody>包裹
				GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
				// FooterRow将被<tfoot>包裹
				GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void gvCategories_RowCommand( object sender, CommandEventArgs e ) { 
			 int categoryId = int.Parse(e.CommandArgument.ToString());
			 //switch ( e.CommandName ) {
			 //    case "Delete":
			 //        Factory.CategoryProvider.Delete(categoryId);
			 //        BindDataToWebUI();
			 //        break;
			 //}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void gvCategories_RowDeleting( object sender, GridViewDeleteEventArgs e ) {
			int categoryId = int.Parse( this.gvCategories.DataKeys[e.RowIndex].Values[0].ToString() );
			Factory.CategoryProvider.Delete( categoryId );
			BindDataToWebUI();
		}
		#endregion

		#region [ 私有方法 ]
		private void BindDataToWebUI() {
			List<Category> items = Factory.CategoryProvider.Gets();
			gvCategories .DataSource = items;
			gvCategories.DataBind();
		}
		#endregion

		
	}
}