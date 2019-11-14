using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PageAdmin.Models
{
    [Table("Payment")]
    public class Invoice
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentType { get; set; }
        public int Amout { get; set; }
        public string Cleared { get; set; }

    }
}
