using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.Admin.Managers
{
	public partial class Create : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			this.BoxTitle = "新建账号";
		}

		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			int managerId = CodeStudio.WebRequest.GetQueryInt( "mid", 0 );

			if ( !this.IsPostBack ) {
				Manager fa = new Manager();
				if ( managerId > 0 ) {
					fa = Factory.ManagerProvider.Get( managerId );
					BoxTitle = "修改账号";
				}

				BindDateToWebUI( fa );
			}
		}

		protected void btnSave_Click( object sender, EventArgs e ) {
			if ( Page.IsValid ) {
				Manager fa = new Manager();
				try {
					fa.ManagerId = int.Parse( ManagerId.Value );
					fa.Name = Name.Text.Trim();
					fa.NickName = NickName.Text.Trim();
					fa.Pwd = CodeStudio.StringUtils.MD5( Pwd.Text.Trim() );

					fa.ManagerId = Factory.ManagerProvider.SaveOrUpdate( fa );
					if ( fa.ManagerId > 0 ) {
						Response.Redirect( "Default.aspx", true );
					}
				}
				catch ( Exception ex ) {
					MessageContainer.Controls.Add(
						CreateMessage( "保存出错了，错误是：" + ex.Message, OperationStatus.error )
					);
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		private void BindDateToWebUI( Manager item ) {
			ManagerId.Value = item.ManagerId.ToString();
			Name.Text = item.Name;
			NickName.Text = item.NickName;
		}
	}
}