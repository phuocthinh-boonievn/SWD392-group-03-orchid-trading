using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public string? OrderName { get; set; }

        public DateTime OrderDate { get; set; }

        public int Status { get; set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float Total { get; set; }

        //Khóa ngoại    
        [ForeignKey("User")]
        public int? UserID { get; set; }
        public virtual User? User { get; set; } 

        [ForeignKey("Aution")]
        public int? AutionID { get; set; }
        public virtual Aution? Aution { get; set; }
    }
}
