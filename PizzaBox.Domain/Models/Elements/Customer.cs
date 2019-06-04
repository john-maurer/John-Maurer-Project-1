using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models.Elements {

    sealed public class CustomerArgs : EventArgs {

        public static new readonly CustomerArgs Empty = new CustomerArgs ();

        public Guid     Id       = Guid.Empty;

        public string   FName  = String.Empty;
        public string   MName  = String.Empty;
        public string   LName  = String.Empty;
        public bool?    Gender = true;
        public DateTime DoB    = new DateTime ();
        public string   Phone  = String.Empty;
        public string   Email  = String.Empty;

        public CustomerArgs () { }

    }

    sealed public class Customer : IElement < Data.Entities.Person > {

        public static readonly Customer Empty = new Customer ();

        public Customer () : base () { _resource = new Data.Entities.Person (); }

        public Customer ( Data.Entities.Person entity ) { _resource = entity; }

        public Customer ( Customer customer ) { _resource = customer._resource; }

        public Customer ( CustomerArgs customerArgs ) {

            _resource.Id     = customerArgs.Id;
            _resource.DoB    = customerArgs.DoB;
            _resource.Email  = customerArgs.Email;
            _resource.Fname  = customerArgs.FName;
            _resource.Mname  = customerArgs.MName;
            _resource.Lname  = customerArgs.LName;
            _resource.Gender = customerArgs.Gender;
            _resource.Phone  = customerArgs.Phone;

        }

        public override Elements.IElement < Data.Entities.Person > Save () {

            if (_resource.Id == Guid.Empty ) _resource.Id = Guid.NewGuid ();

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Person > ( _resource );
                context.Add    < Data.Entities.Person > ( _resource );
                context.SaveChanges ();

            }

            return new Customer ( _resource );

        }

        public override void Delete () {

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Person > ( _resource );
                context.Remove < Data.Entities.Person > ( _resource );
                context.SaveChanges ();

            }

        }

        public override bool Uncommitted { get { return _resource.Id == Guid.Empty ? true : false; } }

        public override Guid Id { get { return _resource.Id; } }

        public string FirstName { get { return _resource.Fname; } set { _resource.Fname = value; } }

        public string MiddleName { get { return _resource.Mname; } set { _resource.Mname = value; } }

        public string LastName { get { return _resource.Lname; } set { _resource.Lname = value; } }

        public string FormalName { get { return _resource.Lname + ", " + _resource.Fname + " " + _resource.Mname [ 0 ] + "."; } }

        public bool Gender { get { return ( bool ) _resource.Gender; } set { _resource.Gender = value; } }

        public DateTime? DoB { get { return _resource.DoB; } set { _resource.DoB = value; } }

        public string Phone { get { return _resource.Phone; } set { _resource.Phone = value; } }

        public string Email { get { return _resource.Email; } set { _resource.Email = value; } }

        public ICollection < Data.Entities.Address > Addresses {

            get { return _resource.Addresses; }
            set { _resource.Addresses = value; }

        }

        public ICollection < Data.Entities.Order > Orders {

            get { return _resource.Orders; }
            set { _resource.Orders = value; }

        }

    }

}
