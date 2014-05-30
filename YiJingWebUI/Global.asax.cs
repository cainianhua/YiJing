using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace YiJingWebUI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start( object sender, EventArgs e ) {

        }

        protected void Session_Start( object sender, EventArgs e ) {
            
        }

        protected void Application_BeginRequest( object sender, EventArgs e ) {
            if ( Request.Url.Host.IndexOf( "www" ) == -1 ) {
                Uri curr = new Uri( string.Format( "{0}://{1}{2}", Request.Url.Scheme, Request.Url.Host.Insert( 0, "www." ), Request.Url.PathAndQuery ) );

                Response.StatusCode = 301;
                Response.Status = "301 Moved Permanently";
                Response.RedirectLocation = curr.ToString();
                Response.End();
            }
        }

        protected void Application_AuthenticateRequest( object sender, EventArgs e ) {

        }

        protected void Application_Error( object sender, EventArgs e ) {

        }

        protected void Session_End( object sender, EventArgs e ) {

        }

        protected void Application_End( object sender, EventArgs e ) {

        }
    }
}