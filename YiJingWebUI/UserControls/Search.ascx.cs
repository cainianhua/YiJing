using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YiJingWebUI.UserControls
{
	public partial class Search : YiJingWebUI.BaseClasses.ControlBase
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
		protected void btnSearch_OnClick( object sender, EventArgs e ) {
			string searchText = this.SearchText.Text.Trim();
			if ( !string.IsNullOrEmpty( searchText ) )
				Response.Redirect( String.Format( "/search/?s={0}", searchText ), true );
			else
				Response.Redirect( "/", true );
		}
	}
}