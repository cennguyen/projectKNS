using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PageAdmin.Models
{
    [Table("SalesPerson")]
    public class SalesPerson
    {
        [Key]
        public int SalesPersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not a valid phone number \n Ex : 1234567899 ,do not add '0' ")]
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public bool Active { get; set; }
    }
}
