using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YiJingWebUI.BaseClasses.Admin
{
	public class ControlBase : System.Web.UI.UserControl
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );

			if ( Session["SignInToken"] == null ) {
				Response.Redirect( "/Admin/Login.aspx", true );
			}
		}
	}
}