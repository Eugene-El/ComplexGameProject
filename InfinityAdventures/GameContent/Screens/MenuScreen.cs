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
    public class MenuScreen : MyScreen
    {
        private List<MyButton> buttonsList;

        public MenuScreen() : base()
        {
            buttonsList = new List<MyButton>();

            Background.Path = "scorpion";

            ButtonImplementation(
                "Button/MainButton",
                new Vector2(280, 60),
                100,
                new Vector2(2, 1),
                "Font/ButtonFont", 
                Color.White,
                new string[] { "Новая игра", "Загрузить", "Настройки", "Титры", "Выход" }
                );

            buttonsList[2].Click += (s, e) =>
            {
                ScreenManager.Instance.TransferScreen(new OptionsScreen());
            };
            buttonsList[4].Click += (s, e) =>
            {
                ScreenManager.Instance.QuitGame();
            };

            ObjectsList.AddRange(buttonsList);
        }


        private void ButtonImplementation(string imagePath, Vector2 firstPosition, float indentation, Vector2 scale, string font, Color color, string[] buttonTexts)
        {
            for (int i = 0; i < buttonTexts.Length; i++)
            {
                MyButton mb = new MyButton()
                {
                    Path = imagePath,
                    Position = firstPosition + new Vector2(0, indentation * i),
                    Scale = scale,
                    Text = new VisualText(font, buttonTexts[i], color),
                };
                

                buttonsList.Add(mb);
            }
        }

    }
}
