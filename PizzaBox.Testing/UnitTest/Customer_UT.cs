using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests.UnitTest {

    public class Customer_UT {

        PizzaBox.Domain.Models.Elements.Customer customer = new PizzaBox.Domain.Models.Elements.Customer ();

        [ SetUp ]
        public void Setup () {

            customer.DoB = DateTime.UtcNow;
            customer.Email = "mesohungry@famished.com";
            customer.FirstName = "me";
            customer.MiddleName = "so";
            customer.LastName = "soTired";
            customer.Phone = "333-555-0908";

        }

        [ Test ]
        public void Write () {

            customer.Save ();

            System.Guid test = customer.Id;

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.People.Find ( test ).Id  != System.Guid.Empty )
                    Assert.Pass ( "Value: {0}", customer.Id ); else Assert.Fail ( "Value: {0}", customer.Id );

            }

            Assert.Pass ();

        }

        [ Test ]
        public void Delete () {

            var local = new PizzaBox.Domain.Models.Elements.Customer ();

            local.DoB = DateTime.UtcNow;
            local.Email = "delete@me.com";
            local.FirstName = "me";
            local.MiddleName = "delete";
            local.LastName = "please";
            local.Phone = "001-010-1010";

            local.Save ();

            System.Guid test = local.Id;

            local.Delete ();

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.People.Find ( test ) == null )
                    Assert.Pass (); else Assert.Fail ();

            }

        }

        [ Test ]
        public void Read () {

            

        }

    }

}
