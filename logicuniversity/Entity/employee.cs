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
    
    public partial class employee
    {
        public employee()
        {
            this.collectionPoints = new HashSet<collectionPoint>();
            this.delegations = new HashSet<delegation>();
            this.delegations1 = new HashSet<delegation>();
            this.inventoryAdjs = new HashSet<inventoryAdj>();
            this.inventoryAdjs1 = new HashSet<inventoryAdj>();
            this.requisitions = new HashSet<requisition>();
            this.requisitions1 = new HashSet<requisition>();
            this.requisitions2 = new HashSet<requisition>();
        }
    
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public Nullable<int> role_id { get; set; }
        public Nullable<int> dept_id { get; set; }
        public string emp_email { get; set; }
        public string emp_password { get; set; }
    
        public virtual ICollection<collectionPoint> collectionPoints { get; set; }
        public virtual ICollection<delegation> delegations { get; set; }
        public virtual ICollection<delegation> delegations1 { get; set; }
        public virtual department department { get; set; }
        public virtual role role { get; set; }
        public virtual ICollection<inventoryAdj> inventoryAdjs { get; set; }
        public virtual ICollection<inventoryAdj> inventoryAdjs1 { get; set; }
        public virtual ICollection<requisition> requisitions { get; set; }
        public virtual ICollection<requisition> requisitions1 { get; set; }
        public virtual ICollection<requisition> requisitions2 { get; set; }
    }
}
