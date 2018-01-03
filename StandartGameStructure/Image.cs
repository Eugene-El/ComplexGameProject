using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartGameStructure
{
    public class Image : IVisualContent
    {
        public Texture2D Texture { get; set; }
        public string Path { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Alpha { get; set; }
        public Rectangle Rect { get; set; }

        private ContentManager content;
        private RenderTarget2D renderTarget;
        private Vector2 origin;

        public Image()
        {
            Path = String.Empty;
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            Rect = Rectangle.Empty;
        }


        //

        public void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");

            if (Path != String.Empty)
                Texture = content.Load<Texture2D>(Path);

            if (Texture != null)
            {
                Rect = new Rectangle(0, 0, Texture.Width, Texture.Height);

                renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, Texture.Width, Texture.Height);


                ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);
                ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);

                ScreenManager.Instance.SpriteBatch.Begin();
                if (Texture != null)
                    ScreenManager.Instance.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);
                ScreenManager.Instance.SpriteBatch.End();

                Texture = renderTarget;

                ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
            }
        }

        public void UnloadContent()
        {
            content.Unload();
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            origin = new Vector2(Rect.Width / 2, Rect.Height / 2);

            if (Texture != null)
                spriteBatch.Draw(Texture, Position + origin, Rect, Color.White * Alpha, 0.0f, origin, Scale, SpriteEffects.None, 0.0f);
        }

        //
    }
}
