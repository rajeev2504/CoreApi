using System;
using System.Collections.Generic;

namespace Demo.Model
{
    public partial class Sales
    {
        public int? EmpId { get; set; }
        public int? SaleAmount { get; set; }
        public string City { get; set; }
        public DateTime? Salesdate { get; set; }
    }
}
