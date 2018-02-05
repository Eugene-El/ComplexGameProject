using InfinityAdventures.GameContent.MyElements;
using Microsoft.Xna.Framework;
using StandartGameStructure;
using StandartGameStructure.GameElemetPaterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfinityAdventures.World.WorldGenerator;

namespace InfinityAdventures.GameContent.Screens
{
    public class GameScreen : MyScreen
    {
        public GameScreen() : base()
        {
            BasicPlayer bp = new BasicPlayer()
            {
                MoveSpeed = 200
            };
            ObjectsList.Add(bp);
            Camera.Folow(bp);

            Vector2 MapSize = new Vector2(512, 256);

            GenerateTiles(Generate((int)MapSize.X, (int)MapSize.Y));
            ScreenManager.Instance.AbsoluteResolution = MapSize * 32;
        }

        private void GenerateTiles(Map map)
        {
            List<VisualMultiPositionalImage> Tiles = new List<VisualMultiPositionalImage>()
            {
                new VisualMultiPositionalImage()
                {
                    Path = "Tile/Water",
                    OriginPosition = OriginPosition.LeftUpperCorner,
                    Animation = new Animator()
                    {
                        AmountOfFrames = new Vector2(3, 0),
                        SwitchTime = 180
                    }
                },
                new VisualMultiPositionalImage()
                {
                    Path = "Tile/Sand",
                    OriginPosition = OriginPosition.LeftUpperCorner
                },
                new VisualMultiPositionalImage()
                {
                    Path = "Tile/Grass",
                    OriginPosition = OriginPosition.LeftUpperCorner,
                    Animation = new Animator()
                    {
                        AmountOfFrames = new Vector2(1, 0),
                        SwitchTime = 180
                    }
                },
                new VisualMultiPositionalImage()
                {
                    Path = "Tile/Swamp",
                    OriginPosition = OriginPosition.LeftUpperCorner,
                    Animation = new Animator()
                    {
                        AmountOfFrames = new Vector2(1, 0),
                        SwitchTime = 180
                    }
                }
            };


            for (int j = 0; j < map.Height; j++)
            {
                for (int i = 0; i < map.Width; i++)
                {
                    Tiles[map.IntMap[j, i]].Positions.Add(new Vector2(i*32, j*32));
                    
                }
            }

            ObjectsList.AddRange(Tiles);
        }

    }
}
