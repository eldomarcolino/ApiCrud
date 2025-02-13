using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeRecarga.Model
{
    public class Estudantes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }

        public int CursoId { get; set; }

        //[ForeignKey("CursoId")]
       // public Curso Curso { get; set; }
    }
}
