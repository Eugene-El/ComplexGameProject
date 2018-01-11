using StandartGameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using StandartGameStructure.GameElemetPaterns;

namespace InfinityAdventures
{
    class TestingObject : BasicPlayer
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Position.X > ScreenManager.Instance.Dimensions.X)
                Position -= new Vector2(ScreenManager.Instance.Dimensions.X,0);
            else if (Position.X < 0)
                Position += new Vector2(ScreenManager.Instance.Dimensions.X, 0);
            else if (Position.Y > ScreenManager.Instance.Dimensions.Y)
                Position -= new Vector2(0, ScreenManager.Instance.Dimensions.Y);
            else if (Position.Y < 0)
                Position += new Vector2(0, ScreenManager.Instance.Dimensions.Y);

            Rotation += 1;
        }
    }
}
