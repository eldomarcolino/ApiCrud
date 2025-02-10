using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCrud.Model
{
    [Table("students_curso")]
    public class StudentsCurso
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }

        [Key, Column(Order = 1)]
        public int CourseId { get; set; }

        [ForeignKey("StudentId")]
        public Students Student { get; set;}

        [ForeignKey("CourseId")]
        public Curso Course { get; set;}
    }
}
