using NUnit.Framework;

namespace Tests.UnitTest {

    public class Feature_UT {

        PizzaBox.Domain.Models.Elements.Feature feature = new PizzaBox.Domain.Models.Elements.Feature ();

        [ SetUp ]
        public void Setup () {

            feature.Name = "cheese";
            feature.Price = 10.99;

        }

        [ Test ]
        public void Write () {

            feature.Save ();

            System.Guid test = feature.Id;

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Features.Find ( test ).Id  != System.Guid.Empty )
                    Assert.Pass ( "Value: {0}", feature.Id ); else Assert.Fail ( "Value: {0}", feature.Id );

            }

        }

        [ Test ]
        public void Delete () {

            var local = new PizzaBox.Domain.Models.Elements.Feature ();

            local.Name  = "Rotten Tomato";
            local.Price = 3.23;

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