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
    
    public partial class ft_Trainings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ft_Trainings()
        {
            this.ft_TrainingExcersises = new HashSet<ft_TrainingExcersises>();
        }
    
        public int Id { get; set; }
        public System.DateTime Datetime { get; set; }
        public System.DateTime SignLimit { get; set; }
        public int Hall { get; set; }
        public int Season { get; set; }
        public int SeasonPart { get; set; }
        public int Category { get; set; }
        public System.DateTime MeetTime { get; set; }
        public bool ShowExcersises { get; set; }
    
        public virtual ft_Category ft_Category { get; set; }
        public virtual ft_Hall ft_Hall { get; set; }
        public virtual ft_SeasonPart ft_SeasonPart { get; set; }
        public virtual ft_Seasons ft_Seasons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ft_TrainingExcersises> ft_TrainingExcersises { get; set; }
    }
}
