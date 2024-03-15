using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        public string? RoleName { get; set; }

        public virtual ICollection<User>? Users { get; set; }

    }
}
