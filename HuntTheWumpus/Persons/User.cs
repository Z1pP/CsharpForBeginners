using System;
using System.Collections.Generic;
using System.Text;

namespace HuntTheWumpus.Persons
{
    public class User : GameObject
    {
        public bool IsAlive { get; set; }
        public User (Coordinates coordinates) : base("User",1,'@',coordinates)
        {
            IsAlive = true;
        }

        public override void Move(StartGame.Direction direction)
        {
            base.Move(direction);
        }
    }
}
