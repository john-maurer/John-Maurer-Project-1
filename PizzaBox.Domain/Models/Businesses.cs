using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Domain.Models {

    public class Businesses : IModels < Elements.Business, Elements.BusinessArgs > {

        protected override Elements.Business Read ( Elements.BusinessArgs entityArgs ) {

            if ( entityArgs == Elements.BusinessArgs.Empty ) return Elements.Business.Empty; else {

                using ( var context = new Data.PizzaBoxDbContext () ) {

                    if ( entityArgs.Id != null && entityArgs.Id != Guid.Empty ) {

                        return new Elements.Business ( 

                            ( from rec in context.Outlets where 
                                 rec.Id == entityArgs.Id
                            select rec ).FirstOrDefault ()

                        );

                    } else {

                        return new Elements.Business ( 

                            ( from rec in context.Outlets where 
                                 rec.Organization == entityArgs.Name
                            select rec ).FirstOrDefault ()

                        );

                    }

                }

            }

        }

        protected override LinkedList < Elements.Business > ReadAll () {

            using ( var context = new Data.PizzaBoxDbContext () ) { 

                var result = new LinkedList < Elements.Business > ();

                foreach ( var record in context.Outlets ) 
                    result.AddLast ( new Elements.Business ( record ) );

                return result;

            }

        }

        public Businesses () : base () { _resource = ReadAll (); }

        public Businesses ( ref Businesses addresses ) : base () { _resource = addresses._resource; }

        public Businesses ( ref ICollection < Data.Entities.Outlet > addresses ) {

            foreach ( var index in addresses )
                _resource.AddLast ( new Models.Elements.Business ( index ) );

        }

        public override Elements.Business this [ Elements.BusinessArgs Index ] {

            get { return Read ( Index ); }

            set {

                if ( this.HasChanged == Status.Unchanged ) this.HasChanged = Status.Updated;

                var result = value;

                if ( result.HasChanged == Status.Unchanged ) result.HasChanged = Status.Updated;


            }

        }

    }

 }
