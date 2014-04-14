using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;

namespace YiJingWebUI.Admin.UserControls
{
	public partial class MessageTips : YiJingWebUI.BaseClasses.Admin.ControlBase
	{
		public OperationStatus Status { get; set; }
		public string Text { get; set; }

		protected void Page_Load( object sender, EventArgs e ) {

		}
	}
}