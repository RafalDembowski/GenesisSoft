using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Structure : Entity
    {
        public string Name { get; set; }
        public ICollection<User> Admins { get; set; }
        public ICollection<User> Managers { get; set; }
        public ICollection<User> Employees { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
