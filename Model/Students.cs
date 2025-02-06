using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCrud.Model
{
    [Table("Students")]
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }
    }
}
