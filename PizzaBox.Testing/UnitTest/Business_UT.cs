using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests.UnitTest {

    public class Business_UT {

        PizzaBox.Domain.Models.Elements.Business business = new PizzaBox.Domain.Models.Elements.Business ();

        [ SetUp ]
        public void Setup () {

            business.Addresses = new LinkedList < PizzaBox.Data.Entities.Address > ();
            business.Employees = new LinkedList < PizzaBox.Data.Entities.PeopleEmployee > ();
            business.Features  = new LinkedList < PizzaBox.Data.Entities.Feature > ();
            business.Items     = new LinkedList < PizzaBox.Data.Entities.Item > ();
            business.Orders    = new LinkedList < PizzaBox.Data.Entities.Order > ();
            business.Name      = "Pizza.Business";

        }

        [ Test ]
        public void Write () {

            business.Save ();

            System.Guid test = business.Id;

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Outlets.Find ( test ).Id  != System.Guid.Empty )
                    Assert.Pass ( "Value: {0}", business.Id ); else Assert.Fail ( "Value: {0}", business.Id );

            }

        }

        [ Test ]
        public void Delete () {

            var local = new PizzaBox.Domain.Models.Elements.Business ();

            local.Addresses = new LinkedList < PizzaBox.Data.Entities.Address > ();
            local.Employees = new LinkedList < PizzaBox.Data.Entities.PeopleEmployee > ();
            local.Features  = new LinkedList < PizzaBox.Data.Entities.Feature > ();
            local.Items     = new LinkedList < PizzaBox.Data.Entities.Item > ();
            local.Orders    = new LinkedList < PizzaBox.Data.Entities.Order > ();
            local.Name      = "Pizza.Deleted Business";

            local.Save ();

            System.Guid test = local.Id;

            local.Delete ();

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Features.Find ( test ) == null )
                    Assert.Pass (); else Assert.Fail ();

            }

        }

        [ Test ]
        public void Read () {

            Assert.Pass ();

        }

    }

}
