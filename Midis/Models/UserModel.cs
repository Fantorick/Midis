using System.ComponentModel.DataAnnotations;

namespace Midis.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(6)]
        [StringLength(100, ErrorMessage = "Длина {0} должна быть не менее {2} и не более {1} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
        public string Group { get; set; }
        public List<string> Errors { get; set; }
    }
}
