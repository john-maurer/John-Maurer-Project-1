using System;
using NUnit.Framework;

namespace Tests.UnitTest {
    
    public class Employee_UT {

        PizzaBox.Domain.Models.Elements.Employee employee = new PizzaBox.Domain.Models.Elements.Employee ();

        [ SetUp ]
        public void Setup () {

            employee.Employer = new PizzaBox.Data.Entities.Outlet ();
            employee.Employer.Organization = "Some damn place";
            employee.Username = "jmeow";
            employee.Password = "supersecretpassword";
            employee.Wage     = 2.13f;
            employee.WageType = 1.0f;
            employee.Status   = "employed";
            employee.Position = "Professional Back-Scratcher";
            employee.Information = new PizzaBox.Data.Entities.Person ();
            employee.Information.Fname = "";
            employee.Information.Mname = "";
            employee.Information.Lname = "";

        }

        [ Test ]
        public void Write () {

            employee.Save ();

            System.Guid test = employee.Id;

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.PeopleEmployees.Find ( test ).Id  != System.Guid.Empty ) { 

                    Assert.Pass ( "Value: {0}", employee.Id ); 

                } else Assert.Fail ( "Value: {0}", employee.Id );

            }

            Assert.Pass ();

        }

        [ Test ]
        public void Delete () {

            var local = new PizzaBox.Domain.Models.Elements.Employee ();

            employee.Employer = new PizzaBox.Data.Entities.Outlet ();
            employee.Username = "yello";
            employee.Password = new string ( "nooo" );
            employee.Wage     = 2.13f;
            employee.WageType = 1.0f;
            employee.Status   = "fired";
            employee.Position = "Sucka";
            employee.Information.DoB = ( DateTime ) DateTime.MinValue;
            employee.Information.Email = "mellow@yellow.com";
            employee.Information.Fname = "Hangy";
            employee.Information.Mname = "Mangy";
            employee.Information.Lname = "Delete";
            employee.Information.Phone = "213-903-3405";

            local.Save ();

            System.Guid test = local.Id;

            local.Delete ();

            using ( var context = new PizzaBox.Data.PizzaBoxDbContext () ) {

                if ( context.PeopleEmployees.Find ( test ) == null )
                    Assert.Pass (); else Assert.Fail ();

            }

        }

        [ Test ]
        public void Read () {

            

        }

    }

}
