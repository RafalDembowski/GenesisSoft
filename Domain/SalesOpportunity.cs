using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SalesOpportunity : Entity
    {
        public string Name { get; set; }
        public Contract Contract { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string SalesStage { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
