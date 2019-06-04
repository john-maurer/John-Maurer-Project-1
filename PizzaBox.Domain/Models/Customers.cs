using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Domain.Models {

    public class Customers : IModels < Elements.Customer, Elements.CustomerArgs > {

        protected override Elements.Customer Read ( Elements.CustomerArgs entityArgs ) {

            if ( entityArgs == Elements.CustomerArgs.Empty ) return Elements.Customer.Empty; else {

                using ( var context = new Data.PizzaBoxDbContext () ) {

                    if ( entityArgs.Id != null && entityArgs.Id != Guid.Empty ) {

                        return new Elements.Customer ( 

                            ( from rec in context.People where 
                                 rec.Id == entityArgs.Id
                            select rec ).FirstOrDefault ()

                        );

                    } else {

                        return new Elements.Customer ( 

                            ( from rec in context.People where 
                                 rec.Email == entityArgs.Email
                            select rec ).FirstOrDefault ()

                        );

                    }

                }

            }

        }

        protected override LinkedList < Elements.Customer > ReadAll () {

            using ( var context = new Data.PizzaBoxDbContext () ) { 

                var result = new LinkedList < Elements.Customer > ();

                foreach ( var record in context.People ) 
                    result.AddLast ( new Elements.Customer ( record ) );

                return result;

            }

        }

        public Customers () : base () { _resource = ReadAll (); }

        public Customers ( ref Customers addresses ) : base () { _resource = addresses._resource; }

        public Customers ( ref ICollection < Data.Entities.Person > addresses ) {

            foreach ( var index in addresses )
                _resource.AddLast ( new Models.Elements.Customer ( index ) );

        }

        public override Elements.Customer this [ Elements.CustomerArgs Index ] {

            get { return Read ( Index ); }

            set {

                if ( this.HasChanged == Status.Unchanged ) this.HasChanged = Status.Updated;

                var result = value;

                if ( result.HasChanged == Status.Unchanged ) result.HasChanged = Status.Updated;


            }

        }

    }

 }
