using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Data;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.BO
{
	public class ConstantBO : BaseBO
	{
		private IConstantProvider provider;
		/// <summary>
		/// 构造方法
		/// </summary>
		public ConstantBO() {
			provider = (IConstantProvider)base.CreateProvider("Constant");
		}
		/// <summary>
		/// 根据主键获取Constant对象
		/// </summary>
		/// <param name="constantId"></param>
		/// <returns></returns>
		public Constant Get(int constantId) {
			if (constantId <= 0)
				return null;

			return provider.Get(constantId);
		}
		/// <summary>
		/// 根据Code获取Constant对象
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public List<Constant> Gets(string code) {
			if (string.IsNullOrEmpty(code)) {
				return new List<Constant>();
			}

			return provider.Gets(code);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<Constant> Gets() {
			return provider.Gets();
		}
		/// <summary>
		/// 保存或者更新Constant对象
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int SaveOrUpdate(Constant item) {
			if (item == null)
				return -1;

			return provider.SaveOrUpdate(item);
		}
		/// <summary>
		/// 删除一个Constant对象，返回删除的数据行数
		/// </summary>
		/// <param name="constantId"></param>
		/// <returns></returns>
		public int Delete(int constantId) {
			if (constantId <= 0)
				return -1;

			return provider.Delete(constantId);
		}
	}
}
