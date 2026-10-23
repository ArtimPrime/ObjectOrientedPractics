using System; // эти все using можно просто удалить если он попросит
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPractics.Model
{
    // internal значит, что класс виден только внутри своего проекта
    internal class Person
    {
        // Это приватные поля (как раз в термине Инкапсуляция упоминается про сокрытие реализации, это вот про них)
        private string _name;
        private int _age;

        // Это свойства
        // get - это метод, который возвращает значение поля
        // set - это метод, который записывает новое значение в поле
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

        // Это конструктор класса Person, который принимает имя и возраст в качестве параметров
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }
}
