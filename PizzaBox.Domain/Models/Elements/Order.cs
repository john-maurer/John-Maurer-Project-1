using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models.Elements {

    sealed public class OrderArgs : EventArgs {

        public static new readonly OrderArgs Empty = new OrderArgs ();

        public Guid      Id          = Guid.Empty;
        public Guid?     OutletId    = Guid.Empty;
        public Guid?     PersonId    = Guid.Empty;

        public string    Items       = String.Empty;
        public DateTime  DateOrdered = new DateTime ();
        public double    SubTotal    = 0.0f;
        public double    Total       = 0.0f;

        public OrderArgs () { }

        public OrderArgs ( Guid Id ) { this.Id = Id; }

        public OrderArgs ( Guid? PersonId, Guid? OutletId = null ) {

            this.PersonId = PersonId;
            if ( OutletId != null ) this.OutletId = OutletId;

        }

    }

    sealed public class Order : IElement<Data.Entities.Order> {

        public static readonly Order Empty = new Order();

        public Order() : base() { _resource = new Data.Entities.Order(); }

        public Order(Data.Entities.Order entity) { _resource = entity; }

        public Order(Order order) { _resource = order._resource; }

        public Order(OrderArgs orderArgs) {

            _resource.Id = orderArgs.Id;
            _resource.OutletId = orderArgs.OutletId;
            _resource.PersonId = orderArgs.PersonId;
            _resource.Items = orderArgs.Items;
            _resource.SubTotal = orderArgs.SubTotal;
            _resource.Total = orderArgs.Total;

        }

        public override Elements.IElement<Data.Entities.Order> Save() {

            if (_resource.Id == Guid.Empty) _resource.Id = Guid.NewGuid();

            using (var context = new Data.PizzaBoxDbContext()) {

                context.Attach<Data.Entities.Order>(_resource);
                context.Add<Data.Entities.Order>(_resource);
                context.SaveChanges();

            }

            return new Order(_resource);

        }

        public override void Delete () {

            using ( var context = new Data.PizzaBoxDbContext () ) {

                context.Attach < Data.Entities.Order > ( _resource );
                context.Remove < Data.Entities.Order > ( _resource );
                context.SaveChanges();

            }

        }

        public override bool Uncommitted { get { return _resource.Id == Guid.Empty ? true : false; } }

        public override Guid Id { get { return _resource.Id; } }

        public Guid? OutletId { get { return _resource.OutletId; } set { _resource.OutletId = value; } }

        public Guid? PersonId { get { return _resource.PersonId; } set { _resource.PersonId = value; } }

        public string Items { get { return _resource.Items; } set { _resource.Items = value; } }

        public DateTime OrderDate { get { return _resource.DateOrdered; } set { _resource.DateOrdered = value; } }

        public double Subtotal { get { return _resource.SubTotal; } set { _resource.SubTotal = value; } }

        public double Total { get { return _resource.Total; } set { _resource.Total = value; } }

        public Data.Entities.Outlet Business {

            get { return _resource.Outlet; }
            set { _resource.Outlet = value; }

        }

        public Data.Entities.Person Customer {

            get { return _resource.Person; }
            set { _resource.Person = value; }

        }

    }

}
