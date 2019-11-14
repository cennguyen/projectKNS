using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PageAdmin.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public int SalesPersonID { get; set; }
        public string CompanyName { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }
}
