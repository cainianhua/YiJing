using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;
using System.Web.Script.Serialization;

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
					//Article item = items.Single();
				output = serializer.Serialize( new {
					code = 1,
					message = "success",
					//items = new { aid = item.ArticleId, title = item.ArticleTitleLocal, subtitle = item.ArticleSubtitle, remarks = item.Remarks, tags = item.Tags, content = item.HtmlContent, createddate = item.CreatedDate.ToString("yyyy-MM-dd") } } );
					items = from item in items
							select new { aid = item.ArticleId, title = item.ArticleTitleLocal, subtitle = item.ArticleSubtitle, remarks = item.Remarks, tags = item.Tags, content = item.HtmlContent, createddate = item.CreatedDate.ToString( "yyyy-MM-dd" ) }
				} );
			}
			context.Response.ContentType = "application/json";
			context.Response.Write( output );
		}

		public bool IsReusable {
			get {
				return false;
			}
		}
	}
}