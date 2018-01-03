using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StandartGameStructure
{
    public class VisualObject : GameObject
    {
        public Image Image { get; set; }

        public VisualObject()
        {
            Image = new Image();
        }

        public override void LoadContent()
        {
            Image.LoadContent();
        }

        public override void UnloadContent()
        {
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Image.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

    }
}
