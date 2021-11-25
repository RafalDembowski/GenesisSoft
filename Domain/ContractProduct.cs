using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ContractProduct 
    {
        public int NumberOfInstalments { get; set; }
        public ICollection<Installment> Installments { get; set; }
        public Product Product { get; set; }
    }
}
