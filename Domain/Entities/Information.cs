using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Information
    {
        [Key]
        public int InformationID { get; set; }

        //[Required]
        public string? InformationTitle { get; set; }

        public string? Image { get; set; }

        public int Status { get; set; }

        public DateTime InformationCreateDate { get; set; }

        //Khóa ngoại

        [ForeignKey("User")]
        public int? UserID { get; set; }
        public virtual User? User { get; set; }


        [ForeignKey("Aution")]
        public int? AutionID { get; set; }
        public virtual Aution? Aution { get; set; }


        [ForeignKey("OrchidProduct")]
        public int? OrchidID { get; set; }
        public virtual OrchidProduct? OrchidProduct { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }
}
