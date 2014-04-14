using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YiJingWebUI.MasterPages
{
	public partial class Site : YiJingWebUI.BaseClasses.MasterPageBase
	{
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			if ( !this.IsPostBack ) { 
				
			}
		}
	}
}