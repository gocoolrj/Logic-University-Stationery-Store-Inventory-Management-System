//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class quotationDetail
    {
        public int quo_id { get; set; }
        public string itemCode { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual catalogue catalogue { get; set; }
        public virtual quotation quotation { get; set; }
    }
}
