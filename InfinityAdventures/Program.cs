using System;

namespace InfinityAdventures
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            World.WorldGenerator.VisualizeMap(World.WorldGenerator.Generate(32, 32)).Save("MAP.bmp");

            using (var game = new MyGame())
                game.Run();
        }
    }
}
