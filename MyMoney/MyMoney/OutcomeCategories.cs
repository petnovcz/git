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
    
    public partial class OutcomeCategories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OutcomeCategories()
        {
            this.BudgetOutcomes = new HashSet<BudgetOutcomes>();
            this.Outcomes = new HashSet<Outcomes>();
        }
    
        public int Id { get; set; }
        public string OutcomeCategoryName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BudgetOutcomes> BudgetOutcomes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outcomes> Outcomes { get; set; }
    }
}
