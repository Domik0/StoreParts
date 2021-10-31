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
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part()
        {
            this.Images = new HashSet<Image>();
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> IdBrand { get; set; }
        public Nullable<int> IdSparePart { get; set; }
        public string Description { get; set; }
        public Nullable<double> RetailPrice { get; set; }
        public Nullable<int> CountStorage { get; set; }
    
        public virtual Brand Brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }

        [NotMapped]
        public Image FirstImage
        {
            get
            {
                return Images.First();
            }
            set
            {
                FirstImage = value;
            }
        }

        public virtual SparePart SparePart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
