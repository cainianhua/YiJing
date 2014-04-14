using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;
using CodeStudio.YiJing;

namespace YiJingWebUI.UserControls
{
	public partial class Footer : System.Web.UI.UserControl
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );

			if ( !this.IsPostBack ) {
				BindDataToWebUI();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void BindDataToWebUI() {
			// 公司宣言
			List<Constant> constants = Factory.ConstantProvider.Gets( "CutureWords" );
			if ( constants.Count > 0 ) {
				bottomWords.Text = constants.SingleOrDefault().TextValue;
			}
			// 联系方式
			rptContactUs.DataSource = Factory.ConstantProvider.Gets( "ContactUs" );
			rptContactUs.DataBind();
			// 底部LOGO
			constants = Factory.ConstantProvider.Gets( "LogoBottom" );
			if ( constants.Count > 0 ) {
				BottomLogo.ImageUrl = constants.SingleOrDefault().TextValue;
			}
			// Mirror...
			constants = Factory.ConstantProvider.Gets( "MirrorPic" );
			if ( constants.Count > 0 ) {
				MirrorPic.ImageUrl = constants.SingleOrDefault().TextValue;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptContactUs_ItemDataBound( object sender, RepeaterItemEventArgs e ) {
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) {
				Constant item = ( Constant )e.Item.DataItem;
				if ( item == null ) return;

				string[] textValues = item.TextValue.Split( '|' );
				if ( textValues.Length < 2 ) return;

				Image iconValue = ( Image )e.Item.FindControl( "iconValue" );
				Literal itemValue = ( Literal )e.Item.FindControl( "itemValue" );
				if ( iconValue != null ) {
					iconValue.ImageUrl = textValues[0];
				}

				if ( itemValue != null ) {
					itemValue.Text = textValues[1];
				}
			}
		}
	}
}