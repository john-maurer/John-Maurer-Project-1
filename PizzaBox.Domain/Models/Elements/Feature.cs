using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models.Elements {

    sealed public class FeatureArgs : EventArgs {

        public static new readonly FeatureArgs Empty = new FeatureArgs ();

        public Guid?   Id       = Guid.Empty;
        public Guid?   OutletId = Guid.Empty;

        public string  Name     = String.Empty;
        public double  Cost     = 0.0f;

        public FeatureArgs () { }

        public FeatureArgs ( string Name, double Cost ) {

            this.Name = Name;
            this.Cost = Cost;

        }

        public FeatureArgs ( FeatureArgs featureArgs ) {

            this.Name = featureArgs.Name;
            this.Cost = featureArgs.Cost;

        }

        public FeatureArgs ( Guid? Id, Guid? OutletId = null ) {

            if ( Id != null && Id != Guid.Empty ) this.Id = Id;
            if ( OutletId != null && OutletId != Guid.Empty ) this.OutletId = OutletId;

        }

    }

    sealed public class Feature : IElement < Data.Entities.Feature > {

        public static readonly Feature Empty = new Feature();

        public Feature () : base () { _resource = new Data.Entities.Feature (); }

        public Feature ( Data.Entities.Feature entity ) { _resource = entity; }

        public Feature ( Feature feature ) { _resource = feature._resource; }

        public Feature ( FeatureArgs featureArgs ) {

            _resource.Id       = ( Guid ) featureArgs.Id;
            _resource.OutletId = featureArgs.OutletId;
            _resource.Name     = featureArgs.Name;
            _resource.Cost     = featureArgs.Cost;

        }

        public override Elements.IElement < Data.Entities.Feature > Save () {

            if ( _resource.Id == Guid.Empty ) _resource.Id = Guid.NewGuid ();

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Feature > ( _resource );
                context.Add < Data.Entities.Feature > ( _resource );
                context.SaveChanges ();

            }

            return new Feature ( _resource );

        }

        public override void Delete () {

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Feature > ( _resource );
                context.Remove < Data.Entities.Feature > ( _resource );
                context.SaveChanges();

            }

        }

        public override bool Uncommitted { get { return _resource.Id == Guid.Empty ? true : false; } }

        public override Guid Id { get { return _resource.Id; } }

        public Guid? OutletId { get { return _resource.OutletId; } set { _resource.OutletId = value; } }

        public string Name { get { return _resource.Name; } set { _resource.Name = value; } }

        public double Price { get { return _resource.Cost; } set { _resource.Cost = value; } }

        public Data.Entities.Outlet Business {

            get { return _resource.Outlet; }
            set { _resource.Outlet = value; }

        }

    }

}
