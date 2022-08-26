using System.IO;

using TextGL.Geometry.Tridimensional;

namespace TextGL.Rendering
{
    public class StreamCamera : Camera
    {
        private BufferedStream output;

        public StreamCamera(int _resolutionLength, int _resolutionHeight, double _aspectLength, double _aspectHeight, double _focalLength, Space _viewedSpace, Double3 _postion, Stream _output)
            : base(_resolutionLength, _resolutionHeight, _aspectLength, _aspectHeight, _focalLength, _viewedSpace, _postion)
        {
            resolutionLength = _resolutionLength;
            resolutionHeight = _resolutionHeight;
            aspectLength = _aspectLength;
            aspectHeight = _aspectHeight;
            focalLength = _focalLength;
            viewedSpace = _viewedSpace;
            position = _postion;
            output = new BufferedStream(_output, 0x15000);

            UpdateProjectionArrays();
        }

        protected override void BeforeRasterize() { }
        protected override void BeforeDraw() { }

        protected override void DrawPixel()
        {
            output.WriteByte((byte)'#');
            output.WriteByte((byte)'#');
        }

        protected override void DrawEmpty()
        {
            output.WriteByte((byte)' ');
            output.WriteByte((byte)' ');
        }

        protected override void AfterLine()
        {
            output.WriteByte((byte)'\n');
        }

        protected override void AfterRasterize()
        {
            output.Flush();
        }
    }
}