using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models.Elements {

    sealed public class TaxArgs : EventArgs {

        public static new readonly TaxArgs Empty = new TaxArgs ();

        public Guid   Id        = Guid.Empty;
        public string Territory = String.Empty;
        public double TaxRate   = 0.0f; 

        public TaxArgs () { }

        public TaxArgs ( Guid Id ) { this.Id = Id; }

        public TaxArgs ( string Territory, double? TaxRate = null ) {

            if ( TaxRate != null ) this.TaxRate = ( double ) TaxRate;

            this.Territory = Territory;

        }

        public TaxArgs ( TaxArgs taxArgs ) {

            this.Id        = taxArgs.Id;
            this.Territory = taxArgs.Territory;
            this.TaxRate   = taxArgs.TaxRate;

        }

    }

    sealed public class SalesTax : IElement < Data.Entities.StateTax > {

        public static readonly SalesTax Empty = new SalesTax ();

        public SalesTax () : base () { _resource = new Data.Entities.StateTax (); }

        public SalesTax ( Data.Entities.StateTax entity ) { _resource = entity; }

        public SalesTax ( SalesTax salesTax ) { _resource = salesTax._resource; }

        public SalesTax ( TaxArgs args ) {

            _resource.Id        = args.Id;
            _resource.TaxRate   = args.TaxRate;
            _resource.Territory = args.Territory;

        }

        public override Elements.IElement < Data.Entities.StateTax > Save () {

            if (_resource.Id == Guid.Empty ) _resource.Id = Guid.NewGuid ();

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.StateTax > ( _resource );
                context.Add    < Data.Entities.StateTax > ( _resource );
                context.SaveChanges ();

            }

            return new SalesTax ( _resource );

        }

        public override void Delete () {

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.StateTax > ( _resource );
                context.Remove < Data.Entities.StateTax > ( _resource );
                context.SaveChanges ();

            }

        }

        public override bool Uncommitted { get { return _resource.Id == Guid.Empty ? true : false; } }

        public override Guid Id { get { return _resource.Id; } }

        public string Territory { get { return _resource.Territory; } set { _resource.Territory = value; } }

        public double Rate { get { return _resource.TaxRate; } set { _resource.TaxRate = value; } }

    }

}
