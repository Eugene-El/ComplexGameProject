using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartGameStructure
{
    public class Background : VisualImage
    {

        public override void LoadContent()
        {
            base.LoadContent();
            Position = ScreenManager.Instance.CenterOfScreen;
            Scale = new Vector2(ScreenManager.Instance.Width / TextureSize.X, ScreenManager.Instance.Height / TextureSize.Y);
        }
    }
}
