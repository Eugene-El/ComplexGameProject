using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace StandartGameStructure
{
    public class VisualMultiPositionalImage : VisualImage
    {
        public List<Vector2> Positions { get; set; }

        public VisualMultiPositionalImage() : base()
        {
            Positions = new List<Vector2>();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            OriginStabilization();

            if(texture != null)
                foreach(Vector2 pos in Positions)
                    spriteBatch.Draw(texture, (Position + pos) * ScreenManager.Instance.WindowResolutionScaling, Rect, Color.White * Alpha, RotationInRadiance, Origin, Scale * ScreenManager.Instance.WindowResolutionScaling, SpriteEffects.None, 0.0f);

        }
    }
}
