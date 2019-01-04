using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Engine.Core.Component
{
    public class TransformEventArgs : EventArgs
    {
        public Vector3 LastPosition { get; set; }

        public Quaternion LastRotation { get; set; }
    }

    public class Transform : Component
    {
        private Vector3 position;
        private Quaternion rotation;

        public event EventHandler OnTransformChanged;
        public event EventHandler OnPositionChanged;
        public event EventHandler OnRotationChanged;

        /// <summary>
        /// Defines the position of the <see cref="GameObject"/>
        /// </summary>
        public Vector3 Position {
            get => position;
            set
            {
                position = value;
                TransformEventArgs args = new TransformEventArgs
                {
                    LastPosition = position,
                    LastRotation = rotation
                };
                OnTransformChanged?.Invoke(this, args);
                OnPositionChanged?.Invoke(this, args);
                
            } }

        public Quaternion Rotation
        {
            get => rotation;
            set
            {
                rotation = value;
                TransformEventArgs args = new TransformEventArgs
                {
                    LastPosition = position,
                    LastRotation = rotation
                };
                OnTransformChanged?.Invoke(this, args);
                OnRotationChanged?.Invoke(this, args);
                
            }
        }

        public Vector3 Size { get; set; }

        public Transform(GameObject gob) : base(gob)
        {
            Position = Vector3.Zero;
            Rotation = Quaternion.Identity;
        }

        public Transform(GameObject gob, Vector3 position) : base(gob)
        {
            Position = position;
            Rotation = Quaternion.Identity;
        }
    }
}
