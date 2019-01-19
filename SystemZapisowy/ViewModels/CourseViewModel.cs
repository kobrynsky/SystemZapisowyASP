using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;

namespace SystemZapisowy.ViewModels
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
        public string Name { get; set; }

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
