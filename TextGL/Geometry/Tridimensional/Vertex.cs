using System;

namespace TextGL.Geometry.Tridimensional
{
    public class Vertex
    {
        private Double3 position;
        public Double3 Position { get => position; }

        private Triangle[] linkedTriangles;
        public Triangle[] LinkedTriangles { get => linkedTriangles; internal set => linkedTriangles = value; }

        public Vertex(Double3 _position)
        {
            position = _position;
        }

        public void Translate(Double3 direction)
        {
            position += direction;
        }

        public void RotateAboutX(double degrees)
        {
            position.Y = (position.Y * Math.Cos(degrees)) - (position.Z * Math.Sin(degrees));
            position.Z = (position.Y * Math.Sin(degrees)) + (position.Z * Math.Cos(degrees));
        }

        public void RotateAboutY(double degrees)
        {
            position.X = (position.X * Math.Cos(degrees)) + (position.Z * Math.Sin(degrees));
            position.Z = (position.Z * Math.Cos(degrees)) - (position.X * Math.Sin(degrees));
        }

        public void RotateAboutZ(double degrees)
        {
            position.X = (position.X * Math.Cos(degrees)) - (position.Y * Math.Sin(degrees));
            position.Y = (position.X * Math.Sin(degrees)) + (position.Y * Math.Cos(degrees));
        }
    }
}