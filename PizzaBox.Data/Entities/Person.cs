using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBox.Data.Entities
{
    [Table("People", Schema = "PizzaBoxDbSchema")]
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        [Required]
        [Column("FName")]
        public string Fname { get; set; }
        [Column("MName")]
        public string Mname { get; set; }
        [Required]
        [Column("LName")]
        public string Lname { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DoB { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual PeopleEmployee PeopleEmployee { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}