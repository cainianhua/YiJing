using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.Admin.Focuses
{
	public partial class Default : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			base.BoxTitle = "焦点图列表";

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
				FocusArticle item = e.Row.DataItem as FocusArticle;
				if ( item == null ) return;

				TextBox txtDescription = ( TextBox )e.Row.FindControl( "Description" );
				Literal ltrOthers = ( Literal )e.Row.FindControl( "Others" );

				if ( txtDescription != null ) {
					txtDescription.Text = item.Description;
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
			Factory.ArticleProvider.Delete( itemId );
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
		///// <summary>
		///// 
		///// </summary>
		///// <param name="sender"></param>
		///// <param name="e"></param>
		//protected void GridView1_RowCommand( object sender, GridViewCommandEventArgs e ) {
		//    switch ( e.CommandName ) {
		//        case "BatchDelete":
		//            foreach ( GridViewRow item in GridView1.Rows ) {
		//                if ( item.RowType == DataControlRowType.DataRow ) {
		//                    CheckBox cbCheck = ( CheckBox )item.Cells[0].FindControl( "cbArticleItem" );
		//                    if ( cbCheck != null && cbCheck.Checked ) {
		//                        int ID = int.Parse( this.GridView1.DataKeys[item.RowIndex].Value.ToString() );
		//                        try {
		//                            Factory.FocuseArticleProvider.Delete( ID );
		//                        }
		//                        catch ( Exception ) { }
		//                    }
		//                }
		//            }

		//            BindDataToWebUI();
		//            break;
		//    }
		//}
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			GridView1.DataSource = Factory.FocuseArticleProvider.Gets();
			GridView1.DataBind();
		}
	}
}