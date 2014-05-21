using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Text;
using YiJingWebUI.UserControls;
using System.IO;
using YiJingWebUI.BaseClasses;

namespace YiJingWebUI.Api
{
	/// <summary>
	/// Summary description for ArticleDetail
	/// </summary>
	public class ArticleDetail : IHttpHandler
	{
		private JavaScriptSerializer serializer = new JavaScriptSerializer();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		public void ProcessRequest( HttpContext context ) {
			string output = serializer.Serialize( new { code = -1, message = "unknown error" } );

			int pageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 0 );
			int cid = CodeStudio.WebRequest.GetQueryInt( "cid", 0 );

			if ( pageIndex <= 0 || cid <= 0 ) {
				output = serializer.Serialize( new { code = -1, message = "invalid parameters" } );
			}
			else {
				List<Article> items = Factory.ArticleProvider.Gets( pageIndex, 1, "", cid ).DataItems;
				if ( items.Count > 0 ) {
					Article item = items.Single();
					
					output = serializer.Serialize( new {
						code = 1,
						message = "success",
						//dataItem = new { aid = item.ArticleId, title = item.ArticleTitleLocal, subtitle = item.ArticleSubtitle, remarks = item.Remarks, tags = item.Tags, content = item.HtmlContent, bgcolor = item.BgColor, bgpic = item.BgPic, titlecolor = item.TitleColor, createddate = item.CreatedDate.ToString( "yyyy-MM-dd" ) }
						dataItem = new { aid = item.ArticleId, title = item.ArticleTitleLocal, keywords = item.Keywords, description = item.Description, bgcolor = item.BgColor, bgpic = item.BgPic, articleHtml = GetControlOutput(context, item) }
					} );
				}
			}
			context.Response.ContentType = "application/json";
			context.Response.Write( output );
		}

		public bool IsReusable {
			get {
				return false;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		private string GetControlOutput(HttpContext context, Article currArticle) {
			Page page = new Page();

			if(currArticle == null) return "";

			SiteSort sort = (SiteSort)currArticle.CategoryId;

			ArticleControlBase c = null;
			switch ( sort ) { 
				case SiteSort.AboutUs:
				case SiteSort.Services:
					c = ( AboutDetail )page.LoadControl( "~/UserControls/AboutDetail.ascx" );
					break;
				case SiteSort.Cases:
					c = ( CaseDetail )page.LoadControl( "~/UserControls/CaseDetail.ascx" );
					break;
				case SiteSort.News:
					c = ( NewsDetail )page.LoadControl( "~/UserControls/NewsDetail.ascx" );
					break;
			}

			if ( c == null ) return "";

			c.DataSource = currArticle;

			page.Controls.Add( c );

			StringBuilder sb = new StringBuilder();
			using ( StringWriter sw = new StringWriter( sb ) ) {
				using ( HtmlTextWriter textwriter = new HtmlTextWriter( sw ) ) {
					context.Server.Execute( page, textwriter, false );
					return sb.ToString();
				}
			}
		}
	}
}