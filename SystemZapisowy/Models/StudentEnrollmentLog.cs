//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SystemZapisowy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentEnrollmentLog
    {
        public int Id { get; set; }
        public decimal IndexNumber { get; set; }
        public int GroupId { get; set; }
        public string MessageText { get; set; }
        public System.DateTime DateOfOperation { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}