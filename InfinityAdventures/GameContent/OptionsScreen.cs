using Microsoft.Xna.Framework;
using StandartGameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityAdventures.GameContent
{
    public class OptionsScreen : MyScreen
    {
        public OptionsScreen() : base()
        {
            VisualText resolutionText = new VisualText(new Vector2(300, 300), "Font/OptionsFont", "Resolution: ", Color.White);
        }
    }
}
