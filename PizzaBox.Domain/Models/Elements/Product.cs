using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models.Elements {

    sealed public class ProductArgs : EventArgs {

        public static new readonly ProductArgs Empty = new ProductArgs ();

        public Guid   Id       = Guid.Empty;
        public Guid?  OutletId = Guid.Empty;

        public string Name     = String.Empty;
        public double Cost     = 0.0f;
        public string Features = String.Empty;

        public ProductArgs () { }

        public ProductArgs ( Guid? Id, Guid? OutletId ) {

            if ( Id != null && Id != Guid.Empty ) this.Id = ( Guid ) Id;
            if ( OutletId != null && OutletId != Guid.Empty ) this.OutletId = OutletId;

        }

        public ProductArgs ( string Name, double Cost, string Features ) {

            this.Name     = Name;
            this.Cost     = Cost;
            this.Features = Features;

        }

    }

    sealed public class Product : IElement < Data.Entities.Item > {

        public static readonly Product Empty = new Product ();

        public Product () : base () { _resource = new Data.Entities.Item (); }

        public Product ( Data.Entities.Item entity ) { _resource = entity; }

        public Product ( Product product ) { _resource = product._resource; }

        public Product ( ProductArgs args ) {

            _resource.Id       = args.Id;
            _resource.OutletId = args.OutletId;
            _resource.Name     = args.Name;
            _resource.Features = args.Features;
            _resource.Cost     = args.Cost;

        }

        public override Elements.IElement < Data.Entities.Item > Save () {

            if (_resource.Id == Guid.Empty ) _resource.Id = Guid.NewGuid ();

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Item > ( _resource );
                context.Add    < Data.Entities.Item > ( _resource );
                context.SaveChanges ();

            }

            return new Product ( _resource );

        }

        public override void Delete () {

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Item > ( _resource );
                context.Remove < Data.Entities.Item > ( _resource );
                context.SaveChanges ();

            }

        }

        public override bool Uncommitted { get { return _resource.Id == Guid.Empty ? true : false; } }

        public override Guid Id { get { return _resource.Id; } }

        public Guid? OutletId { get { return _resource.OutletId; } set { _resource.OutletId = value; } }

        public string Name { get { return _resource.Name; } set { _resource.Name = value; } }

        public double Price { get { return _resource.Cost; } set { _resource.Cost = value; } }

        public string Features { get { return _resource.Features; } set { _resource.Features = value; } }

        public Data.Entities.Outlet Business {

            get { return _resource.Outlet; }
            set { _resource.Outlet = value; }

        }

    }

}
