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
            Position = new Vector2(BasicGame.Width/2, BasicGame.Height/2);
            Scale = new Vector2(BasicGame.Width / (float)Rect.Width, BasicGame.Height / (float)Rect.Height);
        }
    }
}
