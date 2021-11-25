using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /* czy data ubezpieczenia ,  inny ubezpieczający , współubezpieczający , cesjonariusz , współpracownik , prowizja, podzielenie prowizji i cos sie jeszcze znajdzie na asanie */
    public class Contract : Entity
    {
        public string Name { get; set; }
        public User Adviser { get; set; }
        public Company Company { get; set; }
        public ICollection<Person> Persons { get; set; }
        public bool NewSale { get; set; }
        public bool Renewal { get; set; }
        public bool Insurance { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }
        public DateTime RenewalDate { get; set; }
        public string Status { get; set; }
        public ICollection<ContractProduct> ContractProducts { get; set; }
    }
}
