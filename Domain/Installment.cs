using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Installment : Entity
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public float Commission { get; set; }
    }
}
