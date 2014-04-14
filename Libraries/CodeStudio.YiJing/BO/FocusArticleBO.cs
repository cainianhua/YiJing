using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Data;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.BO
{
	public class FocusArticleBO : BaseBO
	{
		private IFocusArticleProvider provider;
		/// <summary>
		/// 
		/// </summary>
		public FocusArticleBO() {
			provider = (IFocusArticleProvider)base.CreateProvider("FocusArticle");
		}
		/// <summary>
		/// 根据主键获取FocusArticle对象
		/// </summary>
		/// <param name="faId"></param>
		/// <returns></returns>
		public FocusArticle Get(int faId) {
			if (faId <= 0)
				return null;

			return provider.Get(faId);
		}
		/// <summary>
		/// 获取所有的FocusArticle对象
		/// </summary>
		/// <returns></returns>
		public List<FocusArticle> Gets() {
			return provider.Gets();
		}
		/// <summary>
		/// 保存FocusArticle对象
		/// </summary>
		/// <param name="fa"></param>
		/// <returns></returns>
		public int SaveOrUpdate(FocusArticle fa) {
			if (fa == null)
				return -1;

			return provider.SaveOrUpdate(fa);
		}
		/// <summary>
		/// 根据主键删除FocusArticle对象
		/// </summary>
		/// <param name="faId"></param>
		/// <returns></returns>
		public int Delete(int faId) {
			if (faId <= 0)
				return -1;

			return provider.Delete(faId);
		}
	}
}
