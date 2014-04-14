using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using YiJingWebUI.Admin.UserControls;
using CodeStudio.YiJing;

namespace YiJingWebUI.BaseClasses.Admin
{
	public class PageBase : System.Web.UI.Page
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );

			if ( Session["SignInToken"] == null ) {
				Response.Redirect( "/Admin/Login.aspx", true );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		protected string BoxTitle {
			set {
				Literal boxTitle = ( Literal )this.Master.FindControl( "BoxTitle" );
				if ( boxTitle != null ) {
					boxTitle.Text = value;
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		protected MessageTips CreateMessage( string text, OperationStatus status ) {
			MessageTips tips = ( MessageTips )LoadControl( "~/Admin/UserControls/MessageTips.ascx" );
			tips.ID = "MessageContent";
			tips.Text = text;
			tips.Status = OperationStatus.error;

			return tips;
		}
	}
}