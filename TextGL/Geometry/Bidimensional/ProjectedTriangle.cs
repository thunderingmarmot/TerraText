using System;

namespace TextGL.Geometry.Bidimensional
{
    public class ProjectedTriangle
    {
        public Tridimensional.Triangle OriginalTriangle;

        public ProjectedVertex ProjectedVertexA;
        public ProjectedVertex ProjectedVertexB;
        public ProjectedVertex ProjectedVertexC;

        public bool PointInTriangle(Double2 point)
        {
            double p0x = ProjectedVertexA.Position.X;
            double p0y = ProjectedVertexA.Position.Y;
            double p1x = ProjectedVertexB.Position.X;
            double p1y = ProjectedVertexB.Position.Y;
            double p2x = ProjectedVertexC.Position.X;
            double p2y = ProjectedVertexC.Position.Y;

            double Area = 0.5f *(-p1y*p2x + p0y*(-p1x + p2x) + p0x*(p1y - p2y) + p1x*p2y);

            double s = 1/(2*Area)*(p0y*p2x - p0x*p2y + (p2y - p0y)*point.X + (p0x - p2x)*point.Y);
            double t = 1/(2*Area)*(p0x*p1y - p0y*p1x + (p0y - p1y)*point.X + (p1x - p0x)*point.Y);

            return (s > 0) && (t > 0) && ((1 - s - t) > 0);
        }

        public bool PointOnTriangle(Double2 point, double epsilon = 0.02)
        {
            return PointOnSide(ProjectedVertexA.Position, ProjectedVertexB.Position, point, epsilon)
                || PointOnSide(ProjectedVertexB.Position, ProjectedVertexC.Position, point, epsilon)
                || PointOnSide(ProjectedVertexC.Position, ProjectedVertexA.Position, point, epsilon);
        }

        public bool PointIsVertex(Double2 point, double epsilon = 0.02)
        {
            if(Math.Abs(point.X - ProjectedVertexA.Position.X) < epsilon
            && Math.Abs(point.Y - ProjectedVertexA.Position.Y) < epsilon
            || Math.Abs(point.X - ProjectedVertexB.Position.X) < epsilon
            && Math.Abs(point.Y - ProjectedVertexB.Position.Y) < epsilon
            || Math.Abs(point.X - ProjectedVertexC.Position.X) < epsilon
            && Math.Abs(point.Y - ProjectedVertexC.Position.Y) < epsilon)
                return true;
            else
                return false;
        }

        private bool PointOnSide(Double2 sidePointA, Double2 sidePointB, Double2 point, double epsilon = 0.02)
        {
            double minX = Math.Min(sidePointA.X, sidePointB.X);
            double maxX = Math.Max(sidePointA.X, sidePointB.X);

            double minY = Math.Min(sidePointA.Y, sidePointB.Y);
            double maxY = Math.Max(sidePointA.Y, sidePointB.Y);

            if (!(minX <= point.X) || !(point.X <= maxX) || !(minY <= point.Y) || !(point.Y <= maxY))
                return false;
            
            if (Math.Abs(sidePointA.X - sidePointB.X) < epsilon)
                return Math.Abs(sidePointA.X - point.X) < epsilon || Math.Abs(sidePointB.X - point.X) < epsilon;
            
            if (Math.Abs(sidePointA.Y - sidePointB.Y) < epsilon)
                return Math.Abs(sidePointA.Y - point.Y) < epsilon || Math.Abs(sidePointB.Y - point.Y) < epsilon;

            if (Math.Abs((point.X - sidePointA.X) / (sidePointB.X - sidePointA.X) - (point.Y - sidePointA.Y) / (sidePointB.Y - sidePointA.Y)) < epsilon)
                return true;
            else
                return false;
        }
    }
}