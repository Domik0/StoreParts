//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreParts
{
    using System;
    using System.Collections.Generic;
    
    public partial class part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public part()
        {
            this.waybills = new HashSet<waybill>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public Nullable<int> id_brand { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public Nullable<int> retail_price { get; set; }
        public Nullable<int> wholesale_price { get; set; }
        public Nullable<int> count_storage { get; set; }
        public Nullable<int> id_category { get; set; }
    
        public virtual brand brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<waybill> waybills { get; set; }
        public virtual category category { get; set; }
    }
}
