//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaBox.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> PersonId { get; set; }
        public Nullable<System.Guid> OutletId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Apt { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Outlet Outlet { get; set; }
    }
}
