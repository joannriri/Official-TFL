using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFabricsLab.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        [Precision(16, 2)]
        public decimal OrderTotal { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string DeliveryMethod { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string PaymentMethod { get; set; }
        public string BankSelect { get; set; }

        [Precision(16, 2)]
        public decimal ShippingFee { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        
    }
}
//[Required]
//        public int UserID { get; set; }
//        [ForeignKey("UserID")]
//        public virtual User User { get; set; }


//[Key]
        //public int OrderID { get; set; }
        //public DateTime OrderDate { get; set; }
        //[Precision(16,2)]
        //public decimal OrderTotal { get; set; }
        //[Required]
        //[ScaffoldColumn(false)]
        //public int OrderDetailID { get; set; }
        //[ForeignKey("OrderDetailsID")]
        //public virtual OrderDetails OrderDetails { get; set; }