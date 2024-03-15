using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        //khóa ngoại

        [ForeignKey("User")]
        public int? UserID { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("OrderDetail")]
        public int? OrderDetailID { get; set; }
        public virtual OrderDetail? OrderDetail { get; set; }
    }
}
