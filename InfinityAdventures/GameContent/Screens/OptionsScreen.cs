using InfinityAdventures.GameContent.MyElements;
using Microsoft.Xna.Framework;
using StandartGameStructure;
using StandartGameStructure.GameElemetPaterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityAdventures.GameContent
{
    public class OptionsScreen : MyScreen
    {
        private int currenResolution;
        private bool isFullscreen;

        public OptionsScreen() : base()
        {
            currenResolution = ScreenManager.Instance.StandartResolutions.FindIndex((x) => x == ScreenManager.Instance.Dimensions);
            isFullscreen = ScreenManager.Instance.IsFullscreen;



            // Resolution group
            VisualText resolutionText = new VisualText(new Vector2(960, 200), "Font/OptionsFont", "Resolution: " + ScreenManager.Instance.StandartResolutions[currenResolution].X + " x " + ScreenManager.Instance.StandartResolutions[currenResolution].Y, Color.White);
            ObjectsList.Add(resolutionText);
            MyButton downResolution = new MyButton()
            {
                Path = "Button/MainSquareButton",
                Position = new Vector2(460, 200),
                Text = new VisualText("Font/TehnicalFont", "◄", Color.White),
                Scale = new Vector2(1.5f, 1)
            };
            downResolution.Click += (s, e) =>
            {
                currenResolution--;
                if (currenResolution < 0)
                    currenResolution = ScreenManager.Instance.StandartResolutions.Count - 1;
                resolutionText.Text = "Resolution: " + ScreenManager.Instance.StandartResolutions[currenResolution].X + " x " + ScreenManager.Instance.StandartResolutions[currenResolution].Y;
                resolutionText.LoadContent();
            };
            MyButton upResolution = new MyButton()
            {
                Path = "Button/MainSquareButton",
                Position = new Vector2(1460, 200),
                Text = new VisualText("Font/TehnicalFont", "►", Color.White),
                Scale = new Vector2(1.5f, 1)
            };
            upResolution.Click += (s, e) =>
            {
                currenResolution++;
                if (currenResolution > ScreenManager.Instance.StandartResolutions.Count - 1)
                    currenResolution = 0;
                resolutionText.Text = "Resolution: " + ScreenManager.Instance.StandartResolutions[currenResolution].X + " x " + ScreenManager.Instance.StandartResolutions[currenResolution].Y;
                resolutionText.LoadContent();
            };
            ObjectsList.Add(downResolution);
            ObjectsList.Add(upResolution);
            //







            // Fullscreen button
            MyButton isFullScreenButton = new MyButton()
            {
                Path = "Button/MainButton",
                Position = new Vector2(960, 350),
                Text = new VisualText("Font/ButtonFont", isFullscreen? "На весь экран" : "В окне", Color.White),
                Scale = new Vector2(3, 1)
            };
            isFullScreenButton.Click += (s, e) =>
            {
                isFullscreen = !isFullscreen;
                isFullScreenButton.Text.Text = isFullscreen ? "На весь экран" : "В окне";
                isFullScreenButton.LoadContent();
            };
            ObjectsList.Add(isFullScreenButton);
            //









            // Accept & back buttons group
            MyButton backButton = new MyButton()
            {
                Path = "Button/MainButton",
                Position = new Vector2(1900, 1060),
                Text = new VisualText("Font/ButtonFont", "Назад", Color.White),
                OriginPosition = OriginPosition.RightLowerCorner,
                Scale = new Vector2(2, 1)
            };
            backButton.Click += (s, e) =>
            {
                ScreenManager.Instance.TransferScreen(new MenuScreen());
            };
            ObjectsList.Add(backButton);

            MyButton acceptButton = new MyButton()
            {
                Path = "Button/MainButton",
                Position = new Vector2(20, 1060),
                Text = new VisualText("Font/ButtonFont", "Принять", Color.White),
                OriginPosition = OriginPosition.LeftLowerCorner,
                Scale = new Vector2(2, 1)
            };
            acceptButton.Click += (s, e) =>
            {
                ScreenManager.Instance.Dimensions = ScreenManager.Instance.StandartResolutions[currenResolution];
                ScreenManager.Instance.IsFullscreen = isFullscreen;
                ScreenManager.Instance.TransferScreen(new MenuScreen());
            };
            ObjectsList.Add(acceptButton);
            //
        }
        
    }
}
