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
            CurrnetScreen.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrnetScreen.Draw(spriteBatch);

        }

        //
        

    }
}
