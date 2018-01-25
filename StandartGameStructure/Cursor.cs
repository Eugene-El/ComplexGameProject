using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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
            
            Position =  Mouse.GetState().Position.ToVector2();
        }
    }
}
