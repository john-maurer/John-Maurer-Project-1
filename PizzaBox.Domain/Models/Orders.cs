using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Domain.Models {

    public class Orders : IModels < Elements.Order, Elements.OrderArgs > {

        protected override Elements.Order Read ( Elements.OrderArgs entityArgs ) {

            if ( entityArgs == Elements.OrderArgs.Empty ) return Elements.Order.Empty; else {

                using ( var context = new Data.PizzaBoxDbContext () ) {

                    if ( entityArgs.OutletId != null && entityArgs.OutletId != Guid.Empty ) {

                        return new Elements.Order ( 

                            ( from rec in context.Orders where 
                                 rec.Id == entityArgs.Id
                            select rec ).FirstOrDefault ()

                        );

                    } else if ( entityArgs.OutletId != null && entityArgs.OutletId != Guid.Empty ) {

                        return new Elements.Order ( 

                            ( from rec in context.Orders where 
                                 rec.OutletId == entityArgs.OutletId
                            select rec ).FirstOrDefault ()

                        );

                    } else {

                        return new Elements.Order ( 

                            ( from rec in context.Orders where 
                                 rec.PersonId == entityArgs.PersonId
                            select rec ).FirstOrDefault ()

                        );

                    }

                }

            }

        }

        protected override LinkedList < Elements.Order > ReadAll () {

            using ( var context = new Data.PizzaBoxDbContext () ) { 

                var result = new LinkedList < Elements.Order > ();

                foreach ( var record in context.Orders ) 
                    result.AddLast ( new Elements.Order ( record ) );

                return result;

            }

        }

        public Orders () : base () { _resource = ReadAll (); }

        public Orders ( ref Orders addresses ) : base () { _resource = addresses._resource; }

        public Orders ( ref ICollection < Data.Entities.Order > addresses ) {

            foreach ( var index in addresses )
                _resource.AddLast ( new Models.Elements.Order ( index ) );

        }

        public override Elements.Order this [ Elements.OrderArgs Index ] {

            get { return Read ( Index ); }

            set {

                if ( this.HasChanged == Status.Unchanged ) this.HasChanged = Status.Updated;

                var result = value;

                if ( result.HasChanged == Status.Unchanged ) result.HasChanged = Status.Updated;


            }

        }

    }

 }
