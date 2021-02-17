using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus.Persons
{
    public class Bat:GameObject
    {
        public Bat(Coordinates coordinates) : base("Bat", 1, 'B',coordinates) { }
    }
}
