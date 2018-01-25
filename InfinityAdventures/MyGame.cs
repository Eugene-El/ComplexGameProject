using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StandartGameStructure;
using StandartGameStructure.GameElemetPaterns;

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

            player.Animation.Animate = false;

            //ScreenManager.Instance.CurrnetScreen.Camera.Folow(player);

            ScreenManager.Instance.CurrnetScreen.Cursor.Path = "cursor";

            ScreenManager.Instance.TransferImage = new Background("Background/Black");
            ScreenManager.Instance.ImageTranferStep = 0.03f;

            BasicButton BB = new BasicButton()
            {
                Path = "button",
                Position = new Vector2(1100, 50),
                Scale = new Vector2(2, 1),
                Animation = new Animator()
                {
                    Animate = false,
                    AmountOfFrames = new Vector2(1,0)
                },
                Text = new VisualText("Font/mainFont", "New game", Color.White)
            };
            BB.MouseHover += (obj, args) => {
                ((BasicButton)obj).Animation.CurrentFrame= new Vector2(1, 0);
            };
            BB.MouseOut += (obj, args) => {
                ((BasicButton)obj).Animation.CurrentFrame = new Vector2(0, 0);
            };
            BB.MousePressed += (obj, args) => {
                ScreenManager.Instance.CurrnetScreen.UnloadContent();
                Screen newScreen = new Screen();
                newScreen.Background.Path = "scorpion";
                ScreenManager.Instance.TransferScreen(newScreen);
               newScreen.Cursor.Path = "cursor";
                newScreen.LoadContent();
            };


            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(BB);

            BasicButton BB2 = new BasicButton()
            {
                Path = "button",
                Position = new Vector2(1100, 110),
                Scale = new Vector2(2, 1),
                Animation = new Animator()
                {
                    Animate = false,
                    AmountOfFrames = new Vector2(1, 0)
                },
                Text = new VisualText("Font/mainFont", "Load game", Color.White)
            };
            BB2.MouseHover += (obj, args) => {
                ((BasicButton)obj).Animation.CurrentFrame = new Vector2(1, 0);
            };
            BB2.MouseOut += (obj, args) => {
                ((BasicButton)obj).Animation.CurrentFrame = new Vector2(0, 0);
            };

            ScreenManager.Instance.CurrnetScreen.ObjectsList.Add(BB2);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }
        
    }
}
