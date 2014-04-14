using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.Data
{
    interface IConstantProvider
    {
		/// <summary>
		/// 根据主键获取Constant对象
		/// </summary>
		/// <param name="constantId"></param>
		/// <returns></returns>
		Constant Get(int constantId);
		/// <summary>
		/// 根据Code获取Constant对象
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		List<Constant> Gets(string code);
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		List<Constant> Gets();
		/// <summary>
		/// 保存或者更新Constant对象
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		int SaveOrUpdate(Constant c);
		/// <summary>
		/// 删除一个Constant对象，返回删除的数据行数
		/// </summary>
		/// <param name="constantId"></param>
		/// <returns></returns>
		int Delete(int constantId);
    }
}
