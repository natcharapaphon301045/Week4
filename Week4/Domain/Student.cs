using System.ComponentModel.DataAnnotations;

namespace Week4.Domain
{
    public class Student
    {
        public int StudentID { get; set; }

        [StringLength(100)]
        public required string StudentName { get; set; }

        [StringLength(100)]
        public required string StudentSurname { get; set; }

        public int ProfessorID { get; set; }
        public required Professor Professor { get; set; }

        public int MajorID { get; set; }
        public required Major Major { get; set; } 
    }
}
