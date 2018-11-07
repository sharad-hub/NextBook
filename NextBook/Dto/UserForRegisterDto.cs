using System.ComponentModel.DataAnnotations;

namespace NextBook.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "You must provide the password")]

        public string Password { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "You must provide the username")]
        public string Username { get; set; }
    }
}