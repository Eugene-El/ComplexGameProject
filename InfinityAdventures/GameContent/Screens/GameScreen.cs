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
            Vector2 MapSize = new Vector2(512, 256);

            GenerateTiles(Generate((int)MapSize.X, (int)MapSize.Y));


            MyPlayer bp = new MyPlayer()
            {
                MoveSpeed = 1200,
                Border = new Vector2(MapSize.X*32, MapSize.Y*32),
                //Path = "player",
                //Scale = new Vector2(2)

            };
            ObjectsList.Add(bp);
            Camera.Folow(bp);

            ObjectsList.AddRange(new List<VisualImage>() {
                new VisualImage()
                {
                    Path = "player",
                    OriginPosition = OriginPosition.LeftUpperCorner
                },
                new VisualImage()
                {
                    Path = "player",
                    Position = new Vector2(MapSize.X*32, 0),
                    OriginPosition = OriginPosition.RightUpperCorner
                },
                new VisualImage()
                {
                    Path = "player",
                    Position = new Vector2(0, MapSize.Y*32),
                    OriginPosition = OriginPosition.LeftLowerCorner
                },
                new VisualImage()
                {
                    Path = "player",
                    Position = new Vector2(MapSize.X*32, MapSize.Y*32),
                    OriginPosition = OriginPosition.RightLowerCorner
                }
            });
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

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.CurrentMouseState.ScrollWheelValue > InputManager.Instance.PrevMouseState.ScrollWheelValue)
                Camera.Zoom += 0.1f;
            else if (InputManager.Instance.CurrentMouseState.ScrollWheelValue < InputManager.Instance.PrevMouseState.ScrollWheelValue)
                Camera.Zoom -= 0.1f;

            base.Update(gameTime);
        }

    }
}
