using NUnit.Framework;

namespace Tests.UnitTest {

    public class SalesTax_UT {

        PizzaBox.Domain.Models.Elements.SalesTax tax = new PizzaBox.Domain.Models.Elements.SalesTax ();

        [ SetUp ]
        public void Setup () {

            tax.Rate = 2.4;
            tax.Territory = "MARS";

        }

        [ Test ]
        public void Write () {

            tax.Save ();

            System.Guid test = tax.Id;

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.StateTaxes.Find ( test ).Id  != System.Guid.Empty )
                    Assert.Pass ( "Value: {0}", tax.Id ); else Assert.Fail ( "Value: {0}", tax.Id );

            }

        }

        [ Test ]
        public void Delete () {

            var local = new PizzaBox.Domain.Models.Elements.SalesTax ();

            local.Territory = "HELL";
            local.Rate      = 1.2;

            local.Save ();

            System.Guid test = local.Id;

            local.Delete ();

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.StateTaxes.Find ( test ) == null )
                    Assert.Pass (); else Assert.Fail ();

            }

        }

        [ Test ]
        public void Read () {

            
            Assert.Pass ();

        }

    }

}