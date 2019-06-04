using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models {

    public abstract class IModels < T, Ty > : IO.IRead < T, Ty >
        where T: new ()
        where Ty: EventArgs, new () {

        public IModels () : base () { }

        abstract public T this [ Ty Index ] { get; set; }

        public LinkedList < T > Records { get { return _resource; } }

    }

}
