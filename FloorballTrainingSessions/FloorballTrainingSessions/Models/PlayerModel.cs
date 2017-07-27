using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace FloorballTrainingSessions
{
    public partial class PlayerModel
    {
        public PlayerModel()
        {
            
            this.Seasons = new HashSet<Seasons>();
            this.CurrentPlayerTeams = new HashSet<TeamPlayers>();
            this.CurrentPlayerTrainings = new HashSet<Trainings>();
        }
        [NotMapped]
        [Key]
        public AspNetUsers CurrentUser { get; set; }
        [NotMapped]
        public Players CurrentPlayer { get; set; }
        public Seasons ActiveSeason { get; set; }
        //public Seasons SelectedSeason { get; set; }
        public Teams ActiveTeam { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seasons> Seasons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamPlayers> CurrentPlayerTeams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainings> CurrentPlayerTrainings { get; set; }
    }
}



