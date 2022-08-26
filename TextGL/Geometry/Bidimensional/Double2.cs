using System;

namespace TextGL.Geometry.Bidimensional
{
    public struct Double2
    {
        public double X;
        public double Y;

        public Double2(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }

        public static explicit operator Float2(Double2 vector)
        {
            return new Float2((float)vector.X, (float)vector.Y);
        }

        public static explicit operator Int2(Double2 vector)
        {
            return new Int2((int)vector.X, (int)vector.Y);
        }

        public static explicit operator Tridimensional.Double3(Double2 vector)
        {
            return new Tridimensional.Double3(vector.X, vector.Y, 0);
        }

        public static Double2 operator + (Double2 vector, double sumNumber)
        {
            return new Double2(vector.X + sumNumber, vector.Y + sumNumber);
        }

        public static Double2 operator + (Double2 vector, Double2 sumVector)
        {
            return new Double2(vector.X + sumVector.X, vector.Y + sumVector.Y);
        }

        public static Double2 operator - (Double2 vector, double subNumber)
        {
            return new Double2(vector.X - subNumber, vector.Y - subNumber);
        }

        public static Double2 operator - (Double2 vector, Double2 subVector)
        {
            return new Double2(vector.X - subVector.X, vector.Y - subVector.Y);
        }

        public static Double2 operator * (Double2 vector, double mulNumber)
        {
            return new Double2(vector.X * mulNumber, vector.Y * mulNumber);
        }

        public static Double2 operator * (Double2 vector, Double2 mulVector)
        {
            return new Double2(vector.X * mulVector.X, vector.Y * mulVector.Y);
        }

        public static Double2 operator / (Double2 vector, double divNumber)
        {
            return new Double2(vector.X / divNumber, vector.Y / divNumber);
        }

        public static Double2 operator / (Double2 vector, Double2 divVector)
        {
            return new Double2(vector.X / divVector.X, vector.Y / divVector.Y);
        }

        public static bool operator == (Double2 vector, Double2 equalVector)
        {
            return vector.X == equalVector.X && vector.Y == equalVector.Y ? true : false;
        }

        public static bool operator != (Double2 vector, Double2 notEqualVector)
        {
            return vector.X != notEqualVector.X && vector.Y != notEqualVector.Y ? true : false;
        }

        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType())
                if(this == (Double2)obj)
                    return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return X + "|" + Y;
        }
    }
}