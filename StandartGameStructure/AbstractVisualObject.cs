using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace StandartGameStructure
{
    public abstract class AbstractVisualObject : IGameContent
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Alpha { get; set; }
        public Rectangle Rect { get; protected set; }

        protected Texture2D texture;
        protected ContentManager content;
        protected RenderTarget2D renderTarget;
        protected Vector2 origin;

        public AbstractVisualObject()
        {
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            Rect = Rectangle.Empty;
        }

        public abstract void LoadContent();

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            origin = new Vector2(Rect.Width / 2, Rect.Height / 2);

            if (texture != null)
                spriteBatch.Draw(texture, Position + origin, Rect, Color.White * Alpha, 0.0f, origin, Scale, SpriteEffects.None, 0.0f);
        }
    }
}
