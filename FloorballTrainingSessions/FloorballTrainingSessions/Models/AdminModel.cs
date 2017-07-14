using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloorballTrainingSessions
{
    public partial class AdminModel
    {
        public AdminModel()
        {
            this.Seasons = new HashSet<Seasons>();
            this.Teamplayers = new HashSet<TeamPlayers>();

        }
        [NotMapped]
        [Key]
        public string CurrentUser { get; set; }
        [NotMapped]
        public int CurrentPlayer { get; set; }
        public string CurrentPlayerName { get; set; }
        public int ActiveSeason { get; set; }
        public string ActiveSeasonName { get; set; }
        public int SelectedSeason { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seasons> Seasons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamPlayers> Teamplayers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainings> Trainings { get; set; }
    }
}



