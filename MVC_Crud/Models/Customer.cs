using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Crud.Models
{
    public class Customers
    {
        public int custId { get; set; }
        public string custName { get; set; }
        public string city { get; set; }
        public int creditBal { get; set; }
        public string panNo { get; set; }
    }
}
