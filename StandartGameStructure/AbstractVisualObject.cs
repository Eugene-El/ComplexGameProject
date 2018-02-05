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
        public Rectangle Rect { get; set; }
        
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

        public Vector2 TextureSize
        {
            get
            {
                if (texture != null)
                    return new Vector2(texture.Width, texture.Height);
                return Vector2.Zero;
            }
        }

        //

        private Vector2 origin;
        public OriginPosition OriginPosition { get; set; }
        public Vector2 Origin
        {
            get
            {
                return origin;
            }
            set
            {
                OriginPosition = OriginPosition.CustomPosition;
                origin = value;
            }
        }

        //

        public AbstractVisualObject(Vector2 position, Vector2 scale, Rectangle rect, float rotation, float alpha)
        {
            Position = position;
            Scale = scale;
            Rect = rect;
            Alpha = alpha;
            Rotation = rotation;
            OriginPosition = OriginPosition.Center;

            ID = ++ObjectsCount;
        }
        public AbstractVisualObject(Vector2 position, Vector2 scale, float rotation = 0, float alpha = 1.0f) : this(position, scale, Rectangle.Empty, rotation, alpha) { }
        public AbstractVisualObject(Vector2 position, float rotation) : this(position, Vector2.One, rotation) { }
        public AbstractVisualObject(Vector2 position) : this(position, Vector2.One) { }
        public AbstractVisualObject() : this(Vector2.Zero) { }


        public abstract void LoadContent();

        public virtual void UnloadContent()
        {
            if (content != null)
            {
                content.Unload();
                content.Dispose();
            }
            if (texture != null)
                texture.Dispose();
            if (renderTarget != null)
                renderTarget.Dispose();
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            OriginStabilization();

            if (texture != null)
                spriteBatch.Draw(texture, Position * ScreenManager.Instance.WindowResolutionScaling, Rect, Color.White * Alpha, RotationInRadiance, Origin, Scale * ScreenManager.Instance.WindowResolutionScaling, SpriteEffects.None, 0.0f);

        }

        protected void OriginStabilization()
        {
            switch (OriginPosition)
            {
                case OriginPosition.LeftUpperCorner:
                    origin = Vector2.Zero;
                    break;

                case OriginPosition.UpperSide:
                    origin = new Vector2(Rect.Width / 2, 0);
                    break;

                case OriginPosition.RightUpperCorner:
                    origin = new Vector2(Rect.Width, 0);
                    break;

                case OriginPosition.LeftSide:
                    origin = new Vector2(0, Rect.Height / 2);
                    break;

                case OriginPosition.Center:
                    origin = new Vector2(Rect.Width / 2, Rect.Height / 2);
                    break;

                case OriginPosition.RightSide:
                    origin = new Vector2(Rect.Width, Rect.Height / 2);
                    break;

                case OriginPosition.LeftLowerCorner:
                    origin = new Vector2(0, Rect.Height);
                    break;

                case OriginPosition.LowerSide:
                    origin = new Vector2(Rect.Width / 2, Rect.Height);
                    break;

                case OriginPosition.RightLowerCorner:
                    origin = new Vector2(Rect.Width, Rect.Height);
                    break;
            }

        }
    }
}
