using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /*dodać pliki (możliwość dodania załączników?)*/
    public class Event : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EventCategory Category { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public User Owner { get; set; }
        public ICollection<User> AssignedColleague { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }
        public string Status { get; set; }
    }
}
