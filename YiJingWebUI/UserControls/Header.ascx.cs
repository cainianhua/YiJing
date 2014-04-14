using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;

namespace YiJingWebUI.UserControls
{
	public partial class Header : YiJingWebUI.BaseClasses.ControlBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			if ( !this.IsPostBack ) {
				BindDataToWebUI();
			}
		}
		/// <summary>
		/// 一级分类数据绑定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptNavigator_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem ) {
				Category item = ( Category )e.Item.DataItem;
				if ( item == null ) return;
				// 名称
				Literal ltrName = ( Literal )e.Item.FindControl( "Name" );
				Literal ltrNameLocal = ( Literal )e.Item.FindControl( "NameLocal" );
				if ( ltrName != null )
					ltrName.Text = item.Name;

				if ( ltrNameLocal != null )
					ltrNameLocal.Text = item.NameLocal;

				Panel pnlSubnav = ( Panel )e.Item.FindControl( "pnlSubnav" );
				if ( pnlSubnav != null ) {
					if ( item.CategoryId == (int)SiteSort.HomePage || item.CategoryId == (int)SiteSort.ContactUs )
						pnlSubnav.Visible = false;
				}

				#region [ 一级分类链接 ]
				HyperLink lnkNavigator = ( HyperLink )e.Item.FindControl( "lnkNavigator" );
				if ( lnkNavigator != null ) {
					lnkNavigator.Text = item.NameLocal;
					switch ( (SiteSort)(item.CategoryId) ) { 
						case SiteSort.HomePage:
							lnkNavigator.NavigateUrl = "/";
							break;
						case SiteSort.AboutUs:
						case SiteSort.Services:
						case SiteSort.ContactUs:
							lnkNavigator.NavigateUrl = "javascript:void(0);";
							lnkNavigator.Attributes.Add( "rel", ((SiteSort)item.CategoryId).ToString().ToLower() );
							break;
						case SiteSort.News:
							lnkNavigator.NavigateUrl = "/news/";
							break;
						case SiteSort.Case:
							lnkNavigator.NavigateUrl = "/cases/";
							break;
					}
				}
				#endregion

				if ( item.AllowToAddSubCategory ) {
					// 二级分类(文章）
					Repeater rptSubNavigator = ( Repeater )e.Item.FindControl( "rptSubNavigator" );
					if ( rptSubNavigator != null && rptSubNavigator.Visible ) {
						rptSubNavigator.DataSource = Factory.CategoryProvider.Gets( item.CategoryId );
						rptSubNavigator.DataBind();
					}
				}
				else {
					Repeater rptArticles = ( Repeater )e.Item.FindControl( "rptArticles" );
					if ( rptArticles != null && rptArticles.Visible ) {
						rptArticles.DataSource = Factory.ArticleProvider.Gets( item.CategoryId );
						rptArticles.DataBind();
					}	
				}
			}
		}
		/// <summary>
		/// 二级分类数据绑定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptSubNavigator_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) {
				Category item = ( Category )e.Item.DataItem;
				if ( item == null ) return;

				HyperLink lnkSubNavigator = ( HyperLink )e.Item.FindControl( "lnkSubNavigator" );
				if ( lnkSubNavigator != null ) {
					if ( item.ParentId == (int)SiteSort.News ) {
						lnkSubNavigator.NavigateUrl = String.Format( "/news/?cid={0}", item.CategoryId );
					}
					else if ( item.ParentId == ( int )SiteSort.Case ) {
						lnkSubNavigator.NavigateUrl = String.Format( "/cases/?cid={0}", item.CategoryId );
					}
					lnkSubNavigator.Text = item.NameLocal;
				}
			}
		}
		/// <summary>
		/// 没有二级分类，直接绑定文章
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptArticles_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) {
				Article item = ( Article )e.Item.DataItem;
				if ( item == null ) return;

				HyperLink lnkArticle = ( HyperLink )e.Item.FindControl( "lnkArticle" );
				if ( lnkArticle != null ) {
					lnkArticle.Text = item.ArticleTitleLocal;
					if ( item.CategoryId == ( int )SiteSort.AboutUs ) {
						lnkArticle.NavigateUrl = String.Format( "/aboutus/?aid={0}", item.ArticleId );
					}
					else if ( item.CategoryId == ( int )SiteSort.Services ) {
						lnkArticle.NavigateUrl = String.Format( "/services/?aid={0}", item.ArticleId );
					}
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			List<Category> cats = Factory.CategoryProvider.Gets( -1 );
			rptNavigator.DataSource = cats;
			rptNavigator.DataBind();

			// 头部LOGO
			List<Constant> constants = Factory.ConstantProvider.Gets( "LogoTop" );
			if ( constants.Count > 0 ) {
				imgTopLogo.ImageUrl = constants.SingleOrDefault().TextValue;
			}
		}
	}
}