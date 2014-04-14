using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Data;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.BO
{
	public class CategoryBO : BaseBO
	{
		private ICategoryProvider provider;
		/// <summary>
		/// 构造方法
		/// </summary>
		public CategoryBO() {
			provider = (ICategoryProvider)base.CreateProvider("Category");
		}
		/// <summary>
		/// 根据主键获取Category对象
		/// </summary>
		/// <param name="categoryId">分类编号</param>
		/// <returns></returns>
		public Category Get(int categoryId) {
			if (categoryId <= 0)
				return null;

			return provider.Get(categoryId);
		}
		/// <summary>
		/// 获取指定Category的所有下一级Category对象
		/// </summary>
		/// <param name="parentId">父级分类编号，获取顶层Category，请传递值为－1</param>
		/// <returns></returns>
		public List<Category> Gets(int parentId) {
			if (parentId <= -2)
				return new List<Category>();

			return provider.Gets(parentId);
		}
		/// <summary>
		/// 获取所有的Category对象。
		/// </summary>
		/// <returns></returns>
		public List<Category> Gets() {
			return provider.Gets();
		}

		/// <summary>
		/// 获取指定的Category下一级允许添加子分类的Category对象
		/// </summary>
		/// <param name="parentId"></param>
		/// <returns></returns>
		public List<Category> GetsAllowedChilds( int parentId ) {
			return this.Gets( parentId ).Where( item => item.AllowToAddSubCategory ).ToList();
		}

		/// <summary>
		/// 保存或者更新Category对象
		/// </summary>
		/// <param name="item">需要保存的分类编号</param>
		/// <returns></returns>
		public int SaveOrUpdate(Category item) {
			if (item == null)
				return -1;

			return provider.SaveOrUpdate(item);
		}
		/// <summary>
		/// 删除指定的Category对象
		/// </summary>
		/// <param name="categoryId">分类编号</param>
		/// <returns></returns>
		public int Delete(int categoryId) {
			if (categoryId <= 0)
				return -1;

			return provider.Delete(categoryId);
		}
	}
}
