using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class RegisterAuction
    {
        [Key]
        public int Id { get; set; }
        public float Price { get; set; }

        public float Deposit { get; set; }

        //Khóa ngoại
        [ForeignKey("User")]
        public int? UserID { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("Aution")]
        public int? BidID { get; set; }
        public virtual Aution? Aution { get; set; }
    }
}
