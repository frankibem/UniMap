using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniMap.Models
{
    public class EventTag
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int TagID { get; set; }

        [Required]
        public Event Event { get; set; }

        [Required]
        public Tag Tag { get; set; }
    }
}