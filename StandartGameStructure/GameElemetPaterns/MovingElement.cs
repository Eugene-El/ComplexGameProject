using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartGameStructure.GameElemetPaterns
{
    public class MovingElement : VisualImage
    {
        public Vector2 Velocity;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position += Velocity;
        }
    }
}
