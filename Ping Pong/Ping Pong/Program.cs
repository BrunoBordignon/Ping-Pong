using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Ping_Pong
{
    class Program : GameWindow
    {
        int xDaBola = 0;
        int yDaBola = 0;
        int velocidadeXDaBola = 3;
        int velocidadeYDaBola = 3;
        int tamanhoDaBola = 20;

        int MovimentoJogador1 = 0;
        int MovimentoJogador2 = 0;


        int xDoJogador1() { return -ClientSize.Width / 2 + larguraJogadores() / 2; }
        int xDoJogador2() { return ClientSize.Width / 2 - larguraJogadores() / 2; }


        int larguraJogadores() { return tamanhoDaBola; }

        int alturaJogadores() { return 5 * tamanhoDaBola; }

        protected override void OnUpdateFrame(FrameEventArgs e) {

            xDaBola = xDaBola +  velocidadeXDaBola;
            yDaBola = yDaBola + velocidadeYDaBola;

            //direito
            if (xDaBola + tamanhoDaBola / 2 > xDoJogador2() - larguraJogadores() /2 
                && yDaBola - tamanhoDaBola / 2 < MovimentoJogador2 + alturaJogadores()/2
                && yDaBola + tamanhoDaBola / 2 > MovimentoJogador2 - alturaJogadores()/2) {

                velocidadeXDaBola = -velocidadeXDaBola;
            }

            //esquerdo
            if (xDaBola - tamanhoDaBola / 2 < xDoJogador1() + larguraJogadores() / 2
                && yDaBola - tamanhoDaBola / 2 < MovimentoJogador1 + alturaJogadores() / 2
                && yDaBola + tamanhoDaBola / 2 > MovimentoJogador1 - alturaJogadores() / 2)
            {
                velocidadeXDaBola = -velocidadeXDaBola;
            }

            //superior
            if (yDaBola + tamanhoDaBola / 2 > ClientSize.Height / 2)
            {
                velocidadeYDaBola = -velocidadeYDaBola;
            }

            //inferior
            if (yDaBola - tamanhoDaBola / 2 < -ClientSize.Height / 2)
            {
                velocidadeYDaBola = -velocidadeYDaBola;
            }

            if (xDaBola < -ClientSize.Width / 2 || xDaBola > ClientSize.Width / 2) {
                xDaBola = 0;
                yDaBola = 0;     
            }

            //CONTROLES JOGADOR 1
            if (Keyboard.GetState().IsKeyDown(Key.W)) {
                MovimentoJogador1 = MovimentoJogador1 + 5;          
            }

            if (Keyboard.GetState().IsKeyDown(Key.S))
            {
                MovimentoJogador1 = MovimentoJogador1 - 5;
            }


            //CONTROLES JOGADOR 2
            if (Keyboard.GetState().IsKeyDown(Key.Up))
            {
                MovimentoJogador2 = MovimentoJogador2 + 5;
            }

            if (Keyboard.GetState().IsKeyDown(Key.Down))
            {
                MovimentoJogador2 = MovimentoJogador2 - 5;
            }

        }

        protected override void OnRenderFrame(FrameEventArgs e) {

            Console.WriteLine(ClientSize.Width + " " + ClientSize.Height);
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            GL.Clear(ClearBufferMask.ColorBufferBit);


            Quadrado(xDaBola , yDaBola , tamanhoDaBola , tamanhoDaBola, 1.0f, 1.0f, 1.0f); //bola
            Quadrado(xDoJogador1(), MovimentoJogador1, alturaJogadores(), larguraJogadores(), 1.0f, 0.0f, 0.0f); //Jogador1 
            Quadrado(xDoJogador2(), MovimentoJogador2, alturaJogadores(), larguraJogadores(), 0.0f, 1.0f, 0.0f); //Jogador2 

            SwapBuffers();
        }

        void Quadrado(int x, int y, int largura , int altura, float r , float g, float b) {

            GL.Color3(r, g, b);
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
