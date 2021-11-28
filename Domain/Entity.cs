using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
        public Structure Structure { get; set; }
    }
}
