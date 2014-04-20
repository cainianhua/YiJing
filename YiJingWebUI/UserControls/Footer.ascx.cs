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
		protected string ContactUsBackgroundBottomString { get; set; }
		/// <summary>
		/// 
		/// </summary>
		protected string ContactUsBackgroundTopString { get; set; }
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
			List<Constant> allConstants = Factory.ConstantProvider.Gets();
			List<Constant> constants = new List<Constant>();
			// 公司宣言
			constants = allConstants.Where( item => item.Code == "CutureWords" ).ToList();
			if ( constants.Count > 0 ) {
				bottomWords.Text = constants.SingleOrDefault().TextValue;
			}
			// 联系方式
			rptContactUs.DataSource = allConstants.Where( item => item.Code == "ContactUs" ); 
			rptContactUs.DataBind();
			// 底部LOGO
			constants = allConstants.Where( item => item.Code == "LogoBottom" ).ToList();
			if ( constants.Count > 0 ) {
				BottomLogo.ImageUrl = constants.SingleOrDefault().TextValue;
			}
			// Mirror...
			constants = allConstants.Where( item => item.Code == "MirrorPic" ).ToList();
			if ( constants.Count > 0 ) {
				MirrorPic.ImageUrl = constants.SingleOrDefault().TextValue;
			}
			this.ContactUsBackgroundBottomString = this.ContactUsBackgroundTopString = "style=\"background:{color} {backgroundimage} no-repeat center top;\"";
			constants = allConstants.Where( item => item.Code == "ContactUsBackgroundColor" ).ToList();
			if ( constants.Count > 0 ) {
				Constant item = constants.SingleOrDefault();
				ContactUsBackgroundBottomString = ContactUsBackgroundBottomString.Replace( "{color}", "#" + item.TextValue );
				ContactUsBackgroundTopString = ContactUsBackgroundTopString.Replace( "{color}", "#" + item.TextValue );
			}
			else {
				ContactUsBackgroundBottomString = ContactUsBackgroundBottomString.Replace( "{color}", "" );
				ContactUsBackgroundTopString = ContactUsBackgroundTopString.Replace( "{color}", "" );
			}

			// 联系我底图（下）
			constants = allConstants.Where( item => item.Code == "ContactUsBackgroundBottom" ).ToList();
			if ( constants.Count > 0 ) {
				Constant item = constants.SingleOrDefault();
				if ( !string.IsNullOrEmpty( item.TextValue ) )
					ContactUsBackgroundBottomString = ContactUsBackgroundBottomString.Replace( "{backgroundimage}", String.Format( "url({0})", item.TextValue ) );
			}
			else {
				ContactUsBackgroundBottomString = ContactUsBackgroundBottomString.Replace( "{backgroundimage}", "" );
			}
			// 联系我底图（上）
			constants = allConstants.Where( item => item.Code == "ContactUsBackgroundTop" ).ToList();
			if ( constants.Count > 0 ) {
				Constant item = constants.SingleOrDefault();
				if ( !string.IsNullOrEmpty( item.TextValue ) )
					ContactUsBackgroundTopString = ContactUsBackgroundTopString.Replace( "{backgroundimage}", String.Format( "url({0})", item.TextValue ) );
			}
			else {
				ContactUsBackgroundTopString = ContactUsBackgroundTopString.Replace( "{backgroundimage}", "" );
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