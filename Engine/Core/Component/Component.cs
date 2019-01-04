using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Component
{
    public abstract class Component
    {
        protected GameObject gameObject;

        protected Component(GameObject gob)
        {
            gameObject = gob;
        }

        public bool Enabled { get; set; }

        public virtual void Start() { }

        public virtual void Update() { }
    }
}
