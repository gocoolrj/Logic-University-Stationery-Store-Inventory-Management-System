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
    
    public partial class stockcard
    {
        public int id { get; set; }
        public string item_code { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string quantity { get; set; }
    
        public virtual catalogue catalogue { get; set; }
    }
}
