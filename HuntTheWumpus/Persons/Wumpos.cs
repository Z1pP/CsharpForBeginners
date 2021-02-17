using System;
using System.Collections.Generic;
using System.Text;
using static HuntTheWumpus.StartGame;
namespace HuntTheWumpus.Persons
{
    public class Wumpos : GameObject
    {
        public bool IsAlive { get; set; }
        public Wumpos(Coordinates coordinates) :base("Wumpos",1, 'W' ,coordinates)
        {
            IsAlive = true;
        }
        public override void Move(Direction direction)
        {
            base.Move(direction);
        }
    }
}
