//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingSessions
{
    using System;
    using System.Collections.Generic;
    
    public partial class ft_Hall
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ft_Hall()
        {
            this.ft_Trainings = new HashSet<ft_Trainings>();
        }
    
        public int Id { get; set; }
        public string HallName { get; set; }
        public Nullable<double> Price { get; set; }
        public bool Inner { get; set; }
        public bool Outter { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ft_Trainings> ft_Trainings { get; set; }
    }
}
