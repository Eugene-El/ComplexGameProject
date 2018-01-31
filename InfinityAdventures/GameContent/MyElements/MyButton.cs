using Microsoft.Xna.Framework;
using StandartGameStructure.GameElemetPaterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityAdventures.GameContent.MyElements
{
    public class MyButton : BasicButton 
    {
        public MyButton() : base()
        {
            Animation.AmountOfFrames = new Vector2(0, 1);
            Animation.Animate = false;

            MouseHover += MouseHoverAnimation;
            MouseOut += MouseOutAnimation;
        }

        private void MouseHoverAnimation(object sender, EventArgs e)
        {
            (sender as BasicButton).Animation.CurrentFrame = new Vector2(0, 1);
        }

        private void MouseOutAnimation(object sender, EventArgs e)
        {
            (sender as BasicButton).Animation.CurrentFrame = new Vector2(0, 0);
        }
    }
}
