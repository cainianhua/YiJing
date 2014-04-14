﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace YiJingWebUI.BaseClasses
{
	public class PageBase : System.Web.UI.Page
	{
		/// <summary>
		/// 背景颜色
		/// </summary>
		protected string BgColor {
			set {
				Literal ltrBgColor = ( Literal )this.Master.FindControl( "BgColor" );
				if ( ltrBgColor != null ) {
					ltrBgColor.Text = String.Format( "#{0}", value );
				}
			}
		}
		/// <summary>
		/// 背景图片
		/// </summary>
		protected string BgImage {
			set {
				Literal ltrBgImage = ( Literal )this.Master.FindControl( "BgImage" );
				if ( ltrBgImage != null ) {
					ltrBgImage.Text = String.Format( "url({0})", value );
				}
			}
		}
		private int _PageSize;
		protected int PageSize {
			get {
				if ( _PageSize == 0 )
					return int.Parse( System.Configuration.ConfigurationManager.AppSettings["PageSize"] );

				return _PageSize;
			}
			set { _PageSize = value; }
		}

		protected int CurrPageIndex {
			get;
			set;
		}
	}
}