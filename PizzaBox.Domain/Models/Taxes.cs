using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Domain.Models {

    public class Taxes : IModels < Elements.SalesTax, Elements.TaxArgs > {

        protected override Elements.SalesTax Read ( Elements.TaxArgs entityArgs ) {

            if ( entityArgs == Elements.TaxArgs.Empty ) return Elements.SalesTax.Empty; else {

                using ( var context = new Data.PizzaBoxDbContext () ) {

                    if ( entityArgs.Id != null && entityArgs.Id != Guid.Empty ) {

                        return new Elements.SalesTax ( 

                            ( from rec in context.StateTaxes where 
                                 rec.Id == entityArgs.Id
                            select rec ).FirstOrDefault ()

                        );

                    } else { 

                        return new Elements.SalesTax ( 

                            ( from rec in context.StateTaxes where 
                                 rec.Id == entityArgs.Id
                            select rec ).FirstOrDefault ()

                        );

                    }

                }

            }

        }

        protected override LinkedList < Elements.SalesTax > ReadAll () {

            using ( var context = new Data.PizzaBoxDbContext () ) { 

                var result = new LinkedList < Elements.SalesTax > ();

                foreach ( var record in context.StateTaxes ) 
                    result.AddLast ( new Elements.SalesTax ( record ) );

                return result;

            }

        }

        public Taxes () : base () { _resource = ReadAll (); }

        public Taxes ( ref Taxes addresses ) : base () { _resource = addresses._resource; }

        public Taxes ( ref ICollection < Data.Entities.StateTax > addresses ) {

            foreach ( var index in addresses )
                _resource.AddLast ( new Models.Elements.SalesTax ( index ) );

        }

        public override Elements.SalesTax this [ Elements.TaxArgs Index ] {

            get { return Read ( Index ); }

            set {

                if ( this.HasChanged == Status.Unchanged ) this.HasChanged = Status.Updated;

                var result = value;

                if ( result.HasChanged == Status.Unchanged ) result.HasChanged = Status.Updated;


            }

        }

    }

 }
