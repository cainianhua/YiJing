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
	public partial class Add : YiJingWebUI.BaseClasses.Admin.PageBase
	{
		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
			base.BoxTitle = "添加联系方式";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			int constantId = CodeStudio.WebRequest.GetQueryInt( "cid", 0 );
			if ( !this.IsPostBack ) {
				Constant item = new Constant();
				if ( constantId > 0 ) {
					item = Factory.ConstantProvider.Get( constantId );
					base.BoxTitle = "编辑联系方式";
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
					item.TextValue = String.Format( "{0}|{1}", Pic.Text.Trim(), TextValue.Text.Trim() );
					item.Description = Description.Text.Trim();
					item.Type = ( ConstantType )( int.Parse( ConstantType.Value ) );
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

			if ( string.IsNullOrEmpty( item.Code ) )
				item.Code = "ContactUs";

			ConstantId.Value = item.ConstantId.ToString();
			Code.Value = item.Code;

			Seq.Value = item.Seq.ToString();

			if ( !string.IsNullOrEmpty( item.TextValue ) ) {
				string[] arrValues = item.TextValue.Split( '|' );
				if ( arrValues.Length == 2 ) {
					TextValue.Text = arrValues[1];
					if ( !string.IsNullOrEmpty( arrValues[0] ) ) {
						Pic.Text = arrValues[0];
						imgPic.ImageUrl = arrValues[0];
					}
				}
			}
			ConstantType.Value = ((int)item.Type).ToString();
			Description.Text = item.Description;
			SortOrder.Text = item.SortOrder.ToString();
		}
	}
}