using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaBox.Data.Entities
{
    [Table("People_Employee", Schema = "PizzaBoxDbSchema")]
    public partial class PeopleEmployee
    {
        public Guid OutletId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Position { get; set; }
        public double Wage { get; set; }
        public double WageType { get; set; }
        [Required]
        public string Status { get; set; }
        public Guid Id { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("PeopleEmployee")]
        public virtual Person IdNavigation { get; set; }
        [ForeignKey("OutletId")]
        [InverseProperty("PeopleEmployees")]
        public virtual Outlet Outlet { get; set; }
    }
}