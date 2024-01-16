using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Demo_DBSlide.Entities
{
    public abstract class Person
    {
        public string First_name { get; private set;}
        public string Last_name { get; private set; }

        public Person(string first_name, string last_name)
        {
            First_name = first_name;
            Last_name = last_name;
        }
    }
}
