using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace StandartGameStructure
{
    public abstract class AbstractVisualObject : IGameContent
    {
        public static uint ObjectsCount { get; private set; }

        public uint ID { get; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Alpha { get; set; }
        public Rectangle Rect { get; protected set; }
        
        public float RotationInRadiance { get; set; }
        public float Rotation
        {
            get
            {
                return RotationInRadiance * 180 / MathHelper.Pi;
            }
            set
            {
                RotationInRadiance = value * MathHelper.Pi / 180f;
            }
        }


        protected Texture2D texture;
        protected ContentManager content;
        protected RenderTarget2D renderTarget;
        protected Vector2 origin;

        public AbstractVisualObject(Vector2 position, Vector2 scale, Rectangle rect, float rotation, float alpha)
        {
            Position = position;
            Scale = scale;
            Rect = rect;
            Alpha = alpha;
            Rotation = rotation;

            ID = ++ObjectsCount;
        }
        public AbstractVisualObject(Vector2 position, Vector2 scale, float rotation = 0, float alpha = 1.0f) : this(position, scale, Rectangle.Empty, rotation, alpha) { }
        public AbstractVisualObject(Vector2 position, float rotation) : this(position, Vector2.One, rotation) { }
        public AbstractVisualObject(Vector2 position) : this(position, Vector2.One) { }
        public AbstractVisualObject() : this(Vector2.Zero) { }


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
                spriteBatch.Draw(texture, Position, Rect, Color.White * Alpha, RotationInRadiance, origin, Scale, SpriteEffects.None, 0.0f);
        }
    }
}
