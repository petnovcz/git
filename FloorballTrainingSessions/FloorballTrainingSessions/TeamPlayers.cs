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

    
    public partial class TeamPlayers
    {
        public int Id { get; set; }
        public int Team { get; set; }
        public int Player { get; set; }
        public int PlayerFunction { get; set; }
        public int Season { get; set; }

        public virtual PlayerFunctions PlayerFunctions { get; set; }
        public virtual Players Players { get; set; }
        public virtual Seasons Seasons { get; set; }
        public virtual Teams Teams { get; set; }
    }
}
