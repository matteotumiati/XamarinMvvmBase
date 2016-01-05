using System;
using System.Collections.Generic;
using System.Text;

namespace TestXamarin2.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Person(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }
    }
}
