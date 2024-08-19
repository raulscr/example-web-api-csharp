using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Repository.Model
{
    [Table("users")]
    public class UserLoginModel
    {
        public UserLoginModel()
        {
            Login = "";
            Password = "";
        }

        [Key]
        [Column("user_id")]
        public int UserId { get; private set; }

        [Required]
        [Column("user_name")]
        public string Login { get; set; }

        [Required]
        [Column("user_password")]
        public string Password { get; set; }
    }
}