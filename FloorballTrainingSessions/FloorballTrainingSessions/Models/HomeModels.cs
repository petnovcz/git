using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloorballTrainingSessions.Models
{
    public partial class HomeModels
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HomeModels()
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





        
