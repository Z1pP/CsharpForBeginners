using System;
using System.Collections.Generic;
using System.Text;
using HuntTheWumpus.Persons;

namespace HuntTheWumpus
{
    public class StartGame
    {
        public enum Direction
        {
            Up=1,
            Down=2,
            Right=3,
            Left=4
        }
        public void Start()
        {
            PlayMap playZone = new PlayMap(3);

            User user = new User(new Coordinates(2,0));
            Wumpos wumpos = new Wumpos(new Coordinates(5, 2));

            playZone.AddGameObject(user);
            //playZone.AddGameObject(wumpos);
            //playZone.AddGameObject(new Bat(new Coordinates(1, 3)));
            //playZone.AddGameObject(new Bat(new Coordinates(2, 5)));

            var values = Enum.GetValues(typeof(Direction));
            Random random = new Random();
            Direction direction;

            while (user.IsAlive && wumpos.IsAlive)
            {
                Console.Clear();
                PrintMap(playZone.RenderMap());

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            user.Move(Direction.Up);

                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            user.Move(Direction.Down);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            user.Move(Direction.Right);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            user.Move(Direction.Left);
                            break;
                        }
                }

                direction = (Direction)values.GetValue(random.Next(values.Length));
                wumpos.Move(direction);

                if (keyInfo.Key == ConsoleKey.Escape)
                    break;


                if (!user.IsAlive)
                {
                    Console.WriteLine("Вы выйграли!!!");
                    break;
                }                   
                if (!wumpos.IsAlive)
                {
                    Console.WriteLine("Вы проиграли...");
                    break;
                }
            }
        }

        public void PrintMap(string[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[x, y]);
                }

                Console.WriteLine();
            }
        }

    }
}
