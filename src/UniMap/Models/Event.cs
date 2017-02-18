using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniMap.Models
{
    public class Event
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public DateTime StartOn { get; set; }

        public DateTime EndOn { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
