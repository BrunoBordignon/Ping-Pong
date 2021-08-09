using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Ping_Pong
{
    class Program : GameWindow
    {
        protected override void OnRenderFrame(FrameEventArgs e) {

            Console.WriteLine(ClientSize.Width + " " + ClientSize.Height);

            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);

            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            Quadrado(-100, 200, 20 , 20);
            Quadrado(-310, 0, 40, 20);
            Quadrado(310, 0, 40, 20);
            SwapBuffers();


        }

        void Quadrado(int x, int y, int largura , int altura) { 
   
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.5f * altura + x , -0.5f * largura + y);
            GL.Vertex2(0.5f * altura + x, -0.5f * largura  + y);
            GL.Vertex2(0.5f * altura + x, 0.5f * largura + y);
            GL.Vertex2(-0.5f * altura + x, 0.5f * largura + y);
            GL.End();

        }
        
        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}
