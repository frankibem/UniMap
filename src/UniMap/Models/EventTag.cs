using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniMap.Models
{
    public class EventTag
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int TagID { get; set; }

        public virtual Event Event { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
