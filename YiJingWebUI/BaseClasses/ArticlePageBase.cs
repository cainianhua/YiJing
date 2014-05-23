using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.BaseClasses
{
	public class ArticlePageBase : PageBase
	{
		/// <summary>
		/// 控件所属分类（提前赋值）
		/// </summary>
		protected SiteSort CurrSort { get; set; }
		/// <summary>
		/// 当前文章编号
		/// </summary>
		protected int CurrArticleId { get; set; }
		/// <summary>
		/// 当前分类下的文章总数
		/// </summary>
		protected int TotalCount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected Article CurrArticle {
			get {
				Article item = null;
				if ( this.CurrPageIndex <= 0 && this.CurrArticleId <= 0 ) {
					return item;
				}

				Pager<Article> articlePagers = new Pager<Article>();
				if ( this.CurrPageIndex > 0 ) {
					articlePagers = Factory.ArticleProvider.Gets( this.CurrPageIndex, 1, "", ( int )CurrSort );
				}
				else if ( this.CurrArticleId > 0 ) {
					articlePagers = Factory.ArticleProvider.GetPagedArticle( this.CurrArticleId );
				}

				this.CurrPageIndex = articlePagers.CurrentPageIndex;
				this.TotalCount = articlePagers.Total;

				if ( articlePagers.DataItems.Count > 0 ) {
					item = articlePagers.DataItems.Single();
				}

				return item;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			
			this.CurrArticleId = CodeStudio.WebRequest.GetQueryInt( "aid", 0 );
			this.CurrPageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 0 );
			if ( !this.IsPostBack ) {
				
			}
		}
	}
}