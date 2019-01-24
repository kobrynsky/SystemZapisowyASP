using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.ViewModels.Course
{
    public class CourseViewModel
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public CourseViewModel()
       // {
            //this.Groups = new HashSet<Group>();
       // }


        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        [Display(Name = "Field of study")]
        public int FieldOfStudyId { get; set; }

        //public virtual FieldsOfStudy FieldsOfStudy { get; set; }
        //public virtual Semester Semester { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Group> Groups { get; set; }
    }
}
