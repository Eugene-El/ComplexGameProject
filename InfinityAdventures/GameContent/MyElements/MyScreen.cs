using Microsoft.Xna.Framework;
using StandartGameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityAdventures.GameContent.MyElements
{
    public class MyScreen : Screen
    {
        public MyScreen() : base()
        {
            Cursor.Path = "cursor";
            Cursor.Scale = new Vector2(2);
        }
    }
}
