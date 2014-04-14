using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio.YiJing
{
	[Flags]
	public enum OperationStatus
	{
		attention = 1,
		information = 2,
		error = 4,
		success = 10
	}
}
