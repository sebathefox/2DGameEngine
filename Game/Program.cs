using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.Core.Component;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game(800, 600, "Test");

            game.Run(60);

            GameObject gameObject = new GameObject();

            ((Transform) gameObject.GetComponent<Transform>()).OnTransformChanged += (sender, eventArgs) =>
            {
                TransformEventArgs e = (TransformEventArgs) eventArgs;
                Console.WriteLine("Last position: " + e.LastPosition);
                Console.WriteLine("Current position: " + ((Transform)sender).Position);
            };

            ((Transform)gameObject.GetComponent<Transform>()).Position += Vector3.One;

            //Console.WriteLine(((Transform)gameObject.GetComponent<Transform>()).Position.ToString());

            Console.ReadLine();
        }
    }
}
