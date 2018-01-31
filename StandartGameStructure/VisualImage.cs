using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace StandartGameStructure
{
    public class VisualImage : AbstractVisualObject
    {
        public string Path { get; set; }
        public Animator Animation { get; set; }


        public VisualImage(string path) : base() { Initialize(path); }
        public VisualImage() : this(String.Empty) { }
        public VisualImage(Vector2 position, Vector2 scale, float rotation, float alpha, string path) : base(position, scale, rotation, alpha) { Initialize(path); }
        public VisualImage(Vector2 position, string path) : base(position) { Initialize(path); }

        private void Initialize(string path)
        {
            Path = path;
            Animation = new Animator();
        }

        //

        public override void LoadContent()
        {
            if (content != null)
                content.Dispose();
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");

            if (Path != String.Empty)
                texture = content.Load<Texture2D>(Path);

            if (texture != null)
            {
                Rect = new Rectangle(0, 0, texture.Width, texture.Height);

                if (renderTarget != null)
                    renderTarget.Dispose();
                renderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, texture.Width, texture.Height);
                
                ScreenManager.Instance.GraphicsDevice.SetRenderTarget(renderTarget);
                ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);

                ScreenManager.Instance.SpriteBatch.Begin();
                if (texture != null)
                    ScreenManager.Instance.SpriteBatch.Draw(texture, Vector2.Zero, Color.White);
                ScreenManager.Instance.SpriteBatch.End();

                texture = renderTarget;

                ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
            }


            VisualImage vi = this;
            Animation.LoadContent(ref vi);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Animation.Update(gameTime);
        }

        //
    }
}
