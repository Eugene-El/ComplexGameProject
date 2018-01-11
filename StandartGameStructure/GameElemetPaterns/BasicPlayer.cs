using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StandartGameStructure.GameElemetPaterns
{
    public class BasicPlayer : MovingElement
    {
        public float MoveSpeed { get; set; }

        public BasicPlayer()
        {
            MoveSpeed = 1;
        }

        public override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.KeyDown(Keys.S, Keys.Down))
            {
                Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (InputManager.Instance.KeyDown(Keys.W, Keys.Up))
            {
                Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
                Velocity.Y = 0;

            if (InputManager.Instance.KeyDown(Keys.D, Keys.Right))
            {
                Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (InputManager.Instance.KeyDown(Keys.A, Keys.Left))
            {
                Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
                Velocity.X = 0;



            base.Update(gameTime);
        }
    }
}
