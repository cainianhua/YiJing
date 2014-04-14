using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio.YiJing.Entities
{
	public class Manager : Entity
	{
		public int ManagerId { get; set; }
		public string Name { get; set; }
		public string NickName { get; set; }
		public string Pwd { get; set; }
	}
}
