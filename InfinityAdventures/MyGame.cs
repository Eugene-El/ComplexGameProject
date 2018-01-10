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
            ScreenManager.Instance.Dimensions = new Vector2(1280, 720);
            ScreenManager.Instance.CurrnetScreen.Background.Path = "scorpion";

            VisualImage player = new VisualImage(new Vector2(1200, 50), new Vector2(3), 180, 1.0f, "player");
            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(player);

            VisualText TO = new VisualText(ScreenManager.Instance.CenterOfScreen, -10, "Font/IntroScreenFont", "Infinity\n   Adventures", Color.Wheat);
            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(TO);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }
        
    }
}
