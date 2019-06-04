using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models.Elements
{

    sealed public class EmployeeArgs : EventArgs
    {

        public static new readonly EmployeeArgs Empty = new EmployeeArgs();

        public Guid Id = Guid.Empty;
        public Guid EmployerId = Guid.Empty;

        public string Username = String.Empty;
        public string Password = String.Empty;
        public string Position = String.Empty;
        public double Wage = 0.0f;
        public double WageType = 0.0f;
        public string Status = String.Empty;

        public EmployeeArgs() { }

    }

    sealed public class Employee : IElement<Data.Entities.PeopleEmployee>
    {

        public static readonly Employee Empty = new Employee();

        public Employee() : base() { _resource = new Data.Entities.PeopleEmployee(); }

        public Employee(Data.Entities.PeopleEmployee entity) { _resource = entity; }

        public Employee(Employee employee) { _resource = employee._resource; }

        public Employee(EmployeeArgs employee)
        {

            _resource.Id = employee.Id;
            _resource.OutletId = employee.EmployerId;
            _resource.Password = employee.Password;
            _resource.Username = employee.Username;
            _resource.Position = employee.Position;
            _resource.Status = employee.Status;
            _resource.Wage = employee.Wage;
            _resource.WageType = employee.WageType;

        }

        public override Elements.IElement<Data.Entities.PeopleEmployee> Save()
        {

            _resource.Id = Guid.NewGuid();

            using (var context = new Data.PizzaBoxDbContext())
            {

                context.Attach<Data.Entities.PeopleEmployee>(_resource);
                context.Add<Data.Entities.PeopleEmployee>(_resource);
                context.SaveChanges();

            }

            return new Employee(_resource);

        }

        public override void Delete()
        {

            using (var context = new Data.PizzaBoxDbContext())
            {

                context.Attach<Data.Entities.PeopleEmployee>(_resource);
                context.Remove<Data.Entities.PeopleEmployee>(_resource);
                context.SaveChanges();

            }

        }

        public override bool Uncommitted { get { return _resource.Id == Guid.Empty ? true : false; } }

        public override Guid Id { get { return _resource.Id; } }

        public Data.Entities.Outlet Employer { get { return _resource.Outlet; } set { _resource.Outlet = value; } }

        public Guid EmployerId { get { return _resource.OutletId; } set { _resource.OutletId = value; } }

        public Data.Entities.Person Information { get { return _resource.IdNavigation; } set { _resource.IdNavigation = value; } }

        public string Username { get { return _resource.Username; } set { _resource.Username = value; } }

        public string Password { get { return _resource.Password; } set { _resource.Password = value; } }

        public string Status { get { return _resource.Status; } set { _resource.Status = value; } }

        public string Position { get { return _resource.Position; } set { _resource.Position = value; } }

        public double Wage { get { return _resource.Wage; } set { _resource.Wage = value; } }

        public double WageType { get { return _resource.WageType; } set { _resource.WageType = value; } }

    }

}
