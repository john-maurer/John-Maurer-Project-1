using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaBox.Domain.Models {

    public class Addresses : IModels < Elements.Address, Elements.AddressArgs > {

        protected override Elements.Address Read ( Elements.AddressArgs entityArgs ) {

            if ( entityArgs == Elements.AddressArgs.Empty ) return Elements.Address.Empty; else {

                using ( var context = new Data.PizzaBoxDbContext () ) {

                    if ( entityArgs.OutletId != null && entityArgs.OutletId != Guid.Empty ) {

                        return new Elements.Address ( 

                            ( from rec in context.Addresses where 
                                 rec.OutletId == entityArgs.OutletId
                            select rec ).FirstOrDefault ()

                        );

                    } else if ( entityArgs.PersonId != null && entityArgs.PersonId != Guid.Empty ) {

                        return new Elements.Address ( 

                            ( from rec in context.Addresses where 
                                 rec.PersonId == entityArgs.PersonId
                            select rec ).FirstOrDefault ()

                        );

                    } else if ( entityArgs.AddressId != null && entityArgs.AddressId != Guid.Empty ) {

                        return new Elements.Address ( 

                            ( from rec in context.Addresses where 
                                 rec.PersonId == entityArgs.PersonId &&
                                 rec.Id       == entityArgs.AddressId
                            select rec ).FirstOrDefault ()

                        );

                    } else {

                        if (

                            entityArgs.State     == String.Empty &&
                            entityArgs.City      != String.Empty &&
                            entityArgs.Street    != String.Empty &&
                            entityArgs.Zip       != String.Empty &&
                            entityArgs.Apartment != String.Empty 

                        ) {

                            return new Elements.Address ( 

                                ( from rec in context.Addresses where 
                                    rec.State == entityArgs.State
                                select rec ).FirstOrDefault ()

                            ); 

                        } else if (

                            entityArgs.State     == String.Empty &&
                            entityArgs.City      == String.Empty &&
                            entityArgs.Street    != String.Empty &&
                            entityArgs.Zip       != String.Empty &&
                            entityArgs.Apartment != String.Empty 

                        ) {

                            return new Elements.Address ( 

                                ( from rec in context.Addresses where 
                                    rec.State == entityArgs.State &&
                                    rec.City  == entityArgs.City
                                select rec ).FirstOrDefault ()

                            ); 

                        } else if (

                            entityArgs.State     == String.Empty &&
                            entityArgs.City      == String.Empty &&
                            entityArgs.Street    == String.Empty &&
                            entityArgs.Zip       != String.Empty &&
                            entityArgs.Apartment != String.Empty 

                        ) {

                            return new Elements.Address ( 

                                ( from rec in context.Addresses where 
                                    rec.State  == entityArgs.State &&
                                    rec.City   == entityArgs.City &&
                                    rec.Street == entityArgs.Street
                                select rec ).FirstOrDefault ()

                            ); 

                        } else if (

                            entityArgs.State     == String.Empty &&
                            entityArgs.City      == String.Empty &&
                            entityArgs.Street    == String.Empty &&
                            entityArgs.Zip       == String.Empty &&
                            entityArgs.Apartment != String.Empty 

                        ) {

                            return new Elements.Address ( 

                                ( from rec in context.Addresses where 
                                    rec.State  == entityArgs.State &&
                                    rec.City   == entityArgs.City &&
                                    rec.Street == entityArgs.Street &&
                                    rec.Apt    == entityArgs.Apartment
                                select rec ).FirstOrDefault ()

                            ); 

                        } else {

                            return new Elements.Address ( 

                                ( from rec in context.Addresses where 
                                    rec.State  == entityArgs.State &&
                                    rec.City   == entityArgs.City &&
                                    rec.Street == entityArgs.Street &&
                                    rec.Apt    == entityArgs.Apartment &&
                                    rec.Zip    == entityArgs.Zip
                                select rec ).FirstOrDefault ()

                            ); 

                        }

                    }

                }

            }

        }

        protected override LinkedList < Elements.Address > ReadAll () {

            using ( var context = new Data.PizzaBoxDbContext () ) { 

                var result = new LinkedList < Elements.Address > ();

                foreach ( var record in context.Addresses ) 
                    result.AddLast ( new Elements.Address ( record ) );

                return result;

            }

        }

        public Addresses () : base () { _resource = ReadAll (); }

        public Addresses ( ref Addresses addresses ) : base () { _resource = addresses._resource; }

        public Addresses ( ref ICollection < Data.Entities.Address > addresses ) {

            foreach ( var index in addresses )
                _resource.AddLast ( new Models.Elements.Address ( index ) );

        }

        public override Elements.Address this [ Elements.AddressArgs Index ] {

            get { return Read ( Index ); }

            set {

                if ( this.HasChanged == Status.Unchanged ) this.HasChanged = Status.Updated;

                var result = value;

                if ( result.HasChanged == Status.Unchanged ) result.HasChanged = Status.Updated;


            }

        }

    }

 }
