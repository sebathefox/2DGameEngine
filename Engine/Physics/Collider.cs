using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.Core.Component;

namespace Engine.Physics
{
    public class Collider : Component
    {
        public override void Update()
        {
        }

        public Collider(GameObject gob) : base(gob)
        {
        }
    }
}
