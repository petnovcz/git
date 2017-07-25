using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloorballTrainingSessions
{
    public partial class SigningSummary
    {
        public SigningSummary()
        {


        }
        [Key]
        int training { get; set; }
        public int SignedInAll { get; set; }
        
        public int SignedOutAll { get; set; }
       
        public int SignedInG { get; set; }
        
        public int SignedOutG { get; set; }
        
        public int SignedInH { get; set; }
        
        public int SignedOutH { get; set; }
        
        public int SignedInV { get; set; }
        
        public int SignedOutV { get; set; }

    }
}