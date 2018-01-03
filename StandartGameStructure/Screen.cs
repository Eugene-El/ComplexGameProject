using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StandartGameStructure
{
    public class Screen : IVisualContent
    {
        public List<GameObject> ObjectsList { get; set; }
        public Image Background { get; set; }

        public Screen()
        {
            ObjectsList = new List<GameObject>();
            Background = new Image();
        }


        //

        public void LoadContent()
        {
            Background.LoadContent();
            foreach (GameObject GO in ObjectsList)
                GO.LoadContent();
        }

        public void UnloadContent()
        {
            Background.UnloadContent();
            foreach (GameObject GO in ObjectsList)
                GO.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            Background.Update(gameTime);
            foreach (GameObject GO in ObjectsList)
                GO.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            foreach (GameObject GO in ObjectsList)
                GO.Draw(spriteBatch);
        }

        //
    }
}
