using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;
using System.Web.UI.HtmlControls;

namespace YiJingWebUI.Admin.Settings
{
	public partial class Default : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			base.BoxTitle = "系统配置";
			this.GridView1.RowDataBound += new GridViewRowEventHandler( GridView1_RowDataBound );
			this.GridView1.PreRender += new EventHandler( GridView1_PreRender );
			this.GridView1.RowDeleting += new GridViewDeleteEventHandler( GridView1_RowDeleting );
			//this.GridView1.RowCommand += new GridViewCommandEventHandler( GridView1_RowCommand );
			this.GridView1.RowCreated += new GridViewRowEventHandler( GridView1_RowCreated );
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
		protected void GridView1_RowDataBound( object sender, GridViewRowEventArgs e ) {
			if ( e.Row.RowType == DataControlRowType.DataRow ) {
				Constant item = e.Row.DataItem as Constant;
				if ( item == null ) return;

				TextBox txtDescription = ( TextBox )e.Row.FindControl( "Description" );
				TextBox txtTextValue = ( TextBox )e.Row.FindControl( "TextValue" );
				Image imgTextValue = ( Image )e.Row.FindControl( "imgTextValue" );
				HtmlControl colorTextValue = ( HtmlControl )e.Row.FindControl( "colorTextValue" );
				
				Literal ltrOthers = ( Literal )e.Row.FindControl( "Others" );
				
				if ( txtDescription != null ) {
					txtDescription.Text = item.Description;
				}

				if ( imgTextValue != null && txtTextValue != null ) {
					if ( item.Type == ConstantType.Image ) {
						imgTextValue.ImageUrl = item.TextValue;
						imgTextValue.Visible = true;
					}
					else if ( item.Type == ConstantType.Color ) {
						colorTextValue.Visible = true;
						colorTextValue.Attributes.Add( "style", "background-color:#" + item.TextValue );
					}
					else {
						txtTextValue.Visible = true;
						txtTextValue.Text = item.TextValue;
					}
				}

				if ( ltrOthers != null ) {
					ltrOthers.Text = String.Format( "{0}/{1}", item.Code, item.Seq );
				}

				// 操作按钮
				HtmlAnchor btnAdd = ( HtmlAnchor )e.Row.FindControl( "addButton" );
				LinkButton btnDelete = ( LinkButton )e.Row.FindControl( "deleteButton" );
				HtmlAnchor btnEdit = ( HtmlAnchor )e.Row.FindControl( "editButton" );
				
				if ( item.Type == ConstantType.Text ) {
					if ( btnEdit != null ) btnEdit.HRef = String.Format( "AddText.aspx?cid={0}", item.ConstantId );
				}
				else if ( item.Type == ConstantType.Image ) {
					if ( btnEdit != null ) btnEdit.HRef = String.Format( "AddImage.aspx?cid={0}", item.ConstantId );
				}
				else if ( item.Type == ConstantType.Color ) {
					if ( btnEdit != null ) btnEdit.HRef = String.Format( "AddColor.aspx?cid={0}", item.ConstantId );
				}
				else {
					if ( btnAdd != null ) btnAdd.Visible = true;
					if ( btnDelete != null ) btnDelete.Visible = true;
					if ( btnEdit != null ) btnEdit.HRef = String.Format( "Add.aspx?cid={0}", item.ConstantId );
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GridView1_PreRender( object sender, EventArgs e ) {
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
		protected void GridView1_RowDeleting( object sender, GridViewDeleteEventArgs e ) {
			int itemId = int.Parse( this.GridView1.DataKeys[e.RowIndex].Values[0].ToString() );
			Factory.ConstantProvider.Delete( itemId );
			BindDataToWebUI();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GridView1_RowCreated( object sender, GridViewRowEventArgs e ) {
			if ( e.Row.RowType == DataControlRowType.Footer ) {
				e.Row.Cells[0].ColumnSpan = e.Row.Cells.Count;
				// keep the first column, will delete othe columns
				for ( int i = e.Row.Cells.Count - 1; i > 0; i-- ) {
					e.Row.Cells.RemoveAt( i );
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			GridView1.DataSource = Factory.ConstantProvider.Gets();
			GridView1.DataBind();
		}
	}
}