using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        [MaxLength(1024)]
        [Required]
        [Column(TypeName = "varbinary(1024)")]
        public byte[] PasswordHash { get; set; }

        [MaxLength(1024)]
        [Required]
        [Column(TypeName = "varbinary(1024)")]
        public byte[] PasswordSalt { get; set; }


        [Required]
        [Range(0.0, float.MaxValue, ErrorMessage = "Lỗi nhập, số tiền trong ví không Âm")]
        public float WalletBalance { get; set; }

        public string? Phone { get; set; }

        public bool Status { get; set; }

        //khóa ngoại
        [ForeignKey("Role")]
        public int? RoleID { get; set; }
        public virtual Role? Role { get; set; }


        //[JsonIgnore]
        public virtual ICollection<Information>? Informations { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }  

        public virtual ICollection<RegisterAuction>? RegisterAuctions { get; set; }      

        public virtual ICollection<Transaction>? Transactions { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }


        //JWT
        [NotMapped]
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

    }
}
