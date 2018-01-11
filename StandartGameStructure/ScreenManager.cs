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
    public class ScreenManager
    {
        // Singleton

        private static ScreenManager instance;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        private ScreenManager()
        {
            CurrnetScreen = new Screen();
        }

        //

        // Window size changing

        private int width, height;
        public Vector2 Dimensions
        {
            get
            {
                return new Vector2(Width, Height);
            }
            set
            {
                Width = (int)value.X;
                Height = (int)value.Y;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                WindowSizeChanged?.Invoke(this, new EventArgs());
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                WindowSizeChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler WindowSizeChanged;


        //

        public Vector2 CenterOfScreen { get { return Dimensions / 2; } }

        public Screen CurrnetScreen { get; set; }

        public ContentManager Content { get; private set; }

        public GraphicsDevice GraphicsDevice { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        //

        public void LoadContent(ContentManager content)
        {
            Content = new ContentManager(content.ServiceProvider, "Content");
            
            CurrnetScreen.LoadContent();
        }

        public void UnloadContent()
        {
            CurrnetScreen.UnloadContent();

        }

        public void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
            CurrnetScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrnetScreen.Draw(spriteBatch);

        }

        //
        

    }
}
