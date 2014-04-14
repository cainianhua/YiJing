using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YiJingWebUI.UserControls
{
	public partial class SlideShow : YiJingWebUI.BaseClasses.ControlBase
	{
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			if ( !this.IsPostBack ) {
				BindDataToWebUI();
			}
		}

		private void BindDataToWebUI() {
			Repeater1.DataSource = CodeStudio.YiJing.Factory.FocuseArticleProvider.Gets();
			Repeater1.DataBind();
		}
	}
}