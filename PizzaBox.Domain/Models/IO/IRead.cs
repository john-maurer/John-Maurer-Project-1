﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBox.Domain.Models.IO {

    public abstract class IRead < T, Ty > : IModel < LinkedList < T > >
        where T: new ()
        where Ty: EventArgs, new () {

        protected abstract T Read ( Ty entityArgs );

        protected abstract LinkedList < T > ReadAll ();

        public IRead () : base () {}

    }

}
