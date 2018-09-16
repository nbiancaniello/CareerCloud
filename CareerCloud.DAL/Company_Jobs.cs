//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareerCloud.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company_Jobs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company_Jobs()
        {
            this.Applicant_Job_Applications = new HashSet<Applicant_Job_Applications>();
            this.Company_Job_Educations = new HashSet<Company_Job_Educations>();
            this.Company_Job_Skills = new HashSet<Company_Job_Skills>();
            this.Company_Jobs_Descriptions = new HashSet<Company_Jobs_Descriptions>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid Company { get; set; }
        public System.DateTime Profile_Created { get; set; }
        public bool Is_Inactive { get; set; }
        public bool Is_Company_Hidden { get; set; }
        public byte[] Time_Stamp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant_Job_Applications> Applicant_Job_Applications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company_Job_Educations> Company_Job_Educations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company_Job_Skills> Company_Job_Skills { get; set; }
        public virtual Company_Profiles Company_Profiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company_Jobs_Descriptions> Company_Jobs_Descriptions { get; set; }
    }
}
