using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace StandartGameStructure
{
    public class TextObject : GameObject
    {
        public string Text { get; set; }
        public string Font { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Alpha { get; set; }
        public Color Color { get; set; }
        public Rectangle Rect { get; private set; }

        private ContentManager content;
        private SpriteFont spriteFont;
        private RenderTarget2D renderTarget;
        private Texture2D texture;
        private Vector2 origin;

        public TextObject()
        {
            Text = String.Empty;
            Font = "Font/mainFont";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            Rect = Rectangle.Empty;
            Color = Color.White;
        }

        public override void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");

            spriteFont = content.Load<SpriteFont>(Font);

            Rect = new Rectangle(0, 0, (int)spriteFont.MeasureString(Text).X, (int)spriteFont.MeasureString(Text).Y);

            renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int)spriteFont.MeasureString(Text).X, (int)spriteFont.MeasureString(Text).Y);

            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);

            ScreenManager.Instance.SpriteBatch.Begin();
            ScreenManager.Instance.SpriteBatch.DrawString(spriteFont, Text, Vector2.Zero, Color);
            ScreenManager.Instance.SpriteBatch.End();

            texture = renderTarget;

            ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
        }

        public override void UnloadContent()
        {
            content.Unload();
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            origin = new Vector2(Rect.Width / 2, Rect.Height / 2);

            spriteBatch.Draw(texture, Position + origin, Rect, Color.White * Alpha, 0.0f, origin, Scale, SpriteEffects.None, 0.0f);
        }

    }
}
