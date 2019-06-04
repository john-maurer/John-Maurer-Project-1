using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Domain.Models {

    public class Employees : IModels < Elements.Employee, Elements.EmployeeArgs > {

        protected override Elements.Employee Read ( Elements.EmployeeArgs entityArgs ) {

            if ( entityArgs == Elements.EmployeeArgs.Empty ) return Elements.Employee.Empty; else {

                using ( var context = new Data.PizzaBoxDbContext () ) {

                    if ( entityArgs.Id != null && entityArgs.Id != Guid.Empty ) {

                        return new Elements.Employee ( 

                            ( from rec in context.PeopleEmployees where 
                                 rec.Id == entityArgs.Id
                            select rec ).FirstOrDefault ()

                        );

                    } else {

                        return new Elements.Employee ( 

                            ( from rec in context.PeopleEmployees where 
                                 rec.Username == entityArgs.Username
                            select rec ).FirstOrDefault ()

                        );

                    }

                }

            }

        }

        protected override LinkedList < Elements.Employee > ReadAll () {

            using ( var context = new Data.PizzaBoxDbContext () ) { 

                var result = new LinkedList < Elements.Employee > ();

                foreach ( var record in context.PeopleEmployees ) 
                    result.AddLast ( new Elements.Employee ( record ) );

                return result;

            }

        }

        public Employees () : base () { _resource = ReadAll (); }

        public Employees ( ref Employees addresses ) : base () { _resource = addresses._resource; }

        public Employees ( ref ICollection < Data.Entities.PeopleEmployee > addresses ) {

            foreach ( var index in addresses )
                _resource.AddLast ( new Models.Elements.Employee ( index ) );

        }

        public override Elements.Employee this [ Elements.EmployeeArgs Index ] {

            get { return Read ( Index ); }

            set {

                if ( this.HasChanged == Status.Unchanged ) this.HasChanged = Status.Updated;

                var result = value;

                if ( result.HasChanged == Status.Unchanged ) result.HasChanged = Status.Updated;


            }

        }

    }

 }
