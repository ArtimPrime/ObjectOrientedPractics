using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ObjectOrientedPractics.Model
{
    internal class Customer
    {

        private readonly int _id;
        private string _fullname;
        private string _address;
    public int Id { get { return _id; } }
        public string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, 200, "Fullname");

                _fullname = value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, 500, "Address");
                _address = value;
            }
        }
        public Customer()
        {
            _id = IdGenerator.GetNextId();
        }

        public Customer(string fullname, string adress)
        {
            FullName = fullname;
            Address = adress;
            _id = IdGenerator.GetNextId();
        }
    } 
}
