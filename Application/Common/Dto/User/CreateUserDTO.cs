using System.ComponentModel.DataAnnotations;

namespace Application.Common.Dto.User
{
    public class CreateUserDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Owner { get; set; }

        [Required]
        [Range(0.0, float.MaxValue, ErrorMessage = "Lỗi nhập, số tiền trong ví không Âm")]
        public float WalletBalance { get; set; }

        public int RoleID { get; set; }
    }
}
