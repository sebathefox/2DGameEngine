using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game
{
    class Game : GameWindow
    {
        private Random rnd = new Random();

        private float[] vertices =
        {
            -0.5f, -0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            0.0f, 0.5f, 0.0f
        };

        private int vbo;
        private int vao;
        private Shader shader;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) 
        {}

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            vbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            
            shader = new Shader("shader.vert", "shader.frag");

            shader.Use();

            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.Use();

            //Bind the VAO
            GL.BindVertexArray(vao);

            //And then call GL.DrawArrays
            //Arguments:
            //  Primitive type; What sort of geometric primitive the vertices represent. We just want a triangle, so PrimitiveType.Triangles is fine.
            //  Starting index; this is just the start of the data you want to draw. 0 here.
            //  How many vertices you want to draw. 3 for a triangle.
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);


            //OpenTK windows are what's known as "double-buffered". In essence, the window manages two images.
            //One is rendered to while the other is currently displayed by the window.
            //After drawing, call this function to swap the buffers. If you don't, it won't display what you've rendered.
            Context.SwapBuffers();


            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            //Location = new Point(rnd.Next(Width), rnd.Next(Height));
            
            GL.ClearColor((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 255);
            
            //GL.Clear(ClearBufferMask.ColorBufferBit);
            //Context.SwapBuffers();

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteBuffer(vbo);
            GL.DeleteVertexArray(vao);

            shader.Dispose();
            base.OnUnload(e);
        }
    }
}
