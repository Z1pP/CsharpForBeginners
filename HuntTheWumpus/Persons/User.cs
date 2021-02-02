using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus.Persons
{
    public class User : Person
    {
        public User(string Name="User",byte Count = 1, char symbl = '@') :base(Name,Count, symbl)
        {

        }

    }
}
