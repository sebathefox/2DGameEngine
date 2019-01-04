using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.Core.Attributes;
using Engine.Core.Component;

namespace Game
{
    [RequireComponent(typeof(Transform))]
    class TestGameObject : GameObject
    {
    }
}
