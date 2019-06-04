using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using PizzaBox.Data;

namespace ConsoleApp {

    class Program {

        static void Main ( string [] args ) {

            using ( var context = new PizzaBoxDatabaseContext () ) {

                foreach ( var element in context.StateTaxes )
                    Console.WriteLine ( "Id: {0}\nTerritory: {1}\nRate: {2}", element.Id.ToString (), element.Territory, element.TaxRate.ToString () );

            }

            Console.ReadLine ();

        }

    }

}
