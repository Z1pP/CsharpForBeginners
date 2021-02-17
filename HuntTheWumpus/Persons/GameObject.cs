using System;
using System.Collections.Generic;
using System.Text;
using static HuntTheWumpus.StartGame;

namespace HuntTheWumpus.Persons
{
    public abstract class GameObject
    {
        private string Name { get; set; }
        private byte Count { get; set; } = 1;
        private char SymbolPerson { get; set; }
        public Coordinates Coordinates { get; set; }
        public GameObject(string name, byte count, char symbl, Coordinates coordinates)
        {
            Name = name;
            Count = count;
            SymbolPerson = symbl;
            Coordinates = coordinates;
        }

        public string GetSymbolPerson() => SymbolPerson.ToString();

        public virtual void Move(Direction direction)
        {
            int x = 0;
            int y = 0;

            PlayMap playMap = new PlayMap();
            switch (direction)
            {
                case Direction.Up:
                    x = Coordinates.X;
                    y = Coordinates.Y - 1;
                    Coordinates = new Coordinates(x, y);
                    break;

                case Direction.Down:
                    x = Coordinates.X;
                    y = Coordinates.Y + 1;
                    Coordinates = new Coordinates(x, y);
                    break;

                case Direction.Left:
                    x = Coordinates.X - 1;
                    y = Coordinates.Y;
                    Coordinates = new Coordinates(x, y);
                    break;

                case Direction.Right:
                    x = Coordinates.X + 1;
                    y = Coordinates.Y;
                    Coordinates = new Coordinates(x, y);
                    break;
            }
            
            
            
        }
       
    }
}
