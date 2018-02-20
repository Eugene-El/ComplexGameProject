using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartGameStructure
{
    public class Camera
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }

        private float zoom;
        public float Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                if (value < MinimalZoom)
                    zoom = MinimalZoom;
                else if (value > MaximalZoom)
                    zoom = MaximalZoom;
                else
                    zoom = value;
            }
        }
        public float MinimalZoom { get; set; }
        public float MaximalZoom { get; set; }

        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }
        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(ViewportWidth/2f, ViewportHeight/2f);
            }
        }

        public Matrix TranslationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-(int)Position.X,
                   -(int)Position.Y, 0) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));// *
                   //Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
            }
        }

        public Camera()
        {
            MaximalZoom = 2f;
            MinimalZoom = 0.25f;
            Zoom = 1f;
        }

        private AbstractVisualObject folowObject;
        public void Folow(AbstractVisualObject objectForFolowing)
        {
            folowObject = objectForFolowing;
        }

        public void Update()
        {
            if (folowObject != null)
                Position = (folowObject.Position - ScreenManager.Instance.AbsoluteResolution/2* (1 / Zoom) ) * ScreenManager.Instance.WindowResolutionScaling;
        }
    }
}
