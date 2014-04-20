using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;
using System.Web.UI.HtmlControls;
using Wuqi.Webdiyer;

namespace YiJingWebUI.Admin.Articles
{
	public partial class Default : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		private int PageSize { get; set; }
		private int CurrPageIndex { get; set; }
		private int TotalCount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			this.BoxTitle = "文章列表";
			this.GridView1.RowDataBound += new GridViewRowEventHandler( GridView1_RowDataBound );
			this.GridView1.PreRender += new EventHandler( GridView1_PreRender );
			this.GridView1.RowDeleting += new GridViewDeleteEventHandler( GridView1_RowDeleting );
			this.GridView1.RowCommand += new GridViewCommandEventHandler( GridView1_RowCommand );
			this.GridView1.RowCreated += new GridViewRowEventHandler( GridView1_RowCreated );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			int cid = CodeStudio.WebRequest.GetQueryInt( "cid", 0 );
			string searchWords = CodeStudio.WebRequest.GetQueryString( "s" );
			this.CurrPageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 1 );

			if ( !this.IsPostBack ) {
				BindDateToDropdownList( cid.ToString() );
				txtSearchText.Text = searchWords;

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
				Article item = e.Row.DataItem as Article;
				if ( item == null ) return;

				TextBox txtTitle = ( TextBox )e.Row.FindControl( "ArticleTitle" );
				TextBox txtDescription = ( TextBox )e.Row.FindControl( "Description" );
				Literal ltrOthers = ( Literal )e.Row.FindControl( "Others" );
				
				if ( txtTitle != null ) {
					txtTitle.Text = String.Format( "{0}/{1}", item.ArticleTitleLocal, item.ArticleTitle );
				}

				if ( txtDescription != null ) {
					txtDescription.Text = item.Description;
				}
			}
			else if ( e.Row.RowType == DataControlRowType.Footer ) {
				AspNetPager AspNetPager1 = ( AspNetPager )e.Row.FindControl( "AspNetPager1" );
				if ( AspNetPager1 != null ) {
					// 分页代码
					AspNetPager1.RecordCount = this.TotalCount;
					AspNetPager1.PageSize = this.PageSize;
					AspNetPager1.CurrentPageIndex = this.CurrPageIndex;
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
		protected void btnSearch_OnClick( object sender, EventArgs e ) {
			BindDataToWebUI();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="searchText"></param>
		private void BindDataToWebUI() {
			int categoryId = int.Parse( drpCategories.SelectedValue );
			string searchWords = txtSearchText.Text.Trim();
			this.PageSize = 5;
			Pager<Article> articlePager = Factory.ArticleProvider.Gets( this.CurrPageIndex, this.PageSize, searchWords, categoryId );
			this.TotalCount = articlePager.Total;

			GridView1.DataSource = articlePager.DataItems;
			GridView1.DataBind();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="selectedValue"></param>
		private void BindDateToDropdownList( string selectedValue ) {
			drpCategories.DataSource = Factory.CategoryProvider.Gets().Where( item => item.AllowToAddSubCategory == false );
			drpCategories.DataTextField = "NameLocal";
			drpCategories.DataValueField = "CategoryId";
			drpCategories.DataBind();

			drpCategories.Items.Insert( 0, new ListItem( "全部", "0" ) );

			drpCategories.ClearSelection();
			drpCategories.SelectedIndex = drpCategories.Items.IndexOf( drpCategories.Items.FindByValue( selectedValue ) );
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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GridView1_RowCommand( object sender, GridViewCommandEventArgs e ) {
			switch ( e.CommandName ) {
				case "BatchDelete":
					foreach ( GridViewRow item in GridView1.Rows ) {
						if ( item.RowType == DataControlRowType.DataRow ) {
							CheckBox cbCheck = ( CheckBox )item.Cells[0].FindControl( "cbArticleItem" );
							if ( cbCheck != null && cbCheck.Checked) { 
								int ID = int.Parse(this.GridView1.DataKeys[item.RowIndex].Value.ToString());
								try {
									Factory.ArticleProvider.Delete( ID );
								}
								catch ( Exception ) { }
							}
						}
					}

					BindDataToWebUI();
					break;
			}
		}
	}
}