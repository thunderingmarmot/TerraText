using System;

namespace TextGL.Geometry.Tridimensional
{
    public class Model
    {
        private Vertex anchor;
        public Vertex Anchor { get => anchor; }

        private Mesh geometryMesh;
        public Mesh GeometryMesh { get => geometryMesh; }

        public Model(Mesh _geometryMesh, Vertex _anchor)
        {
            anchor = _anchor;
            geometryMesh = _geometryMesh;
        }

        public void Translate(Double3 direction)
        {
            anchor.Translate(direction);
            for(int i = 0; i < geometryMesh.Vertices.Length; i++)
                geometryMesh.Vertices[i].Translate(direction);
        }

        public void RotateAboutX(double degrees)
        {
            anchor.RotateAboutX(degrees);
            for(int i = 0; i < geometryMesh.Vertices.Length; i++)
                geometryMesh.Vertices[i].RotateAboutX(degrees);
        }

        public void RotateAboutY(double degrees)
        {
            anchor.RotateAboutY(degrees);
            for(int i = 0; i < geometryMesh.Vertices.Length; i++)
                geometryMesh.Vertices[i].RotateAboutY(degrees);
        }

        public void RotateAboutZ(double degrees)
        {
            anchor.RotateAboutZ(degrees);
            for(int i = 0; i < geometryMesh.Vertices.Length; i++)
                geometryMesh.Vertices[i].RotateAboutZ(degrees);
        }
    }
}