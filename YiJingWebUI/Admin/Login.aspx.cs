using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;
using CodeStudio;

namespace YiJingWebUI.Admin
{
	public partial class Login : System.Web.UI.Page
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SignIn_OnClick( object sender, EventArgs e ) {
			if ( Page.IsValid ) {
				if ( Authenticate( Name.Text.Trim(), Password.Text.Trim() ) ) {
					Response.Redirect( "/Admin/", true );
				}
				else {
					errorMessage.Text = "登录名或者密码错误，请重新输入";
					pnMessage.Visible = true;
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		private bool Authenticate(string name, string password) {
			if ( !string.IsNullOrEmpty( name ) && !string.IsNullOrEmpty( password ) ) {
				Manager item = Factory.ManagerProvider.Get( name );
				if ( item != null && item.Pwd == password.MD5() ) {
					Session["SignInToken"] = item.NickName;
					return true;
				}
			}

			return false;
		}
	}
}