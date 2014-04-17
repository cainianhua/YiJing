using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio.YiJing.Entities
{
    public class Constant : Entity
    {
		public int ConstantId { get; set; }
		public String Code { get; set; }
		public int Seq { get; set; }
		public String TextValue { get; set; }
		public String Description { get; set; }
		public ConstantType Type { get; set; }
		private int _SortOrder = 9999;
		public int SortOrder {
			get { return _SortOrder; }
			set { _SortOrder = value; }
		}
    }
}
