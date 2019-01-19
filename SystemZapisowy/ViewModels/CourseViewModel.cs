using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;

namespace SystemZapisowy.ViewModels
{
    public class CourseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseViewModel()
        {
            this.Groups = new HashSet<Group>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public int SemesterId { get; set; }
        public int FieldOfStudyId { get; set; }

        //public virtual FieldsOfStudy FieldsOfStudy { get; set; }
        //public virtual Semester Semester { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
