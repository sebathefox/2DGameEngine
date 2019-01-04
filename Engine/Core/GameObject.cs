using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Engine.Core.Attributes;
using Engine.Core.Component;
using OpenTK;

namespace Engine.Core
{
    public class GameObject
    {
        protected List<Component.Component> components = new List<Component.Component>();

        public string Name { get; set; }

        public GameObject()
        {
            Name = String.Empty;
            components.Add(new Transform(this, Vector3.Zero));

            RequireComponent comp = (RequireComponent) GetType().GetCustomAttribute(typeof(RequireComponent));

            if (comp != null)
            {
                // If component is not null OR if component doesn't exist in the components list
                if (comp.component != null ||
                    components.Find(component => component.GetType() == comp.component).GetType() !=
                    typeof(Component.Component))
                {
                    AddComponent(comp.component);
                    Debug.WriteLine("Added Component: " + comp.component.ToString() + " To \"" + this.Name + "\"");
                }
                
                else
                {
                    Debug.WriteLine("NOPE");
                }
            }
            
        }

        public Component.Component GetComponent(Type type)
        {
            return components.Find(component => component.GetType() == type);
        }

        public Component.Component GetComponent<T>()
        {
            return components.Find(component => component.GetType() == typeof(T));
        }

        public void AddComponent(Type t)
        {
            Component.Component comp = (Component.Component)Activator.CreateInstance(t, new object[] { this });
            components.Add(comp);
        }

        public void RemoveComponent<T>()
        {
            components.Remove(components.Find(component => component.GetType() == typeof(T)));
        }

        public void RemoveComponent(Type t)
        {
            components.Remove(components.Find(component => component.GetType() == t));
        }
    }
}
