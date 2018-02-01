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
        public event EventHandler Click;

        private bool mouseOnButton;

        //

        public override void LoadContent()
        {
            base.LoadContent();
            Text.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Text.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle r = new Rectangle(
                (int)(Position.X - Origin.X * Scale.X ), 
                (int)(Position.Y - Origin.Y * Scale.Y ), 
                (int)(TextureSize.X / (Animation.AmountOfFrames.X + 1) * Scale.X ),
                (int)(TextureSize.Y / (Animation.AmountOfFrames.Y + 1) * Scale.Y ));

            if (r.Contains(Mouse.GetState().Position.ToVector2() / ScreenManager.Instance.WindowResolutionScaling))
            {
                if (!mouseOnButton)
                {
                    mouseOnButton = true;
                    MouseHover?.Invoke(this, new EventArgs());
                }
                if (InputManager.Instance.PrevMouseState.LeftButton == ButtonState.Pressed &&
                    InputManager.Instance.CurrentMouseState.LeftButton == ButtonState.Released)
                    Click?.Invoke(this, new EventArgs());
            }
            else if (mouseOnButton)
            {
                mouseOnButton = false;
                MouseOut?.Invoke(this, new EventArgs());
            }

            Text.Position = Position - Origin * Scale + TextureSize / (Animation.AmountOfFrames + new Vector2(1)) * Scale / new Vector2(2);

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
