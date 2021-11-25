using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Task : Entity
    {
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}
