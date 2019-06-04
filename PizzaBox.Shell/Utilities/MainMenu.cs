using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Shell.Utilities {

    sealed public class MainMenu {

        private static bool MainPromptIsValid ( string selection ) {

            return ( selection == "1" || selection == "2" || selection == "3" || selection.ToLower () == "exit"  );

        }

        private static void Banner () { System.Console.WriteLine ( "PizzaBox.Shell - Outlet Manager\n\n" ); }

        public static void CreateOutletCustomer () {

            Utilities.MainMenu.Banner ();

            System.Console.WriteLine ( "Create Outlet" );
            System.Console.ReadLine ();

            MainPrompt ();

        }

        public static void RemoveOutletCustomer () {

            Utilities.MainMenu.Banner ();

            System.Console.WriteLine ( "Remove Outlet" );
            System.Console.ReadLine ();

            MainPrompt ();

        }

        public static void ViewOutletCustomers () {

            Utilities.MainMenu.Banner ();

            System.Console.WriteLine ( "View all Outlets" );
            System.Console.ReadLine ();

            MainPrompt ();

        }

        public static string MainPrompt () {

            string selection;

            do { 

                Utilities.MainMenu.Banner ();

                System.Console.WriteLine ( "1) Create Outlet\n2) Remove Outlet\n3) View Outlets\n\nEnter, 'exit', to close shell\n\nSelection - " );
                selection = System.Console.ReadLine ();

                System.Console.Clear ();

            } while ( ! MainPromptIsValid ( selection ) );

            return selection;

        }



    }

}
