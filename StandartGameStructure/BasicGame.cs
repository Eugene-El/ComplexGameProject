using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartGameStructure
{
    public class BasicGame : Game
    {
        public static int Width;
        public static int Height;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public BasicGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();

        }

        protected override void Update(GameTime gameTime)
        {
            ScreenManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Coral);

            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void SetWindowSize(int width, int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
            Width = width;
            Height = height;
        }

    }
}
