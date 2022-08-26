using System;
using System.Collections.Generic;

using TextGL.Tools;

namespace TextGL.Geometry.Tridimensional
{
    public class Mesh
    {
        private Vertex[] vertices;
        public Vertex[] Vertices { get => vertices; }
        private Triangle[] triangles;
        public Triangle[] Triangles { get => triangles; }

        private bool isLinked;
        public bool IsLinked { get => isLinked; }

        public Mesh(int numberOfVertices, int numberOfTriangles)
        {
            vertices = new Vertex[numberOfVertices];
            triangles = new Triangle[numberOfTriangles];
            isLinked = false;
        }

        public Mesh(List<Vertex> verticesList, List<Triangle> trianglesList)
        {
            vertices = verticesList.ToArray();
            triangles = trianglesList.ToArray();
            isLinked = false;
        }

        public Mesh(Vertex[] verticesArr, Triangle[] trianglesArr)
        {
            vertices = verticesArr;
            triangles = trianglesArr;
            isLinked = false;
        }

        public bool AddTriangle(Vertex a, Vertex b, Vertex c)
        {
            if(GetVertexIndex(a) == -1)
                AddToVertices(a);
            if(GetVertexIndex(b) == -1)
                AddToVertices(b);
            if(GetVertexIndex(c) == -1)
                AddToVertices(c);

            Triangle abc = new Triangle(a, b, c);
            if(GetTriangleIndex(abc) == -1)
                AddToTriangles(abc);
            
            return true;
        }

        private int AddToVertices(Vertex vertexToInsert)
        {
            for(int i = 0; i < vertices.Length; i++)
            {
                if(vertices[i] == null)
                {
                    vertices[i] = vertexToInsert;
                    return i;
                }
            }

            return -1;
        }

        private int AddToTriangles(Triangle triangleToInsert)
        {
            for(int i = 0; i < triangles.Length; i++)
            {
                if(triangles[i] == null)
                {
                    triangles[i] = triangleToInsert;
                    return i;
                }
            }

            return -1;
        }

        public void LinkMesh()
        {
            //Linking all triangles with current mesh
            for(int i = 0; i < triangles.Length; i++)
                triangles[i].LinkedMesh = this;

            //Linking all vertices with their triangles
            for(int i = 0; i < vertices.Length; i++)
                vertices[i].LinkedTriangles = FindVertex(vertices[i]);

            isLinked = true;
        }

        private int GetVertexIndex(Vertex vertexToFind)
        {
            for(int i = 0; i < vertices.Length; i++)
                if(vertices[i] == vertexToFind)
                    return i;

            return -1;
        }

        private int GetTriangleIndex(Triangle triangleToFind)
        {
            for(int i = 0; i < triangles.Length; i++)
                if(triangles[i] == triangleToFind)
                    return i;

            return -1;
        }

        private Triangle[] FindVertex(Vertex vertexToFind)
        {
            List<Triangle> trianglesContainingVertex = new List<Triangle>();

            for(int i = 0; i < triangles.Length; i++)
                for(int j = 0; j < 3; j++)
                    if(triangles[i][j] == vertexToFind)
                        trianglesContainingVertex.Add(triangles[i]);

            return trianglesContainingVertex.ToArray();
        }
    }
}