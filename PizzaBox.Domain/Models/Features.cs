using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Domain.Models {

    public class Features : IModels < Elements.Feature, Elements.FeatureArgs > {

        protected override Elements.Feature Read ( Elements.FeatureArgs entityArgs ) {

            if ( entityArgs == Elements.FeatureArgs.Empty ) return Elements.Feature.Empty; else {

                using ( var context = new Data.PizzaBoxDbContext () ) {

                    if ( entityArgs.Id != null && entityArgs.Id != Guid.Empty ) {

                        return new Elements.Feature ( 

                            ( from rec in context.Features where 
                                 rec.Id == entityArgs.Id
                            select rec ).FirstOrDefault ()

                        );

                    } else if ( entityArgs.OutletId != null && entityArgs.OutletId != Guid.Empty ) {

                        return new Elements.Feature ( 

                            ( from rec in context.Features where 
                                 rec.OutletId == entityArgs.OutletId
                            select rec ).FirstOrDefault ()

                        );

                    } else {

                        return new Elements.Feature ( 

                            ( from rec in context.Features where 
                                 rec.Name == entityArgs.Name
                            select rec ).FirstOrDefault ()

                        );

                    }

                }

            }

        }

        protected override LinkedList < Elements.Feature > ReadAll () {

            using ( var context = new Data.PizzaBoxDbContext () ) { 

                var result = new LinkedList < Elements.Feature > ();

                foreach ( var record in context.Features ) 
                    result.AddLast ( new Elements.Feature ( record ) );

                return result;

            }

        }

        public Features () : base () { _resource = ReadAll (); }

        public Features ( ref Features addresses ) : base () { _resource = addresses._resource; }

        public Features ( ref ICollection < Data.Entities.Feature > addresses ) {

            foreach ( var index in addresses )
                _resource.AddLast ( new Models.Elements.Feature ( index ) );

        }

        public override Elements.Feature this [ Elements.FeatureArgs Index ] {

            get { return Read ( Index ); }

            set {

                if ( this.HasChanged == Status.Unchanged ) this.HasChanged = Status.Updated;

                var result = value;

                if ( result.HasChanged == Status.Unchanged ) result.HasChanged = Status.Updated;


            }

        }

    }

 }
