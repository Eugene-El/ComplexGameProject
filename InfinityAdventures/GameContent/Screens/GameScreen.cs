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
                MoveSpeed = 200,
                Path = "player"
            };
            ObjectsList.Add(bp);
            Camera.Folow(bp);

            Vector2 MapSize = new Vector2(64, 64);

            GenerateTiles(Generate((int)MapSize.X, (int)MapSize.Y));
            ScreenManager.Instance.AbsoluteResolution = MapSize * 32;
        }

        private void GenerateTiles(Map map)
        {
            List<VisualImage> Tiles = new List<VisualImage>();

            for (int j = 0; j < map.Height; j++)
            {
                for (int i = 0; i < map.Width; i++)
                {
                    switch (map.IntMap[j, i])
                    {
                        case 0:
                            Tiles.Add(new VisualImage()
                            {
                                Path = "Tile/Water",
                                OriginPosition = OriginPosition.LeftUpperCorner,
                                Position = new Vector2(32 * i, 32 * j),
                                Animation = new Animator()
                                {
                                    AmountOfFrames = new Vector2(3, 0),
                                    SwitchTime = 180
                                }
                            });
                            break;

                        case 1:
                            Tiles.Add(new VisualImage()
                            {
                                Path = "Tile/Sand",
                                OriginPosition = OriginPosition.LeftUpperCorner,
                                Position = new Vector2(32 * i, 32 * j),
                            });
                            break;

                        case 2:
                            Tiles.Add(new VisualImage()
                            {
                                Path = "Tile/Grass",
                                OriginPosition = OriginPosition.LeftUpperCorner,
                                Position = new Vector2(32 * i, 32 * j),
                                Animation = new Animator()
                                {
                                    AmountOfFrames = new Vector2(1, 0),
                                    SwitchTime = 180
                                }
                            });
                            break;

                        case 3:
                            Tiles.Add(new VisualImage()
                            {
                                Path = "Tile/Swamp",
                                OriginPosition = OriginPosition.LeftUpperCorner,
                                Position = new Vector2(32 * i, 32 * j),
                                Animation = new Animator()
                                {
                                    AmountOfFrames = new Vector2(1, 0),
                                    SwitchTime = 180
                                }
                            });
                            break;
                    }
                    
                }
            }

            ObjectsList.AddRange(Tiles);
        }

    }
}
