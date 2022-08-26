using System;
using System.Collections.Generic;
using System.IO;

using TextGL.Rendering;
using TextGL.Tools;

namespace TextGL.Geometry.Tridimensional
{
    public class Space
    {
        private Double3 origin;
        public Double3 Origin { get => origin; }
        private List<Model> models;
        public List<Model> Models { get => models; }
        private Camera camera;
        public Camera Camera { get => camera; }

        public Space()
        { 
            origin = new Double3(0, 0, 0);
            models = new List<Model>();
        }

        public void AddModel(Model modelToAdd)
        {
            models.Add(modelToAdd);
        }

        public void SetCamera(int _resolutionLength, int _resolutionHeight, double _viewportLength, double _viewportHeight, double _focalLength, Double3 _postion, Stream _output)
        {
            camera = new StreamCamera(_resolutionLength, _resolutionHeight, _viewportLength, _viewportHeight, _focalLength, this, _postion, _output);
        }

        public void SetCamera(int _resolutionLength, int _resolutionHeight, double _viewportLength, double _viewportHeight, double _focalLength, Double3 _postion)
        {
            camera = new ConsoleCamera(_resolutionLength, _resolutionHeight, _viewportLength, _viewportHeight, _focalLength, this, _postion);
        }

        public double GetDistanceX(Double3 point1, Double3 point2)
        {
            return Math.Abs(point1.X - point2.X);
        }

        public double GetDistanceY(Double3 point1, Double3 point2)
        {
            return Math.Abs(point1.Y - point2.Y);
        }

        public double GetDistanceZ(Double3 point1, Double3 point2)
        {
            return Math.Abs(point1.Z - point2.Z);
        }

        public double GetDistance(Double3 point1, Double3 point2)
        {
            return Math.Sqrt(Math.Pow(GetDistanceX(point1, point2), 2) + Math.Pow(GetDistanceY(point1, point2), 2) + Math.Pow(GetDistanceZ(point1, point2), 2));
        }
    }
}