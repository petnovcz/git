//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingSessions
{
    using System;
    using System.Collections.Generic;
    
    public partial class ft_TrainingExcersises
    {
        public int Id { get; set; }
        public int Training { get; set; }
        public int Excersise { get; set; }
        public int Order { get; set; }
    
        public virtual ft_Excersises ft_Excersises { get; set; }
        public virtual ft_Trainings ft_Trainings { get; set; }
    }
}
