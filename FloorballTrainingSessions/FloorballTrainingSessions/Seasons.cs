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
    
    public partial class Seasons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seasons()
        {
            this.TeamPlayers = new HashSet<TeamPlayers>();
            this.Trainings = new HashSet<Trainings>();
        }
    
        public int Id { get; set; }
        public string SeasonName { get; set; }
        public bool IsActiveSeason { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamPlayers> TeamPlayers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainings> Trainings { get; set; }
    }
}
