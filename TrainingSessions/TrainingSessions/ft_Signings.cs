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
    
    public partial class ft_Signings
    {
        public int Id { get; set; }
        public string username { get; set; }
        public bool Signing { get; set; }
        public byte[] Timestamp { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
