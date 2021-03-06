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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Trainings
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainings()
        {
            this.PlayerSigningToTrainings = new HashSet<PlayerSigningToTrainings>();
            this.TrainingExcersises = new HashSet<TrainingExcersises>();
        }
    
        public int Id { get; set; }
        
        [Display(Name ="Tr�nink")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public System.DateTime TrainingDate { get; set; }

        [Display(Name = "Sraz")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public System.DateTime MeetDate { get; set; }

        [Display(Name = "Nahl�en�")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public System.DateTime SigningLimitDate { get; set; }
        [Display(Name = "M�sto")]
        public int TrainingLocation { get; set; }
        [Display(Name = "T�m")]
        public int Team { get; set; }
        [Display(Name = "Sez�na")]
        public int Season { get; set; }
        [Display(Name = "��st tr�ninku")]
        public int SeasonPart { get; set; }
        [Display(Name = "Zam��en�")]
        public Nullable<int> TrainingFocus { get; set; }
        [Display(Name = "Model")]
        public Nullable<int> TrainingSchemeModel { get; set; }
        [Display(Name = "Doba trv�n�")]
        public double TrainingLength { get; set; }
        [Display(Name = "Tr�nink vid.")]
        public bool PublishTraining { get; set; }
        [Display(Name = "Cvi�en� vid.")]
        public bool PublishExcersises { get; set; }
        [Display(Name = "Tr. uzav�en")]
        public bool TrainingClosed { get; set; }
        [Display(Name = "Tr. zru�en")]
        public bool TrainingCanceled { get; set; }
        [Display(Name = "Doch�zka uz.")]
        public bool AttendanceClosed { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerSigningToTrainings> PlayerSigningToTrainings { get; set; }
        public virtual SeasonParts SeasonParts { get; set; }
        public virtual Seasons Seasons { get; set; }
        public virtual Teams Teams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingExcersises> TrainingExcersises { get; set; }
        public virtual TrainingFocuses TrainingFocuses { get; set; }
        public virtual TrainingLocations TrainingLocations { get; set; }
        public virtual TrainingSchemeModels TrainingSchemeModels { get; set; }
        [NotMapped]
        public int Excersisecount { get { return this.TrainingExcersises.Count; } }
        [NotMapped]
        public DayOfWeek DayOfTraining { get {
                

                return this.TrainingDate.DayOfWeek; } }
        
        
    }
}
