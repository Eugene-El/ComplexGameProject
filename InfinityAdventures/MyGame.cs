using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StandartGameStructure;

namespace InfinityAdventures
{
    public class MyGame : BasicGame
    {
        public MyGame()
        {
            SetWindowSize(1280, 720);
            VisualObject player = new VisualObject();
            player.Image.Path = "player";
            player.Image.Position = new Vector2(100, 100);
            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(player);

            TextObject TO = new TextObject();
            TO.Text = "Hello world!";
            TO.Position = new Vector2(200, 100);
            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(TO);
            TO.Color = Color.Black;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }
        
    }
}
