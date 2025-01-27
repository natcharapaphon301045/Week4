using System.ComponentModel.DataAnnotations;

namespace Week4.Domain
{
    public class Major
    {
        public int MajorID { get; set; }
        
        [StringLength(100)]
        public required String MinorName { get; set; }

        public ICollection<Student>? Student { get; set; }
    }
}
