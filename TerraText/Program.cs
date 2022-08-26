using System;

using TextGL.Geometry.Tridimensional;
using TextGL.Tools;

using System.Threading;

namespace TerraText
{
    class Program
    {
        public static Space space;

        static void MainRenderer()
        {
            while(true)
            {
                space.Camera.ProjectVertices();
                space.Camera.RasterizeImage(TextGL.Rendering.Camera.RenderType.Normal);
            }
        }

        static void Main(string[] args)
        {
            space = new Space();
            space.AddModel(ModelMaker.GetModelFromOBJ("./monkeyAlt2.obj"));
            //space.AddModel(ModelMaker.GetCube(10));

            //space.SetCamera(160, 90, 1, 0.5625, 0.5f, new Double3(0, 0, -15));
            space.SetCamera(200, 200, 1, 1, 0.5f, new Double3(0, 0, -2));

            Thread renderer = new Thread(new ThreadStart(MainRenderer));
            renderer.Start();

            while(true)
            {
                if(Console.ReadKey(true).Key == ConsoleKey.R)
                    space.Models[0].RotateAboutX(0.2);

                if(Console.ReadKey(true).Key == ConsoleKey.DownArrow)
                    space.Models[0].Translate(new Double3(0, -1, 0));
                
                if(Console.ReadKey(true).Key == ConsoleKey.UpArrow)
                    space.Models[0].Translate(new Double3(0, 1, 0));

                if(Console.ReadKey(true).Key == ConsoleKey.LeftArrow)
                    space.Models[0].Translate(new Double3(-1, 0, 0));

                if(Console.ReadKey(true).Key == ConsoleKey.RightArrow)
                    space.Models[0].Translate(new Double3(1, 0, 0));
                
                if(Console.ReadKey(true).Key == ConsoleKey.Q)
                    space.Models[0].Translate(new Double3(0, 0, 1));
                
                if(Console.ReadKey(true).Key == ConsoleKey.E)
                    space.Models[0].Translate(new Double3(0, 0, -1));

                if(Console.ReadKey(true).Key == ConsoleKey.A)
                    space.Camera.Translate(new Double3(0, 0, 1));
                
                if(Console.ReadKey(true).Key == ConsoleKey.D)
                    space.Camera.Translate(new Double3(0, 0, -1));
            }
        }
    }
}
