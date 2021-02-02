using System;
using System.Collections.Generic;
using System.Text;
using HuntTheWumpus.Persons;

namespace HuntTheWumpus
{
    public class StartGame
    {
        public static void Start()
        {
            Console.Write("Укажите размер карты: ");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine($"Укажите число Wumpus-ов");
            Wumpos wumpol = new Wumpos("Wumpul", byte.Parse(Console.ReadLine()),'#');
            Console.WriteLine($"Укажите число Мышей");
            Bat bat = new Bat("Batman", byte.Parse(Console.ReadLine()),'0');
            User user = new User();

            while (true)
            {
                Logic(size,user,bat,wumpol);
                Console.Clear();
            }
        }
        
    }
}
