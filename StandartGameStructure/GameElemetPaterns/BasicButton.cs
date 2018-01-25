using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StandartGameStructure.GameElemetPaterns
{
    public class BasicButton : VisualImage
    {
        public VisualText Text { get; set; }


        public BasicButton() : base()
        {
            Animation.Animate = false;
        }

        // Events

        public event EventHandler MouseHover;
        public event EventHandler MouseOut;
        public event EventHandler MousePressed;

        private bool mouseOnButton;

        //

        public override void LoadContent()
        {
            base.LoadContent();
            Text.LoadContent();
            Text.Position = Position;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Text.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle r = new Rectangle((int)(Position.X-TextureSize.X/2), (int)(Position.Y- TextureSize.Y / 2), (int)TextureSize.X, (int)TextureSize.Y);
            if (r.Contains(Mouse.GetState().Position))
            {
                if (!mouseOnButton)
                {
                    mouseOnButton = true;
                    MouseHover?.Invoke(this, new EventArgs());
                }
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    MousePressed?.Invoke(this, new EventArgs());
            }
            else if (mouseOnButton)
            {
                mouseOnButton = false;
                MouseOut?.Invoke(this, new EventArgs());
            }

            base.Update(gameTime);
            Text.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Text.Draw(spriteBatch);
        }
    }
}
