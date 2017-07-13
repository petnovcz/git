using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloorballTrainingSessions
{
    public partial class MyTrainingsModel
    {
        public MyTrainingsModel()
        {
            this.Trainings = new HashSet<Trainings>();
            
        }
        [NotMapped]
        [Key]
        public string CurrentUser { get; set; }
        [NotMapped]
        public int CurrentPlayer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainings> Trainings { get; set; }
    }
}