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

        public VisualText(string font, string text, Color color) : base() { Initialize(font, text, color); }
        public VisualText(string font, string text) : this(font, text, Color.White) { }
        public VisualText(string font) : this(font, String.Empty) { }
        public VisualText(Vector2 position, Vector2 scale, float rotation, float alpha, string font, string text, Color color) : base(position, scale, rotation, alpha) { Initialize(font, text, color); }
        public VisualText(Vector2 position, string font, string text, Color color) : base(position) { Initialize(font, text, color); }
        public VisualText(Vector2 position, float rotation, string font, string text, Color color) : base(position, rotation) { Initialize(font, text, color); }

        private void Initialize(string font, string text, Color color)
        {
            Text = text;
            Font = font;
            Color = color;
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
