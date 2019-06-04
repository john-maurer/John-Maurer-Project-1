using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBox.Data.Entities
{
    [Table("Outlets", Schema = "PizzaBoxDbSchema")]
    public partial class Outlet
    {
        public Outlet()
        {
            Addresses = new HashSet<Address>();
            Features = new HashSet<Feature>();
            Items = new HashSet<Item>();
            Orders = new HashSet<Order>();
            PeopleEmployees = new HashSet<PeopleEmployee>();
        }

        public Guid Id { get; set; }
        [Required]
        public string Organization { get; set; }

        [InverseProperty("Outlet")]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty("Outlet")]
        public virtual ICollection<Feature> Features { get; set; }
        [InverseProperty("Outlet")]
        public virtual ICollection<Item> Items { get; set; }
        [InverseProperty("Outlet")]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty("Outlet")]
        public virtual ICollection<PeopleEmployee> PeopleEmployees { get; set; }
    }
}