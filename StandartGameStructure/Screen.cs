using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StandartGameStructure
{
    public class Screen : IGameContent
    {
        public List<AbstractVisualObject> ObjectsList { get; set; }

        public Background Background { get; set; }

        public Screen()
        {
            ObjectsList = new List<AbstractVisualObject>();
            Background = new Background();
        }


        //

        public void LoadContent()
        {
            Background.LoadContent();
            foreach (AbstractVisualObject GO in ObjectsList)
                GO.LoadContent();
        }

        public void UnloadContent()
        {
            Background.UnloadContent();
            foreach (AbstractVisualObject GO in ObjectsList)
                GO.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            Background.Update(gameTime);
            foreach (AbstractVisualObject GO in ObjectsList)
                GO.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            foreach (AbstractVisualObject GO in ObjectsList)
                GO.Draw(spriteBatch);
        }

        //
    }
}
