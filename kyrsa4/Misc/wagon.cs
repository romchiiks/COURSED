//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kyrsa4.Misc
{
    using System;
    using System.Collections.Generic;
    
    public partial class wagon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public wagon()
        {
            this.trains = new HashSet<train>();
        }
    
        public int wagon_id { get; set; }
        public string goods_type { get; set; }
        public string wagon_type { get; set; }
        public double maxweight { get; set; }
        public double volume { get; set; }
        public int countindepot { get; set; }
        public int depot_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<train> trains { get; set; }
    }
}