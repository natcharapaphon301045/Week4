using System.ComponentModel.DataAnnotations;

namespace Week4.Domain
{
    public class Professor
    {
        public int ProfessorID { get; set;}

        [StringLength(100)]
        public required string ProfessorName { get; set;}
        
        [StringLength(100)]
        public required string ProfessorSurname { get; set;}

        public ICollection<Student>? Student { get; set; }
    }
}
