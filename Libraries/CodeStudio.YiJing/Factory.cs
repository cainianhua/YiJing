using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.BO;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing
{
	public class Factory
	{
		private static ArticleBO articleBO;
		private static CategoryBO categoryBO;
		private static ConstantBO constantBO;
		private static FocusArticleBO faBO;
		private static ManagerBO managerBO;

		public static ArticleBO ArticleProvider {
			get {
				if ( articleBO == null ) articleBO = new ArticleBO();
				return articleBO;
			}
		}

		public static CategoryBO CategoryProvider {
			get {
				if ( categoryBO == null ) categoryBO = new CategoryBO();
				return categoryBO;
			}
		}

		public static ConstantBO ConstantProvider {
			get {
				if ( constantBO == null ) constantBO = new ConstantBO();
				return constantBO;
			}
		}

		public static FocusArticleBO FocuseArticleProvider {
			get {
				if ( faBO == null ) faBO = new FocusArticleBO();
				return faBO;
			}
		}

		public static ManagerBO ManagerProvider {
			get {
				if ( managerBO == null ) managerBO = new ManagerBO();
				return managerBO;
			}
		}
	}
}
