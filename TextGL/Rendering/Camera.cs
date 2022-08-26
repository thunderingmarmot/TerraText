using System;

using TextGL.Geometry.Tridimensional;
using TextGL.Geometry.Bidimensional;

namespace TextGL.Rendering
{
    public abstract class Camera
    {
        protected Space viewedSpace;
        protected Double3 position;
        public Double3 Position { get => position; }
        protected double focalLength;

        protected double aspectLength;
        protected double aspectHeight;

        protected int resolutionLength;
        protected int resolutionHeight;

        protected ProjectedTriangle[] projectedTriangles;

        public Camera(int _resolutionLength, int _resolutionHeight, double _aspectLength, double _aspectHeight, double _focalLength, Space _viewedSpace, Double3 _postion)
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

        public void UpdateProjectionArrays()
        {
            int trianglesCount = 0;

            for(int i = 0; i < viewedSpace.Models.Count; i++)
                trianglesCount += viewedSpace.Models[i].GeometryMesh.Triangles.Length;

            projectedTriangles = new ProjectedTriangle[trianglesCount];

            for(int i = 0; i < projectedTriangles.Length; i++)
            {
                projectedTriangles[i] = new ProjectedTriangle();
                projectedTriangles[i].ProjectedVertexA = new ProjectedVertex();
                projectedTriangles[i].ProjectedVertexB = new ProjectedVertex();
                projectedTriangles[i].ProjectedVertexC = new ProjectedVertex();
            }

            for(int i = 0; i < viewedSpace.Models.Count; i++)
            {
                for(int j = 0; j < viewedSpace.Models[i].GeometryMesh.Triangles.Length; j++)
                {
                    projectedTriangles[j].OriginalTriangle = viewedSpace.Models[i].GeometryMesh.Triangles[j];
                    projectedTriangles[j].ProjectedVertexA.OriginalVertex = viewedSpace.Models[i].GeometryMesh.Triangles[j].VertexA;
                    projectedTriangles[j].ProjectedVertexB.OriginalVertex = viewedSpace.Models[i].GeometryMesh.Triangles[j].VertexB;
                    projectedTriangles[j].ProjectedVertexC.OriginalVertex = viewedSpace.Models[i].GeometryMesh.Triangles[j].VertexC;
                }
            }
        }

        public void Translate(Double3 direction)
        {
            position += direction;
        }

        ////////////////////////////////////

        public enum RenderType
        {
            Normal,
            Wireframe,
            VerticesOnly,
            Everything
        }

        protected bool AreViewportCoordinatesValid(Double2 viewportCoordinates)
        {
            /*float viewportLimitUp = aspectRatio.Height / 2;
            float viewportLimitDown = -(aspectRatio.Height / 2);
            float viewportLimitRight = aspectRatio.Length / 2;
            float viewportLimitLeft = -(aspectRatio.Length / 2);

            if(viewportCoordinates.X < viewportLimitRight && viewportCoordinates.X > viewportLimitLeft && viewportCoordinates.Y < viewportLimitUp && viewportCoordinates.Y > viewportLimitUp)
                return true;
            else
                return false;*/

            return true;
        }

        public Double2? WorldToViewportCoordinates(Double3 worldCoordinates)
        {
            double focalLengthSubjectDistanceRatio = focalLength / viewedSpace.GetDistanceZ(worldCoordinates, position);
            Double2 projectedPosition = new Double2(worldCoordinates.X * focalLengthSubjectDistanceRatio, worldCoordinates.Y * focalLengthSubjectDistanceRatio);

            if(AreViewportCoordinatesValid(projectedPosition))
                return projectedPosition;
            else
                return null;
        }

        public Double2? ScreenToViewportCoordinates(Int2 screenCoordinates)
        {
            double viewportMultiplierX = (resolutionLength / aspectLength);
            double viewportMultiplierY = (resolutionHeight / aspectHeight);

            return new Double2(screenCoordinates.X / viewportMultiplierX, screenCoordinates.Y / viewportMultiplierY);
        }

        public Int2? ViewportToScreenCoordinates(Double2 viewportCoordinates)
        {
            double viewportMultiplierX = (resolutionLength / aspectLength);
            double viewportMultiplierY = (resolutionHeight / aspectHeight);

            if(AreViewportCoordinatesValid(viewportCoordinates))
                return (Int2)(new Double2(viewportCoordinates.X * viewportMultiplierX, viewportCoordinates.Y * viewportMultiplierY));
            else
                return null;
        }

        ////////////////////////////////////

        public void ProjectVertices()
        {
            for(int i = 0; i < viewedSpace.Models.Count; i++)
            {
                for(int j = 0; j < viewedSpace.Models[i].GeometryMesh.Triangles.Length; j++)
                {
                    projectedTriangles[j].ProjectedVertexA.Position = (Double2)WorldToViewportCoordinates(viewedSpace.Models[i].GeometryMesh.Triangles[j].VertexA.Position);
                    projectedTriangles[j].ProjectedVertexB.Position = (Double2)WorldToViewportCoordinates(viewedSpace.Models[i].GeometryMesh.Triangles[j].VertexB.Position);
                    projectedTriangles[j].ProjectedVertexC.Position = (Double2)WorldToViewportCoordinates(viewedSpace.Models[i].GeometryMesh.Triangles[j].VertexC.Position);
                }
            }
        }

        protected abstract void BeforeRasterize();
        protected abstract void BeforeDraw();

        protected abstract void DrawPixel();
        protected abstract void DrawEmpty();
        
        protected abstract void AfterLine();
        protected abstract void AfterRasterize();

        public void RasterizeImage(RenderType renderType = RenderType.Normal)
        {
            Func<ProjectedTriangle, Int2, bool> rasterMethod = RasterNormal;
            if(renderType == RenderType.Normal)
                rasterMethod = RasterNormal;
            else if(renderType == RenderType.Wireframe)
                rasterMethod = RasterWireframe;
            else if(renderType == RenderType.VerticesOnly)
                rasterMethod = RasterVerticesOnly;
            else if(renderType == RenderType.Everything)
                rasterMethod = RasterEverything;

            BeforeRasterize();
            int indexI = resolutionHeight / 2;
            for(int i = 0; i < resolutionHeight; i++)
            {
                int indexJ = -(resolutionLength / 2);
                for(int j = 0; j < resolutionLength; j++)
                {
                    BeforeDraw();

                    bool drawPixel = false;
                    for(int k = 0; k < projectedTriangles.Length; k++)
                        if(rasterMethod(projectedTriangles[k], new Int2(indexJ, indexI)))
                            drawPixel = true;

                    if(drawPixel)
                        DrawPixel();
                    else
                        DrawEmpty();

                    indexJ++;
                }
                AfterLine();
                indexI--;
            }
            AfterRasterize();
        }

        private bool RasterNormal(ProjectedTriangle triangle, Int2 pixelCoords)
        {
            Double2 viewportCoords = (Double2)ScreenToViewportCoordinates(pixelCoords);
            return triangle.PointInTriangle(viewportCoords)
                || triangle.PointOnTriangle(viewportCoords);
        }

        private bool RasterWireframe(ProjectedTriangle triangle, Int2 pixelCoords)
        {
            Double2 viewportCoords = (Double2)ScreenToViewportCoordinates(pixelCoords);
            return triangle.PointOnTriangle(viewportCoords, 0.005)
                || triangle.PointIsVertex(viewportCoords, 0.005);
        }

        private bool RasterVerticesOnly(ProjectedTriangle triangle, Int2 pixelCoords)
        {
            Double2 viewportCoords = (Double2)ScreenToViewportCoordinates(pixelCoords);
            return triangle.PointIsVertex(viewportCoords, 0.005);
        }

        private bool RasterEverything(ProjectedTriangle triangle, Int2 pixelCoords)
        {
            Double2 viewportCoords = (Double2)ScreenToViewportCoordinates(pixelCoords);
            return triangle.PointInTriangle(viewportCoords)
                || triangle.PointOnTriangle(viewportCoords)
                || triangle.PointIsVertex(viewportCoords);
        }
    }
}