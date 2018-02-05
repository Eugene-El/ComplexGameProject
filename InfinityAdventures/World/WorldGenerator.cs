using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityAdventures.World
{
    public static class WorldGenerator
    {
        public static Random Random { get; set; }
        public static List<Tile> Tiles { get; }
        

        static WorldGenerator()
        {
            Tiles = new List<Tile>
            {
                new Tile("Water", Color.Blue),
                new Tile("Sand", Color.LightGoldenrodYellow),
                new Tile("Grass", Color.LightGreen),
                new Tile("Swamp", Color.DarkGreen),
            };
        }


        public static Map Generate(int width, int height)
        {
            if (Random == null)
                Random = new Random();

            Map map = new Map(width, height);

            for (int i = 1; i < 8; i ++)
            {
                for (int j = 1; j < 8; j ++)
                {
                    map.IntMap[height / 8 * j, width / 8 * i] = Random.Next(Tiles.Count);
                }
            }
            

            MakeFractal(width/16, height/16, map);

            return map;
        }

        private static void MakeFractal(int Wstep, int Hstep, Map map)
        {
            for (int j = 0; j < map.Height; j += Hstep)
            {
                for (int i = 0; i < map.Width; i += Wstep)
                {
                    int x = i + (Random.Next(2) == 0 ? 0 : Wstep);
                    int y = j + (Random.Next(2) == 0 ? 0 : Hstep);

                    x = x / (Wstep * 2) * Wstep * 2;
                    y = y / (Hstep * 2) * Hstep * 2;

                    x = x % map.Width;
                    y = y % map.Height;

                    map.IntMap[j, i] = map.IntMap[y, x];
                }
            }

            if (Wstep > 1 || Hstep > 1)
            {
                if (Wstep == 1) Wstep = 2;
                if (Hstep == 1) Hstep = 2;
                MakeFractal(Wstep / 2, Hstep / 2, map);
            }
        }



        public static Bitmap VisualizeMap(Map map)
        {
            Bitmap mapBitmap = new Bitmap(map.Width, map.Height);
            for (int j = 0; j < map.Height; j++)
            {
                for (int i = 0; i < map.Width; i++)
                {
                    mapBitmap.SetPixel(i, j, Tiles.Find((x) => x.ID == map.IntMap[j, i]).Color);
                }
            }

            return mapBitmap;
        }

        public struct Map
        {
            public int[,] IntMap { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public Map(int width, int height)
            {
                Width = width;
                Height = height;
                IntMap = new int[Height, Width];
            }
        }

        public struct Tile
        {
            private static int tilesCounter;
            public int ID { get; }
            public string Name { get; }
            public Color Color { get; }

            public Tile(string name, Color color)
            {
                ID = tilesCounter++;
                Name = name;
                Color = color;
            }
        }
    }
}
