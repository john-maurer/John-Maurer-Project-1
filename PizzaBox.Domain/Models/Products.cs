using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Domain.Models {

    public class Products : IModels < Elements.Product, Elements.ProductArgs > {

        protected override Elements.Product Read ( Elements.ProductArgs entityArgs ) {

            if ( entityArgs == Elements.ProductArgs.Empty ) return Elements.Product.Empty; else {

                using ( var context = new Data.PizzaBoxDbContext () ) {

                    if ( entityArgs.OutletId != null && entityArgs.OutletId != Guid.Empty ) {

                        return new Elements.Product ( 

                            ( from rec in context.Items where 
                                 rec.OutletId == entityArgs.Id
                            select rec ).FirstOrDefault ()

                        );

                    } else if ( entityArgs.OutletId != null && entityArgs.OutletId != Guid.Empty ) {

                        return new Elements.Product ( 

                            ( from rec in context.Items where 
                                 rec.OutletId == entityArgs.OutletId
                            select rec ).FirstOrDefault ()

                        );

                    } else {

                        return new Elements.Product ( 

                            ( from rec in context.Items where 
                                 rec.Name == entityArgs.Name
                            select rec ).FirstOrDefault ()

                        );

                    }

                }

            }

        }

        protected override LinkedList < Elements.Product > ReadAll () {

            using ( var context = new Data.PizzaBoxDbContext () ) { 

                var result = new LinkedList < Elements.Product > ();

                foreach ( var record in context.Items ) 
                    result.AddLast ( new Elements.Product ( record ) );

                return result;

            }

        }

        public Products () : base () { _resource = ReadAll (); }

        public Products ( ref Products addresses ) : base () { _resource = addresses._resource; }

        public Products ( ref ICollection < Data.Entities.Item > addresses ) {

            foreach ( var index in addresses )
                _resource.AddLast ( new Models.Elements.Product ( index ) );

        }

        public override Elements.Product this [ Elements.ProductArgs Index ] {

            get { return Read ( Index ); }

            set {

                if ( this.HasChanged == Status.Unchanged ) this.HasChanged = Status.Updated;

                var result = value;

                if ( result.HasChanged == Status.Unchanged ) result.HasChanged = Status.Updated;


            }

        }

    }

 }
