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
    
    public partial class request
    {
        public int request_id { get; set; }
        public int goods_id { get; set; }
        public int route_id { get; set; }
        public int user_id { get; set; }
        public int requeststatus_id { get; set; }
    
        public virtual good good { get; set; }
        public virtual request_status request_status { get; set; }
        public virtual route route { get; set; }
        public virtual user user { get; set; }
    }
}
