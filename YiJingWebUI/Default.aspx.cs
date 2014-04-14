using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing;
using CodeStudio.YiJing.Entities;

namespace YiJingWebUI
{
	public partial class _Default : YiJingWebUI.BaseClasses.PageBase
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
			// 背景
			Category category = Factory.CategoryProvider.Get( 1 );
			if ( category != null ) {
				base.BgColor = category.BgColor;
				if ( !string.IsNullOrEmpty( category.BgPic ) )
					base.BgImage = category.BgPic;
			}
		}
    }
}