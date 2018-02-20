using StandartGameStructure.GameElemetPaterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using StandartGameStructure;

namespace InfinityAdventures.GameContent.MyElements
{
    public class MyPlayer : BasicPlayer
    {
        private Vector2 border;
        public Vector2 Border
        {
            get
            {
                return border;
            }
            set
            {
                border = value;// * ScreenManager.Instance.WindowResolutionScaling;
            }
        }

        public MyPlayer() : base()
        {
            Border = new Vector2();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float zoom = ScreenManager.Instance.CurrnetScreen.Camera.Zoom;
            Vector2 border = ScreenManager.Instance.AbsoluteResolution / 2 * (1 / zoom);



            if (Position.X < border.X)
                Position = new Vector2(border.X, Position.Y);
            else if (Position.X > Border.X - border.X)
                Position = new Vector2(Border.X - border.X, Position.Y);

            if (Position.Y < border.Y)
                Position = new Vector2(Position.X, border.Y);
            else if (Position.Y > Border.Y - border.Y)
                Position = new Vector2(Position.X, Border.Y - border.Y);


            //if (Position.X * ScreenManager.Instance.WindowResolutionScaling.X < 0)
            //    Position = new Vector2(0, Position.Y);
            //else if (Position.X * ScreenManager.Instance.WindowResolutionScaling.X > Border.X)
            //    Position = new Vector2(Border.X, Position.Y);
            //if (Position.Y * ScreenManager.Instance.WindowResolutionScaling.Y < 0)
            //    Position = new Vector2(Position.X, 0);
            //else if (Position.Y * ScreenManager.Instance.WindowResolutionScaling.Y > Border.Y)
            //    Position = new Vector2(Position.X, Border.Y);
        }
    }
}
