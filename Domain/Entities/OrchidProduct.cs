using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class OrchidProduct
    {
        [Key]
        public int OrchidID { get; set; }

        public string? OrchidName { get; set; }

        public string? Characteristics { get; set; }

        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float UnitPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Lỗi nhập, Số lượng không được Âm")]
        public int Quantity { get; set; }

        public int Status { get; set; }

        //Khóa ngoại

    }
}
