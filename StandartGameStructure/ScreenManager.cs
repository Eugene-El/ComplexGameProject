using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace StandartGameStructure
{
    public class ScreenManager
    {
        // Singleton

        private static ScreenManager instance;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        private ScreenManager()
        {
            CurrnetScreen = new Screen();
            ImageTranferStep = 0.1f;

            StandartResolutions = new List<Vector2>()
            {
                new Vector2(800, 600),
                new Vector2(1024, 768),
                new Vector2(1152, 864),
                new Vector2(1176, 664),
                new Vector2(1280, 720),
                new Vector2(1280, 768),
                new Vector2(1280, 800),
                new Vector2(1280, 960),
                new Vector2(1280, 1024),
                new Vector2(1360, 768),
                new Vector2(1366, 768),
                new Vector2(1440, 900),
                new Vector2(1600, 900),
                new Vector2(1600, 1024),
                new Vector2(1680, 1050),
                new Vector2(1768, 992),
                new Vector2(1920, 1080)
            };
        }

        //

        // Window size changing

        public List<Vector2> StandartResolutions { get; }

        public Vector2 WindowResolutionScaling
        {
            get
            {
                return (Dimensions / AbsoluteResolution);
            }
        }
        
        public Vector2 AbsoluteResolution { get; set; }


        private int width, height;
        public Vector2 Dimensions
        {
            get
            {
                return new Vector2(Width, Height);
            }
            set
            {
                Width = (int)value.X;
                Height = (int)value.Y;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                WindowSizeChanged?.Invoke(this, new EventArgs());
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                WindowSizeChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler WindowSizeChanged;
        public event EventHandler ExitTheGame;


        //

        public Vector2 CenterOfScreen { get { return AbsoluteResolution / 2; } }

        public ContentManager Content { get; private set; }

        public GraphicsDevice GraphicsDevice { get; set; }
        public SpriteBatch SpriteBatch { get; set; }


        // Screen changing staff

        public Screen CurrnetScreen { get; set; }
        public Screen NextScreen { get; set; }
        public bool IsTransitioning { get; private set; }
        public Background TransferImage { get; set; }
        public float ImageTranferStep { get; set; }
        private bool transferBack;

        //

        //

        public void LoadContent(ContentManager content)
        {
            if (Content != null)
                Content.Dispose();

            Content = new ContentManager(content.ServiceProvider, "Content");
            
            CurrnetScreen.LoadContent();
            if (TransferImage != null)
                TransferImage.LoadContent();
        }

        public void UnloadContent()
        {
            CurrnetScreen.UnloadContent();
            if (TransferImage != null)
                TransferImage.UnloadContent();

            Content.Unload();
        }

        public void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
            CurrnetScreen.Update(gameTime);

            if (IsTransitioning)
            {
                if (TransferImage != null)
                {
                    if (transferBack)
                    {
                        if (TransferImage.Alpha - ImageTranferStep >= 0)
                            TransferImage.Alpha -= ImageTranferStep;
                        else
                        {
                            TransferImage.Alpha = 0;
                            transferBack = false;
                            IsTransitioning = false;
                        }
                    }
                    else
                    {
                        if (TransferImage.Alpha + ImageTranferStep <= 1)
                            TransferImage.Alpha += ImageTranferStep;
                        else
                        {
                            TransferImage.Alpha = 1;
                            transferBack = true;
                            CurrnetScreen.UnloadContent();
                            CurrnetScreen = NextScreen;
                            CurrnetScreen.LoadContent();
                            NextScreen = null;
                        }
                    }


                    TransferImage.Update(gameTime);
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrnetScreen.Draw(spriteBatch);

            if (IsTransitioning && TransferImage != null)
                TransferImage.Draw(spriteBatch);
        }

        //

        public void TransferScreen()
        {
            // Check that screen not already transitioning
            if (!IsTransitioning)
            {
                // If is transfer image
                IsTransitioning = true;
                transferBack = false;
                if (TransferImage != null)
                {
                    TransferImage.Alpha = 0;
                    TransferImage.Position = Vector2.Zero;
                }
                else // If not do it momentaly 
                {
                    if(Content!= null)
                        CurrnetScreen.UnloadContent();
                    CurrnetScreen = NextScreen;
                    if (Content != null)
                        CurrnetScreen.LoadContent();
                    NextScreen = null;
                    IsTransitioning = false;
                }
            }
        }

        public void TransferScreen(Screen screen)
        {
            NextScreen = screen;
            TransferScreen();
        }

        public void QuitGame()
        {
            ExitTheGame?.Invoke(this, new EventArgs());
        }
    }
}
