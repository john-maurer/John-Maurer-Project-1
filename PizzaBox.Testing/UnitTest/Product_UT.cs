using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.UnitTest {

    public class Product_UT {

        PizzaBox.Domain.Models.Elements.Product product = new PizzaBox.Domain.Models.Elements.Product ();

        [ SetUp ]
        public void Setup () {

            product.Name     = "Gross Pizza";
            product.Features = "Severed Heads, Teeth, Chewed Gum";
            product.Price    = 12.34;
            product.Business = new PizzaBox.Data.Entities.Outlet ();
            product.Business.Organization    = "Gross Pizza especial";
            product.Business.Addresses       = new LinkedList < PizzaBox.Data.Entities.Address > ();
            product.Business.PeopleEmployees = new LinkedList < PizzaBox.Data.Entities.PeopleEmployee > ();
            product.Business.Features        = new LinkedList < PizzaBox.Data.Entities.Feature > ();
            product.Business.Items           = new LinkedList < PizzaBox.Data.Entities.Item > ();
            product.Business.Orders          = new LinkedList < PizzaBox.Data.Entities.Order > ();

        }

        [ Test ]
        public void Write () {

            var local = new PizzaBox.Domain.Models.Elements.Product ();

            local.Features  = "Cig Butts";
            local.Name      = "Smokin Pizza";
            local.Price     = 116.23;

            product.Save ();

            //System.Guid test = product.Id;

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Items.Find ( product.Id ).Id  != System.Guid.Empty )
                    Assert.Pass ( "Value: {0}", product.Id ); else Assert.Fail ( "Value: {0}", product.Id );

            }

        }

        [ Test ]
        public void Delete () {

            var local = new PizzaBox.Domain.Models.Elements.Product ();

            local.Features  = "A";
            local.Name      = "Forbidden Pizza";
            local.Price     = 16.66;

            local.Save ();

            System.Guid test = local.Id;

            local.Delete ();

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Items.Find ( test ) == null )
                    Assert.Pass (); else Assert.Fail ();

            }

        }

        [ Test ]
        public void Read () {

            Assert.Pass ();

        }

    }

}