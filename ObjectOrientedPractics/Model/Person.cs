using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPractics.Model
{
    internal class Person
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }


        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }
}
