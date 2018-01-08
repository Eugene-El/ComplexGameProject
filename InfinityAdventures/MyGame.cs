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
            ScreenManager.Instance.CurrnetScreen.Background.Path = "scorpion";

            //VisualImage player = new VisualImage();
            //player.Path = "player";
            //player.Position = new Vector2(100, 100);
            //ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(player);

            VisualText TO = new VisualText("Font/IntroScreenFont");
            TO.Text = "Infinity\n   Adventures";
            TO.Position = new Vector2(Width/2, Height/2);
            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(TO);
            TO.Color = Color.White;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }
        
    }
}
