using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeStudio.YiJing.Entities;

namespace YiJingWebUI.UserControls
{
	public partial class ArticleMetas : YiJingWebUI.BaseClasses.ControlBase
	{
		/// <summary>
		/// 
		/// </summary>
		public Article DataSource { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad( EventArgs e ) {
			base.OnLoad( e );
			if ( !this.IsPostBack ) {
				if ( DataSource != null ) {
					BindDataToWebUI();
				}
			}
		}

		private void BindDataToWebUI() { 
			

		}

		protected string Keywords {
			get {
				return DataSource == null ? "" : DataSource.Keywords;
			}
		}
		protected string Description {
			get {
				return DataSource == null ? "" : DataSource.Description;
			}
		}
	}
}