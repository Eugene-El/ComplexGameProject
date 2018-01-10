using StandartGameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace InfinityAdventures
{
    class TestingObject : VisualImage
    {
        public TestingObject(Vector2 position, Vector2 scale, float rotation, float alpha, string path) : base(position, scale, rotation, alpha, path) { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Rotation += 1;
            Position = Position + new Vector2(-0.3f, + 0.2f); 
        }
    }
}
