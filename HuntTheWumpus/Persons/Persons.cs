using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus.Persons
{
    public abstract class Person
    {
        public string Name { get; set; }
        public  byte Count { get; set; }
        public char SymbolPerson { get; set; }
        public Person(string name,byte count,char symbl)
        {
            Name = name;
            Count = count;
            SymbolPerson = symbl;
        }
    }
}
