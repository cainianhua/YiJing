using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio.YiJing
{
	public enum ConstantType
	{
		NotSet,
		/// <summary>
		/// 普通文字信息
		/// </summary>
		Text,
		/// <summary>
		/// 图片信息
		/// </summary>
		Image,
		/// <summary>
		/// 序列，像联系方式
		/// </summary>
		Sequence
	}
}
