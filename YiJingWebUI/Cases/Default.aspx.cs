using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.Cases
{
	public partial class Default : YiJingWebUI.BaseClasses.PageBase
	{
		private int CurrentCategoryId;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			
			this.rptCategories.ItemDataBound += new RepeaterItemEventHandler( rptCategories_ItemDataBound );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			this.CurrPageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 1 );
			this.CurrentCategoryId = CodeStudio.WebRequest.GetQueryInt( "cid", ( int )SiteSort.Case );
			if ( !this.IsPostBack ) {
				BindDataToWebUI();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		protected void BindDataToWebUI() {
			// 绑定分类
			Category rootCat = Factory.CategoryProvider.Get( ( int )SiteSort.Case );
			List<Category> cats = Factory.CategoryProvider.Gets( ( int )SiteSort.Case );
			if ( rootCat != null ) {
				this.Page.Title = rootCat.NameLocal;
				rootCat.NameLocal = "全部";
				cats.Insert( 0, rootCat );
			}

			rptCategories.DataSource = cats;
			rptCategories.DataBind();
			// 绑定文章
			Pager<Article> pagedArticles = Factory.ArticleProvider.Gets( this.CurrPageIndex, this.PageSize, string.Empty, CurrentCategoryId );
			rptArticles.DataSource = pagedArticles.DataItems;
			rptArticles.DataBind();
			// 分页代码
			AspNetPager1.RecordCount = pagedArticles.Total;
			AspNetPager1.PageSize = this.PageSize;
			AspNetPager1.CurrentPageIndex = this.CurrPageIndex;
			//// 设置背景
			//foreach ( Category item in cats ) {
			//    if ( item.CategoryId == CurrentCategoryId ) {
			//        base.BgColor = item.BgColor;
			//        if ( !string.IsNullOrEmpty( item.BgPic ) ) {
			//            base.BgImage = item.BgPic;
			//        }
			//        break;
			//    }
			//}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptCategories_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.AlternatingItem
				|| e.Item.ItemType == ListItemType.Item ) {
				Category item = ( Category )e.Item.DataItem;
				if ( item == null ) return;

				HyperLink lnkCategory = ( HyperLink )e.Item.FindControl( "lnkCategory" );
				if ( lnkCategory != null ) {
					lnkCategory.Text = item.NameLocal;
					lnkCategory.NavigateUrl = String.Format( "/cases/?cid={0}", item.CategoryId );
					if ( item.CategoryId == ( int )SiteSort.Case ) {
						lnkCategory.NavigateUrl = String.Format( "/cases/" );
					}

					if ( item.CategoryId == CurrentCategoryId ) {
						lnkCategory.CssClass = "selected";
						base.BgColor = item.BgColor;
						if ( !string.IsNullOrEmpty( item.BgPic ) ) {
							base.BgImage = item.BgPic;
						}
						if ( item.NameLocal != "全部" ) {
							this.Page.Title = item.NameLocal;
						}
					}
				}
			}
		}
	}
}