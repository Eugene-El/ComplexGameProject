using System;
using InfinityAdventures.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StandartGameStructure;
using StandartGameStructure.GameElemetPaterns;

namespace InfinityAdventures
{
    public class MyGame : BasicGame
    {
        public MyGame() : base()
        {
            ScreenManager.Instance.AbsoluteResolution = new Vector2(1920, 1080);
            ScreenManager.Instance.Dimensions = ScreenManager.Instance.StandartResolutions[1];
            ScreenManager.Instance.NextScreen = new MenuScreen();
            ScreenManager.Instance.TransferScreen();
            ScreenManager.Instance.ImageTranferStep = 0.03f;
            ScreenManager.Instance.TransferImage = new Background("Background/Black");

            //Window.AllowUserResizing = true;
            //graphics.ToggleFullScreen();
            
        }

        protected override void ExitGame(object sender, EventArgs args)
        {
            Exit();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }
        

    }
}
