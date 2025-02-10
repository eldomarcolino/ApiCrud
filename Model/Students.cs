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
        public decimal Balance { get; set; }

        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }

        //Chave estrangeira para o curso
        public int CursoId { get; set; }
        //Propriedade de naveçaão para o curso do aluno
        [JsonIgnore]
        [ForeignKey("CursoId")]
        public virtual Curso Curso { get; set; }
    }
}
