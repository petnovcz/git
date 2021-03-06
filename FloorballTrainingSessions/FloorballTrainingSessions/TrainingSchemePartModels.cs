//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FloorballTrainingSessions
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrainingSchemePartModels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainingSchemePartModels()
        {
            this.TrainingExcersises = new HashSet<TrainingExcersises>();
        }
    
        public int Id { get; set; }
        public int TrainingSchemeModel { get; set; }
        public int ExcersiseCategory { get; set; }
        public string PartLength { get; set; }
        public Nullable<int> NumberOfExcersises { get; set; }
        public Nullable<int> Series { get; set; }
        public string SeriesLength { get; set; }
        public string RestBetweenSeries { get; set; }
        public string RestBetweenExcersises { get; set; }
    
        public virtual ExcersiseCategories ExcersiseCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingExcersises> TrainingExcersises { get; set; }
        public virtual TrainingSchemeModels TrainingSchemeModels { get; set; }
    }
}
