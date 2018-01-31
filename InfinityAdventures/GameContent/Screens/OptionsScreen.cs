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
            // TODO
            // get current resolution

            VisualText resolutionText = new VisualText(new Vector2(600, 300), "Font/OptionsFont", "Resolution: " + ScreenManager.Instance.StandartResolutions[currenResolution], Color.White);
            ObjectsList.Add(resolutionText);

            MyButton backButton = new MyButton()
            {
                Path = "Button/MainButton",
                Position = new Vector2(600, 500),
                Text = new VisualText("Font/ButtonFont", "Назад", Color.White)
            };
            backButton.Click += (s, e) =>
            {
                ScreenManager.Instance.TransferScreen(new MenuScreen());
            };
            ObjectsList.Add(backButton);


            MyButton acceptButton = new MyButton();

        }
        
    }
}
