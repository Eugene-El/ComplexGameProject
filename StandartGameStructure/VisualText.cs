using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace StandartGameStructure
{
    public class VisualText : AbstractVisualObject
    {
        public string Text { get; set; }
        public string Font { get; set; }
        public Color Color { get; set; }
        
        private SpriteFont spriteFont;

        public VisualText(string font) : base()
        {
            Text = String.Empty;
            Font = font;
            Color = Color.White;
        }

        //

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

        //
    }
}
