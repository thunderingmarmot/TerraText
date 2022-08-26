using System;

using TextGL.Geometry.Tridimensional;

using TextGL.Tools;

namespace TextGL.Rendering
{
    public class ConsoleCamera : Camera
    {
        public ConsoleCamera(int _resolutionLength, int _resolutionHeight, double _aspectLength, double _aspectHeight, double _focalLength, Space _viewedSpace, Double3 _postion)
            : base(_resolutionLength, _resolutionHeight, _aspectLength, _aspectHeight, _focalLength, _viewedSpace, _postion)
        {
            resolutionLength = _resolutionLength;
            resolutionHeight = _resolutionHeight;
            aspectLength = _aspectLength;
            aspectHeight = _aspectHeight;
            focalLength = _focalLength;
            viewedSpace = _viewedSpace;
            position = _postion;

            UpdateProjectionArrays();
        }

        protected override void BeforeRasterize()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
        }

        protected override void BeforeDraw() { }

        protected override void DrawPixel()
        {
            FastConsole.Write("█");
            FastConsole.Write("█");
            FastConsole.Flush();
        }

        protected override void DrawEmpty()
        {
            FastConsole.Write(" ");
            FastConsole.Write(" ");
            FastConsole.Flush();
        }

        protected override void AfterLine()
        {
            FastConsole.Write("\n");
            FastConsole.Flush();
        }

        protected override void AfterRasterize()
        {
            FastConsole.Flush();
        }
    }
}