using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StandartGameStructure
{
    public class Cursor : VisualImage
    {
        public Cursor(string path) : base(path) { OriginPosition = OriginPosition.LeftUpperCorner; }
        public Cursor() : base() { OriginPosition = OriginPosition.LeftUpperCorner; }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            Position = (Mouse.GetState().Position.ToVector2() * (1 / ScreenManager.Instance.CurrnetScreen.Camera.Zoom) + ScreenManager.Instance.CurrnetScreen.Camera.Position) / ScreenManager.Instance.WindowResolutionScaling;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            OriginStabilization();

            if (texture != null)
                spriteBatch.Draw(texture, Position * ScreenManager.Instance.WindowResolutionScaling, Rect, Color.White * Alpha, RotationInRadiance, Origin, Scale * ScreenManager.Instance.WindowResolutionScaling * (1 / ScreenManager.Instance.CurrnetScreen.Camera.Zoom), SpriteEffects.None, 0.0f);

        }
    }
}
