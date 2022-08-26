using System;

namespace TextGL.Geometry.Tridimensional
{
    public class Triangle
    {
        private Vertex vertA;
        public Vertex VertexA { get => vertA; }
        private Vertex vertB;
        public Vertex VertexB { get => vertB; }
        private Vertex vertC;
        public Vertex VertexC { get => vertC; }

        private Mesh linkedMesh;
        public Mesh LinkedMesh { get => linkedMesh; internal set => linkedMesh = value; }

        public Triangle(Vertex _vertA, Vertex _vertB, Vertex _vertC)
        {
            vertA = _vertA;
            vertB = _vertB;
            vertC = _vertC;
        }

        public Vertex this[int index]
        {
            get
            {
                if(index == 0)
                    return vertA;
                else if(index == 1)
                    return vertB;
                else if(index == 2)
                    return vertC;
                else
                    throw new IndexOutOfRangeException("Index must be between [0, 2]");
            }

            set
            {
                if(index == 0)
                    vertA = value;
                else if(index == 1)
                    vertB = value;
                else if(index == 2)
                    vertC = value;
                else
                    throw new IndexOutOfRangeException("Index must be between [0, 2]");
            }
        }
    }
}