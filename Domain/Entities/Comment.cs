using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public string? CommentMsg { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsCheckBool { get; set; }

        //khóa ngoại

        [ForeignKey("User")]
        public int? UserID { get; set; }
        public virtual User? User { get; set; }


        [ForeignKey("Information")]
        public int? InformationID { get; set; }
        public virtual Information? Information { get; set; }
    }
}
