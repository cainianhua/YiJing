using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.Data
{
    interface ICategoryProvider
    {
		/// <summary>
		/// 根据主键获取Category对象
		/// </summary>
		/// <param name="categoryId"></param>
		/// <returns></returns>
		Category Get(int categoryId);
		/// <summary>
		/// 获取指定Category的所有下一级Category对象
		/// </summary>
		/// <param name="parentId">父级分类编号，获取顶层Category，请传递值为－1</param>
		/// <returns></returns>
		List<Category> Gets(int parentId);
		/// <summary>
		/// 获取全部的Category对象
		/// </summary>
		/// <returns></returns>
		List<Category> Gets();
		/// <summary>
		/// 保存或者更新Category对象
		/// </summary>
		/// <param name="c"></param>
		/// <returns>返回自增长的分类编号</returns>
		int SaveOrUpdate(Category c);
		/// <summary>
		/// 删除指定的Category对象
		/// </summary>
		/// <param name="categoryId"></param>
		/// <returns></returns>
		int Delete(int categoryId);
    }
}
