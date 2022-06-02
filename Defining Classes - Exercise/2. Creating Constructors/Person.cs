﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person(int age)
        {
            this.Name = "No name";
            this.Age = age;
        }
        public Person(string n, int a)
        {
            this.Name = n;
            this.Age = a;
        }

    }
}
