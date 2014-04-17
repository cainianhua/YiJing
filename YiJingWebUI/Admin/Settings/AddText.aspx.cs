using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;

namespace YiJingWebUI.Admin.Settings
{
	public partial class EditWords : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			base.BoxTitle = "编辑底部文字";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			int constantId = CodeStudio.WebRequest.GetQueryInt( "cid", 0 );
			string code = CodeStudio.WebRequest.GetQueryString( "code" );

			if ( !this.IsPostBack ) {
				if ( constantId <= 0 && string.IsNullOrEmpty( code ) ) {
					Response.Redirect( "Default.aspx", true );
				}

				Constant item = new Constant();
				if ( constantId > 0 ) {
					item = Factory.ConstantProvider.Get( constantId );
				}
				if ( !string.IsNullOrEmpty( code ) ) {
					List<Constant> items = Factory.ConstantProvider.Gets( code );
					if ( items.Count > 0 )
						item = items.SingleOrDefault();
				}

				BindDataToWebUI( item );
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSave_Click( object sender, EventArgs e ) {
			if ( Page.IsValid ) {
				Constant item = new Constant();
				try {
					item.ConstantId = int.Parse( ConstantId.Value );
					item.Code = Code.Value;
					item.Seq = int.Parse( Seq.Value );
					item.TextValue = TextValue.Text.Trim();
					item.Description = Description.Text.Trim();
					item.SortOrder = int.Parse( SortOrder.Text );
					item.ActionDate = DateTime.Now;
					item.ActionBy = User.Identity.Name;

					item.ConstantId = Factory.ConstantProvider.SaveOrUpdate( item );
					if ( item.ConstantId > 0 ) {
						Response.Redirect( "Default.aspx", true );
					}
				}
				catch ( Exception ex ) {
					MessageContainer.Controls.Add(
						base.CreateMessage( "保存出错了，错误是：" + ex.Message, OperationStatus.error )
					);
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		private void BindDataToWebUI( Constant item ) {
			if ( item == null ) return;

			ConstantId.Value = item.ConstantId.ToString();
			Code.Value = item.Code;
			Seq.Value = item.Seq.ToString();
			TextValue.Text = item.TextValue;
			Description.Text = item.Description;
			SortOrder.Text = item.SortOrder.ToString();
		}
	}
}