using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models.Elements {

    sealed public class BusinessArgs : EventArgs {

        public static new readonly BusinessArgs Empty = new BusinessArgs ();

        public Guid   Id   = Guid.Empty;

        public string Name = String.Empty;

        public BusinessArgs () { }

        public BusinessArgs ( Guid Id ) { this.Id = Id; }

        BusinessArgs ( string BusinessName ) { Name = BusinessName; }

    }

    sealed public class Business : IElement < Data.Entities.Outlet > {

        public static readonly Business Empty = new Business ();

        public Business () : base () { _resource = new Data.Entities.Outlet (); }

        public Business ( Data.Entities.Outlet entity ) { _resource = entity; }

        public Business ( Business business ) { _resource = business._resource; }

        public Business ( BusinessArgs businessArgs ) {

            _resource.Id           = _resource.Id;
            _resource.Organization = businessArgs.Name;

        }

        public override Elements.IElement < Data.Entities.Outlet > Save () {

            if (_resource.Id == Guid.Empty ) _resource.Id = Guid.NewGuid ();

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Outlet > ( _resource );
                context.Add    < Data.Entities.Outlet > ( _resource );
                context.SaveChanges ();

            }

            return new Business ( _resource );

        }

        public override void Delete () {

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Outlet > ( _resource );
                context.Remove < Data.Entities.Outlet > ( _resource );
                context.SaveChanges ();

            }

        }

        public override bool Uncommitted { get { return _resource.Id == Guid.Empty ? true : false; } }

        public override Guid Id { get { return _resource.Id; } }

        public string Name { get { return _resource.Organization; } set { _resource.Organization = value; } }

        public ICollection < Data.Entities.Order > Orders { get { return _resource.Orders; } set { _resource.Orders = value; } }

        public ICollection < Data.Entities.PeopleEmployee > Employees {

            get { return _resource.PeopleEmployees; }
            set { _resource.PeopleEmployees = value; }

        }

        public ICollection < Data.Entities.Item > Items {

            get { return _resource.Items; }
            set { _resource.Items = value; }

        }

        public ICollection < Data.Entities.Feature > Features {

            get { return _resource.Features; }
            set { _resource.Features = value; }

        }

        public ICollection < Data.Entities.Address > Addresses {

            get { return _resource.Addresses; }
            set { _resource.Addresses = value; }

        }

    }

}
