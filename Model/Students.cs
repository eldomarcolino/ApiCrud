using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCrud.Model
{
    [Table("Students")]
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string RegistrationNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Course { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Balance { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }

        [JsonIgnore]
        public ICollection<StudentsCurso> StudentsCursos { get; set; }
    }
}
