using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaDeRecarga.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }


        [JsonIgnore]
        [MaxLength(255)]
        public string Password { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [StringLength(20)]
        public string RegistrationNumber { get; set; }

        public string Role { get; set; }
        public DateTime Createdate { get; set; }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string Role { get; set; }
        public DateTime Createdate { get; set; }
    }
}
