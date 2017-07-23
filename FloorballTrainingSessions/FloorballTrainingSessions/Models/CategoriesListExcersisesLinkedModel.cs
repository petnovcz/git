using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloorballTrainingSessions
{
    public partial class CategoriesListExcersisesLinkedModel
    {
        public CategoriesListExcersisesLinkedModel()
        {
        }
        [NotMapped]
        [Key]
        public int ExcersiseCategory { get; set; }
        [NotMapped]
        public string ExcerciseCaegoryName { get; set; }
        [NotMapped]
        public int Excersise { get; set; }
        [NotMapped]
        public bool Linked { get; set; }
        [NotMapped]
        public bool Available { get; set; }
    }
}




