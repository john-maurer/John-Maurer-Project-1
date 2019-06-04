using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models.Elements {

    sealed public class AddressArgs : EventArgs {

        new public static AddressArgs Empty = new AddressArgs ();

        public Guid? AddressId = Guid.Empty;
        public Guid? PersonId  = Guid.Empty;
        public Guid? OutletId  = Guid.Empty;

        public string State     = String.Empty;
        public string City      = String.Empty;
        public string Street    = String.Empty;
        public string Zip       = String.Empty;
        public string Apartment = String.Empty;

        public AddressArgs () {}

        public AddressArgs ( Guid? AddressId ) { this.AddressId = AddressId; }

        public AddressArgs ( Guid? PersonId, Guid? OutletId ) {

            if ( PersonId != null && PersonId != Guid.Empty ) this.PersonId = PersonId;
            if ( OutletId != null && OutletId != Guid.Empty ) this.OutletId = OutletId;

        }

        public AddressArgs ( string State, string City, string Street, string Apartment, string Zip ) {

            this.State     = State;
            this.City      = City;
            this.Street    = Street;
            this.Zip       = Zip;
            this.Apartment = Apartment;

        }

        public AddressArgs ( ref AddressArgs addressArgs ) {

            AddressId = addressArgs.AddressId;
            PersonId  = addressArgs.PersonId;
            OutletId  = addressArgs.OutletId;

            State     = addressArgs.State;
            City      = addressArgs.City;
            Street    = addressArgs.State;
            Zip       = addressArgs.Zip;
            Apartment = addressArgs.Apartment;

        }

    }

    sealed public class Address : IElement < Data.Entities.Address > { 

        public static readonly Address Empty = new Address ();

        public Address () : base () { _resource = new Data.Entities.Address (); }

        public Address ( Data.Entities.Address entity ) { _resource = entity; }

        public Address ( Address address ) { _resource = address._resource; }

        public Address ( AddressArgs args ) {

            _resource.Apt      = args.Apartment;
            _resource.City     = args.City;
            _resource.Id       = ( Guid ) args.AddressId; 
            _resource.OutletId = args.OutletId;
            _resource.PersonId = args.PersonId;
            _resource.State    = args.State;
            _resource.Street   = args.Street;
            _resource.Zip      = args.Zip;

        }

        public override Elements.IElement < Data.Entities.Address > Save () {

            if (_resource.Id == Guid.Empty ) _resource.Id = Guid.NewGuid ();

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Address > ( _resource );
                context.Add    < Data.Entities.Address > ( _resource );
                context.SaveChanges ();

            }

            return new Address ( _resource );

        }

        public override void Delete () {

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Address > ( _resource );
                context.Remove < Data.Entities.Address > ( _resource );
                context.SaveChanges ();

            }

        }

        public override bool Uncommitted { get { return _resource.Id == Guid.Empty ? true : false; } }

        public override Guid Id { get { return _resource.Id; } }

        public Guid? ResidentId {

            get { return _resource.PersonId != Guid.Empty ?_resource.PersonId : _resource.OutletId; }

            set {

                if ( _resource.PersonId == Guid.Empty && _resource.OutletId != Guid.Empty )
                    throw new ArgumentException ( "Address has no recorded resident!\n Person and Outlet Id's are null" );

                if ( _resource.PersonId != Guid.Empty ) _resource.PersonId = value;
                else _resource.OutletId = value;

            }

        }

        public bool IsOutlet { get { return _resource.PersonId == Guid.Empty ? true : false; } }

        public string Apartment { get { return _resource.Apt; } set { _resource.Apt = value; } }

        public string City { get { return _resource.City; } set { _resource.City = value; } }

        public string State { get { return _resource.State; } set { _resource.State = value; } }

        public string Street { get { return _resource.Street; } set { _resource.Street = value; } }

        public string Zip { get { return _resource.Zip; } set { _resource.Zip = value; } }

        public object ResidentInformation {

            get {

                if ( _resource.PersonId == Guid.Empty && _resource.OutletId != Guid.Empty )
                    throw new ArgumentException ( "Address has no recorded resident!\n Person and Outlet Id's are null" );

                return _resource.PersonId != Guid.Empty ? ( object ) _resource.Person : ( object ) _resource.Outlet;

            } set {

                if ( _resource.PersonId == Guid.Empty && _resource.OutletId != Guid.Empty )
                    throw new ArgumentException ( "Address has no resident!\n Person and Outlet Id's are null" );

                if ( value.GetType ().FullName.Contains ( "Person" ) ) _resource.Person = ( Data.Entities.Person ) value;
                else if ( value.GetType ().FullName.Contains ( "Outlet" ) ) _resource.Outlet = ( Data.Entities.Outlet ) value;
                else throw new ArgumentException ( "Type assigned to Address.ResidentInformation instance is neither of type Person or Outlet" );

            }

        }

    }

}
