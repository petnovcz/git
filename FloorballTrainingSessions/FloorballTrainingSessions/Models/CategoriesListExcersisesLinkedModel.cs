﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloorballTrainingSessions.Models
{
    public partial class CategoriesListExcersisesLinkedModel
    {
        public CategoriesListExcersisesLinkedModel()
        {
            //this.Seasons = new HashSet<Seasons>();
            //this.Teamplayers = new HashSet<TeamPlayers>();

        }
        [NotMapped]
        public int Excersise { get; set; }
        [NotMapped]
        public int ExcersiseCategory { get; set; }
        [NotMapped]
        public int Selected { get; set; }
        [NotMapped]
        public int Available { get; set; }



        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Excersises> Seasons { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TeamPlayers> Teamplayers { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Trainings> Trainings { get; set; }
    }
}




