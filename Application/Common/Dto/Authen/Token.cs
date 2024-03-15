namespace Application.Common.Dto.Authen
{
    public class Token
    {
        public int UserId { get; set; }
        public string UserToken { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
