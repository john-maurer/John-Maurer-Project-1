using NUnit.Framework;

namespace Tests.UnitTest {

    public class Address_UT {

        PizzaBox.Domain.Models.Elements.Address _address = new PizzaBox.Domain.Models.Elements.Address ();

        [ SetUp ]
        public void Setup () {

            _address.Apartment = "A";
            _address.City      = "Kingsville";
            _address.State     = "TX";
            _address.Street    = "FS Street";
            _address.Zip       = "98376";

        }

        [ Test ]
        public void Write () {

            _address.Save ();

            System.Guid test = _address.Id;

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Addresses.Find ( test ).Id  != System.Guid.Empty )
                    Assert.Pass ( "Value: {0}", _address.Id ); else Assert.Fail ( "Value: {0}", _address.Id );

            }

            Assert.Pass ();

        }

        [ Test ]
        public void Delete () {

            var local = new PizzaBox.Domain.Models.Elements.Address ();

            local.Apartment = "A";
            local.City      = "Kingsville";
            local.State     = "TX";
            local.Street    = "I Should be Deleted Street";
            local.Zip       = "91837";

            local.Save ();

            System.Guid test = local.Id;

            local.Delete ();

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.Addresses.Find ( test ) == null )
                    Assert.Pass (); else Assert.Fail ();

            }

        }

        [ Test ]
        public void Read () {

            

        }

    }

}