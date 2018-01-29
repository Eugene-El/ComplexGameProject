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
        private List<BasicButton> buttonsList;

        public MenuScreen() : base()
        {
            buttonsList = new List<BasicButton>();

            Background.Path = "scorpion";

            ButtonImplementation(
                "Button/MainButton",
                new Vector2(280, 60),
                100,
                new Vector2(2, 1),
                new Animator()
                {
                    Animate = false,
                    AmountOfFrames = new Vector2(0, 1)
                },
                "Font/ButtonFont", 
                Color.White,
                new string[] { "Новая игра", "Загрузить", "Настройки", "Титры", "Выход" }
                );

            ObjectsList.AddRange(buttonsList);
        }


        private void ButtonImplementation(string imagePath, Vector2 firstPosition, float indentation, Vector2 scale, Animator animator, string font, Color color, string[] buttonTexts)
        {
            for (int i = 0; i < buttonTexts.Length; i++)
            {
                BasicButton bb = new BasicButton()
                {
                    Path = imagePath,
                    Position = firstPosition + new Vector2(0, indentation * i),
                    Scale = scale,
                    Animation = new Animator()
                    {
                        Animate = animator.Animate,
                        AmountOfFrames = animator.AmountOfFrames
                    },
                    Text = new VisualText(font, buttonTexts[i], color),
                };

                bb.MouseHover += MouseHover;
                bb.MouseOut += MouseOut;

                buttonsList.Add(bb);
            }
        }

        private void MouseHover(object sender, EventArgs e)
        {
            ((BasicButton)sender).Animation.CurrentFrame = new Vector2(0, 1);
        }

        private void MouseOut(object sender, EventArgs e)
        {
            ((BasicButton)sender).Animation.CurrentFrame = new Vector2(0, 0);
        }

    }
}
