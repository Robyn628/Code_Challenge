using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Code_Challenge.Models
{
    public class UserModel //url = /user/create
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please Enter Username...")]
        [Display(Name = "UserName")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public UserModel()
        {
            UserId = 0;
            Username = "";
            Password = "";
        }

        public UserModel(int userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }
    }
}
