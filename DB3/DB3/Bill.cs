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
    
    public partial class Bill
    {
        public int Bill_id { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> CustomerID { get; set; }
    
        public virtual Bill Bill1 { get; set; }
        public virtual Bill Bill2 { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
