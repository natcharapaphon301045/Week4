using System.ComponentModel.DataAnnotations;
using Week4.Domain;

namespace Week4.Domain
{
    public class Class
    {
        public int ClassID {get; set;}

        [StringLength(100)]
        public required string ClassName { get; set; }
        public int ProfessorID { get; set; }
        public required Professor Professor { get; set; }

        public ICollection<StudentClass>? StudentClasses { get; set; }
    }
}
