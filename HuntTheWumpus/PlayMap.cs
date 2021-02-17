using System;
using System.Collections.Generic;
using System.Text;
using HuntTheWumpus.Persons;

namespace HuntTheWumpus
{
    public class PlayMap
    {
        private string[,] Map { get; set; }
        public byte MapSize { get; }
        private GameObject[] GameObjects { get; set; }
        private uint GameObjectCount { get; set; }
        public PlayMap()
        {

        }
        public PlayMap(byte mapSize)
        {
            MapSize = mapSize;
            CreateMap();
        }


        public void CreateMap()
        {
            string[,] map = new string[MapSize, MapSize];
            GameObjects = new GameObject[100];
            GameObjectCount = 0;

            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    map[j,i] = "[ ]";
                    Console.Write(map[j, i]);
                }
                Console.WriteLine();
            }

            this.Map = map;
        }


        public void AddGameObject(GameObject gameObject)
        {
            Coordinates coordinates = gameObject.Coordinates;
            Map[coordinates.X, coordinates.Y] = $"[{gameObject.GetSymbolPerson()}]";
            GameObjects[GameObjectCount] = gameObject;
            GameObjectCount++;
        }


        public string[,] ShowMap()
        {
            return Map;
        }


        public string[,] RenderMap()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    Map[j, i] = "[ ]";
                }
            }

            for (int i = 0; i < GameObjectCount; i++)
            {
                GameObject gameObject = GameObjects[i];
                Coordinates coordinates = gameObject.Coordinates;

                if(coordinates.X >= 0 && coordinates.X < MapSize &&
                    coordinates.Y >= 0 && coordinates.Y < MapSize)
                {
                    int x = coordinates.X;
                    int y = coordinates.Y;
                    Map[x, y] = $"[{gameObject.GetSymbolPerson()}]";
                }
                else
                {
                    coordinates = FixMove(coordinates);
                    gameObject.Coordinates = coordinates;
                    int x = coordinates.X;
                    int y = coordinates.Y;
                    Map[x, y] = $"[{gameObject.GetSymbolPerson()}]";
                }
                
            }

            return Map;
        }
        private Coordinates FixMove(Coordinates coordinates)
        {
            if (coordinates.X < 0)
                coordinates.X = MapSize - 1;
            else if (coordinates.X >= MapSize)
                coordinates.X = 0;
            else if (coordinates.Y < 0)
                coordinates.Y = MapSize - 1;
            else if (coordinates.Y >= MapSize)
                coordinates.Y = 0;

            return new Coordinates(coordinates.X,coordinates.Y);
        }
    }
}
