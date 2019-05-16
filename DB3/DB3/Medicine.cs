//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicine()
        {
            this.Orders = new HashSet<Order>();
            this.Stocks = new HashSet<Stock>();
        }
    
        public int Medicine_id { get; set; }
        public string Medicine_Name { get; set; }
        public int  Price { get; set; }
        public System.DateTime Mfg_Date { get; set; }
        public DateTime Exp_Date { get; set; }
        public string Batch { get; set; }
        public string Type { get; set; }
        public int CompanyID { get; set; }
        public string Weight { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
