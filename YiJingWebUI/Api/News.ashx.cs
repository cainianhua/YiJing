using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.Api
{
	/// <summary>
	/// Summary description for ArticleService
	/// </summary>
	public class News : IHttpHandler
	{
		private JavaScriptSerializer serializer = new JavaScriptSerializer();

		public void ProcessRequest( HttpContext context ) {
			int pageIndex = CodeStudio.WebRequest.GetQueryInt( "pn", 0 );
			int cid = CodeStudio.WebRequest.GetQueryInt( "cid", (int)SiteSort.News );
			int pageSize = int.Parse( System.Configuration.ConfigurationManager.AppSettings["PageSize"] );

			List<Article> items = Factory.ArticleProvider.Gets( pageIndex, pageSize, "", cid ).DataItems;

			string output = serializer.Serialize( from item in items
												  select new { item.ArticleId, item.ArticleTitleLocal, item.Description, item.Thumbnail } );

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