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
        public Background() : base() { }
        public Background(string path) : base(path) { }

        public override void LoadContent()
        {
            base.LoadContent();
            Position = ScreenManager.Instance.CenterOfScreen;
            Scale = ScreenManager.Instance.AbsoluteResolution / new Vector2(TextureSize.X, TextureSize.Y);
        }
    }
}
