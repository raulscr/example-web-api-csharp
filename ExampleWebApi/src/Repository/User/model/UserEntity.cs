using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Repository.Model
{
    [Table("users")]
    public class UserEntity
    {
        public UserEntity()
        {
            Login = "";
            Password = "";
        }

        [Key]
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; private set; }

        [Required]
        [Column("user_name")]
        [MaxLength(255)]
        public string Login { get; set; }

        [Required]
        [Column("user_password")]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}