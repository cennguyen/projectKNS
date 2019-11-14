using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PageAdmin.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Value name is empty, Please check again.")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Standard Price")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [StringLength(10,ErrorMessage ="Price must be smaller 1.000.000.000 VND")]
        public double StandardPrice { get; set; }
        [DisplayName("Unity Type")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [StringLength(10, ErrorMessage = "Price must be smaller 1.000.000.000 VND")]
        public int UnityType { get; set; }
        [DisplayName("On Hand")]
        public int OnHand { get; set; }
        public string Ordered { get; set; }
        public bool BackOrdered { get; set; }
    }
}
