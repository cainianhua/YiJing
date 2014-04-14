using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;

namespace YiJingWebUI.Search
{
	public partial class Default : YiJingWebUI.BaseClasses.PageBase
	{
		private string SearchWords { get; set; }
		private int CurrCategoryId { get; set; }
		private Dictionary<int, int> CategoryStatistics { get; set; }

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
			this.SearchWords = CodeStudio.WebRequest.GetQueryString( "s", "" );
			this.CurrCategoryId = CodeStudio.WebRequest.GetQueryInt( "cid", 0 );
			this.CurrPageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 1 );

			if ( !this.IsPostBack ) {
				if ( string.IsNullOrEmpty( SearchWords ) )
					Response.Redirect( "/", true );

				BindDataToWebUI();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptCategories_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.AlternatingItem 
				|| e.Item.ItemType == ListItemType.Item ) 
			{
				Category item = ( Category )e.Item.DataItem;
				if ( item == null ) return;

				HyperLink lnkCategory = ( HyperLink )e.Item.FindControl( "lnkCategory" );
				if ( lnkCategory != null ) {
					lnkCategory.NavigateUrl = String.Format( "/search/?s={0}", this.SearchWords );
					if ( item.CategoryId > 0 ) {
						lnkCategory.NavigateUrl = String.Format( "/search/?s={0}&cid={1}", this.SearchWords, item.CategoryId );
						lnkCategory.Text = String.Format( "{0}({1})", item.NameLocal, (this.CategoryStatistics.Keys.Contains(item.CategoryId) ? this.CategoryStatistics[item.CategoryId] : 0) );
					}
					else {
						lnkCategory.Text = String.Format( "{0}({1})", item.NameLocal, this.TotalCount.Text );
					}
					if ( item.CategoryId == CurrCategoryId ) {
						lnkCategory.CssClass = "selected";
					}
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		private void BindDataToWebUI() {
			Pager<Article> articlePages = Factory.ArticleProvider.Gets( this.CurrPageIndex, this.PageSize, this.SearchWords, (int)SiteSort.News, (int)SiteSort.Case );
			this.CategoryStatistics = Factory.ArticleProvider.GetStatistics( this.CurrPageIndex, this.PageSize, this.SearchWords, ( int )SiteSort.News, ( int )SiteSort.Case );
			
			this.Page.Title = String.Format( "{0} - 搜索结果", this.SearchWords );
			this.SearchText.Text = this.SearchWords;
			this.TotalCount.Text = articlePages.Total.ToString();
			this.lnkKeywords.Text = this.SearchWords;
			this.lnkKeywords.NavigateUrl = String.Format( "/search/?s={0}", this.SearchWords );

			if ( articlePages.DataItems.Count == 0 ) {
				phEmpty.Visible = true;
			}

			this.AspNetPager1.RecordCount = articlePages.Total;
			this.AspNetPager1.PageSize = this.PageSize;
			this.AspNetPager1.CurrentPageIndex = this.CurrPageIndex;



			List<Category> lstCategories = Factory.CategoryProvider.Gets( -1 ).Where(item => item.AllowToAddSubCategory).ToList();
			lstCategories.Insert( 0, new Category() { NameLocal = "全部" } );
			rptCategories.DataSource = lstCategories;
			rptCategories.DataBind();

			rptResults.DataSource = articlePages.DataItems;
			rptResults.DataBind();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="keywords"></param>
		/// <returns></returns>
		protected string GenerateKeywordsLink( string keywords ) {
			if ( !string.IsNullOrEmpty( keywords ) ) {
				string[] words = keywords.Split( new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
				StringBuilder builder = new StringBuilder( words.Length );
				for ( int i = words.Length - 1; i > 0; i-- ) {
					builder.AppendFormat( "<a href=\"/search/?s={0}\">{0}</a>", words[i] );
				}
				builder.AppendFormat( "<a href=\"/search/?s={0}\">{0}</a>/", words[0] );

				return builder.ToString();
			}
			return "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="parentId"></param>
		/// <param name="articleId"></param>
		/// <returns></returns>
		protected string GenerateArticleLink( int parentId, int articleId ) {
			string returnVal = "";

			switch ( ( SiteSort )parentId ) { 
				case SiteSort.Case:
					returnVal = String.Format( "/cases/detail.aspx?aid={0}", articleId );
					break;
				case SiteSort.News:
					returnVal = String.Format( "/news/detail.aspx?aid={0}", articleId );
					break;
			}

			return returnVal;
		}
	}
}