using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicBuilder.Structures.Tests.Data
{
    [Table("OfficeAssignment")]
    public class OfficeAssignment
    {
        [Key]
        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string? Location { get; set; }

        
        public virtual Instructor? Instructor { get; set; }
    }
}
