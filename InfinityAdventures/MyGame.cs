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

            VisualText TO = new VisualText(ScreenManager.Instance.CenterOfScreen, -10, "Font/IntroScreenFont", "Infinity\n   Adventures", Color.Wheat);
            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(TO);


            VisualImage player = new TestingObject()
            {
                Path = "playerAnimated",
                Position = new Vector2(500, 600),
                MoveSpeed = 100,
                Scale = new Vector2(2)
            };
            player.Animation.AmountOfFrames = new Vector2(2, 0);

            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(player);

            ScreenManager.Instance.CurrnetScreen.Cursor.Path = "cursor";
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }
        
    }
}
