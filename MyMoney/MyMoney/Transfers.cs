//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMoney
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transfers
    {
        public int Id { get; set; }
        public System.DateTime TransferDate { get; set; }
        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        public double Amount { get; set; }
    
        public virtual Accounts Accounts { get; set; }
        public virtual Accounts Accounts1 { get; set; }
    }
}
