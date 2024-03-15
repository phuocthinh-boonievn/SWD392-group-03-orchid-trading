using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Aution
    {
        [Key]
        public int AutionID { get; set; }

        public string? AutionTitle { get; set; }

        public string? AutionDescription { get; set; }

        public float StartingBid { get; set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float MaxBid { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime DateClosed { get; set; }

        public int Status { get; set; }

        public virtual ICollection<RegisterAuction>? RegisterAuctions { get; set; }
    }
}
