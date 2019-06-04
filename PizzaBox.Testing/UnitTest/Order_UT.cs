using NUnit.Framework;

namespace Tests.UnitTest {

    public class Order_UT {

        PizzaBox.Domain.Models.Elements.Order order = new PizzaBox.Domain.Models.Elements.Order ();

        [ SetUp ]
        public void Setup () {

            order.Items     = "none";
            order.Subtotal  = 912.45;
            order.Total     = 1203.01;
            order.OrderDate = System.DateTime.Now;

        }

        [ Test ]
        public void Write () {

            order.Save ();

            System.Guid test = order.Id;

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Orders.Find ( test ).Id  != System.Guid.Empty )
                    Assert.Pass ( "Value: {0}", order.Id ); else Assert.Fail ( "Value: {0}", order.Id );

            }

        }

        [ Test ]
        public void Delete () {

            var local = new PizzaBox.Domain.Models.Elements.Order ();

            /*order.Items     = "sticky-icky";
            order.Subtotal  = 100.00;
            order.Total     = 10.00;
            order.OrderDate = new System.DateTime ();
            order.Items     = string.Empty;*/

            order.Items     = "none";
            order.Subtotal  = 912.45;
            order.Total     = 1203.01;
            order.OrderDate = System.DateTime.Now;

            local.Save ();

            System.Guid test = local.Id;

            local.Delete ();

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Orders.Find ( test ) == null )
                    Assert.Pass (); else Assert.Fail ();

            }

        }

        [ Test ]
        public void Read () {



            Assert.Pass ();

        }

    }

}
