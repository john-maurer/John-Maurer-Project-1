using System;
using PizzaBox.Data;

namespace PizzaBox.Shell {

    class Program {

        static void Main ( string [] args ) {

            /*switch ( Utilities.MainMenu.MainPrompt () ) {

                case "1": { Utilities.MainMenu.CreateOutletCustomer (); } break;
                case "2": { Utilities.MainMenu.RemoveOutletCustomer (); } break;
                case "3": { Utilities.MainMenu.ViewOutletCustomers (); }  break;

                default: break;
                
            };*/

            Data.Entities.Address _address = new Data.Entities.Address ();

            var context = new Data.PizzaBoxDbContext ();

            _address.Apt       = "A";
            _address.City      = "Kingsville";
            _address.State     = "TX";
            _address.Street    = "FS Street";
            _address.Zip       = "918376";

            context.Attach ( _address );
            context.Addresses.Add ( _address );
            context.SaveChanges ();

            //using ( var context = new PizzaBoxDbContext ( new Microsoft.EntityFrameworkCore.DbContextOptions < PizzaBoxDbContext > () ) {

                //context.Attach ( _address );

                //foreach ( var element in context.StateTaxes )
                    //Console.WriteLine ( "Id: {0}\nTerritory: {1}\nRate: {2}", element.Id.ToString (), element.Territory, element.TaxRate.ToString () );

                //context.StateTaxes

                //var temp = ( from rec in context.StateTaxes where rec.Territory == "CA" select rec ).FirstOrDefault < PizzaBox.Data.Entities.StateTax > ();

                //Console.WriteLine ( "Id: {0}\nTerritory: {1}\nRate: {2}", temp.Id.ToString (), temp.Territory, temp.TaxRate.ToString () );

                //var temp = ( from rec in context.StateTaxes where rec.Territory == "CA" select rec );

                //Console.WriteLine ( "Id: {0}\nTerritory: {1}\nRate: {2}", context.StateTaxes
                    
                    //.Id.ToString (), element.Territory, element.TaxRate.ToString () );

            //}

        }

    }

}
