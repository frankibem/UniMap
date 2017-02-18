using System;
using System.Collections.Generic;

namespace UniMap.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime EndOn { get; set; }

        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}