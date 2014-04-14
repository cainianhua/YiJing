using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStudio.YiJing.Entities
{
    public class Entity
    {
        public DateTime CreatedDate { get; internal set; }
        public String CreatedBy { get; internal set; }
        public DateTime ModifiedDate { get; internal set; }
        public String ModifiedBy { get; internal set; }
        public DateTime ActionDate { get; set; }
        public String ActionBy { get; set; }
    }
}
