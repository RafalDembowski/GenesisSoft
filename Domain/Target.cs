using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Target : Entity
    {
        public string Name { get; set; }
        public float Daily { get; set; }
        public float Weekly { get; set; }
        public float Monthly { get; set; }
        public float Quarterly { get; set; }
        public float SixMonth { get; set; }
        public float Annual { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
        public DateTime EndedDate { get; set; }
    }
}
