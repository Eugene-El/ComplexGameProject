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
        public Cursor Cursor { get; set; }
        public Camera Camera { get; set; }
        

        public Screen()
        {
            ObjectsList = new List<AbstractVisualObject>();
            Background = new Background();
            Cursor = new Cursor();
            Camera = new Camera()
            {
                //ViewportWidth = 1280,
                //ViewportHeight = 720
            };

        }


        //

        public void LoadContent()
        {
            Background.LoadContent();
            foreach (AbstractVisualObject GO in ObjectsList)
                GO.LoadContent();
            Cursor.LoadContent();
        }

        public void UnloadContent()
        {
            Background.UnloadContent();
            foreach (AbstractVisualObject GO in ObjectsList)
                GO.UnloadContent();
            Cursor.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            Camera.Update();
            Background.Update(gameTime);
            foreach (AbstractVisualObject GO in ObjectsList)
                GO.Update(gameTime);
            Cursor.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Camera.TranslationMatrix);
            Background.Draw(spriteBatch);
            foreach (AbstractVisualObject GO in ObjectsList)
                GO.Draw(spriteBatch);
            Cursor.Draw(spriteBatch);
        }

        //
    }
}
