using System;
using System.IO;
using System.Collections.Generic;

using TextGL.Geometry.Tridimensional;

namespace TextGL.Tools
{
    public static class ModelMaker
    {
        public static Model GetRegularIcosahedron()
        {
            //Creating temp mesh to store all data;
            Mesh regularIcosahedron = new Mesh(12, 20);

            //Value necessary to calculate the vertices of a regular icosahedron that has the origin as its center
            //More informations: https://en.wikipedia.org/wiki/Regular_icosahedron#Cartesian_coordinates
            float omega = (float)((1 + Math.Sqrt(5)) / 2);

            //Vertices calculation
            Vertex a = new Vertex(new Double3(0, 1, omega));
            Vertex b = new Vertex(new Double3(0, -1, omega));
            Vertex c = new Vertex(new Double3(0, 1, -omega));
            Vertex d = new Vertex(new Double3(0, -1, -omega));
            Vertex e = new Vertex(new Double3(1, omega, 0));
            Vertex f = new Vertex(new Double3(-1, omega, 0));
            Vertex g = new Vertex(new Double3(1, -omega, 0));
            Vertex h = new Vertex(new Double3(-1, -omega, 0));
            Vertex i = new Vertex(new Double3(omega, 0, 1));
            Vertex j = new Vertex(new Double3(omega, 0, -1));
            Vertex k = new Vertex(new Double3(-omega, 0, 1));
            Vertex l = new Vertex(new Double3(-omega, 0, -1));

            //Triangles calculation and automatic edges
            regularIcosahedron.AddTriangle(a, b, k);
            regularIcosahedron.AddTriangle(b, k, h);
            regularIcosahedron.AddTriangle(b, h, g);
            regularIcosahedron.AddTriangle(b, g, i);
            regularIcosahedron.AddTriangle(i, a, e);
            regularIcosahedron.AddTriangle(a, e, f);
            regularIcosahedron.AddTriangle(a, f, k);
            regularIcosahedron.AddTriangle(f, k, l);
            regularIcosahedron.AddTriangle(k, l, h);
            regularIcosahedron.AddTriangle(f, e, c);
            regularIcosahedron.AddTriangle(f, c, l);
            regularIcosahedron.AddTriangle(g, i, j);
            regularIcosahedron.AddTriangle(i, e, j);
            regularIcosahedron.AddTriangle(e, j, c);
            regularIcosahedron.AddTriangle(d, h, g);
            regularIcosahedron.AddTriangle(d, g, j);
            regularIcosahedron.AddTriangle(d, j, c);
            regularIcosahedron.AddTriangle(d, c, l);
            regularIcosahedron.AddTriangle(d, l, h);
            regularIcosahedron.AddTriangle(a, i, b);

            //Link mesh to reduce computation time during rendering
            regularIcosahedron.LinkMesh();

            //Returning created icosahedron mesh
            return new Model(regularIcosahedron, new Vertex(new Double3(0, 0, 0)));
        }

        public static Model GetCube(double side)
        {
            double halfSide = side / 2;

            Mesh cube = new Mesh(8, 12);

            Vertex a = new Vertex(new Double3(halfSide, halfSide, halfSide));
            Vertex b = new Vertex(new Double3(halfSide, -halfSide, halfSide));
            Vertex c = new Vertex(new Double3(-halfSide, halfSide, halfSide));
            Vertex d = new Vertex(new Double3(-halfSide, -halfSide, halfSide));
            Vertex e = new Vertex(new Double3(halfSide, halfSide, -halfSide));
            Vertex f = new Vertex(new Double3(halfSide, -halfSide, -halfSide));
            Vertex g = new Vertex(new Double3(-halfSide, halfSide, -halfSide));
            Vertex h = new Vertex(new Double3(-halfSide, -halfSide, -halfSide));

            cube.AddTriangle(a, b, c);
            cube.AddTriangle(d, b, c);
            cube.AddTriangle(a, b, e);
            cube.AddTriangle(b, e, f);
            cube.AddTriangle(d, b, h);
            cube.AddTriangle(b, h, f);
            cube.AddTriangle(a, c, e);
            cube.AddTriangle(c, e, g);
            cube.AddTriangle(c, d, g);
            cube.AddTriangle(d, g, h);
            cube.AddTriangle(e, f, g);
            cube.AddTriangle(g, f, h);

            cube.LinkMesh();

            return new Model(cube, new Vertex(new Double3(0, 0, 0)));
        }
    
        public static Model GetModelFromOBJ(string pathToObj)
        {
            List<Vertex> importedVertices = new List<Vertex>();
            using(StreamReader reader = new StreamReader(pathToObj))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parsedLine = line.Split(" ");
                    if(parsedLine[0] == "v")
                    {
                        double x = double.Parse(parsedLine[1]);
                        double y = double.Parse(parsedLine[2]);
                        double z = double.Parse(parsedLine[3]);

                        importedVertices.Add(new Vertex(new Double3(x, y, z)));
                    }
                }
                reader.Close();
            }

            List<Triangle> importedTriangles = new List<Triangle>();
            using(StreamReader reader = new StreamReader(pathToObj))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parsedLine = line.Split(" ");
                    if(parsedLine[0] == "f")
                    {
                        string[] parsedItemA = parsedLine[1].Split("/");
                        string[] parsedItemB = parsedLine[2].Split("/");
                        string[] parsedItemC = parsedLine[3].Split("/");

                        int indexA = int.Parse(parsedItemA[0]) - 1;
                        int indexB = int.Parse(parsedItemB[0]) - 1;
                        int indexC = int.Parse(parsedItemC[0]) - 1;

                        importedTriangles.Add(new Triangle(importedVertices[indexA], importedVertices[indexB], importedVertices[indexC]));
                    }
                }
                reader.Close();
            }

            Mesh importedMesh = new Mesh(importedVertices, importedTriangles);
            importedMesh.LinkMesh();

            return new Model(importedMesh, new Vertex(new Double3(0, 0, 0)));
        }
    }
}