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
    
    public partial class purchaseOrder
    {
        public purchaseOrder()
        {
            this.deliverOrders = new HashSet<deliverOrder>();
            this.purchaseOrderDetails = new HashSet<purchaseOrderDetail>();
        }
    
        public string po_id { get; set; }
        public string sup_code { get; set; }
        public Nullable<System.DateTime> po_date { get; set; }
        public Nullable<System.DateTime> po_duedate { get; set; }
        public Nullable<System.DateTime> po_approvedate { get; set; }
        public Nullable<decimal> net_amount { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
        public string deliver_status { get; set; }
    
        public virtual ICollection<deliverOrder> deliverOrders { get; set; }
        public virtual supplier supplier { get; set; }
        public virtual ICollection<purchaseOrderDetail> purchaseOrderDetails { get; set; }
    }
}
