using System;

namespace TextGL.Geometry.Tridimensional
{
    public struct Double3
    {
        public double X;
        public double Y;
        public double Z;

        public Double3(double _x, double _y, double _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public static explicit operator Float3(Double3 vector)
        {
            return new Float3((float)vector.X, (float)vector.Y, (float)vector.Z);
        }

        public static explicit operator Int3(Double3 vector)
        {
            return new Int3((int)vector.X, (int)vector.Y, (int)vector.Z);
        }

        public static explicit operator Bidimensional.Double2(Double3 vector)
        {
            return new Bidimensional.Double2(vector.X, vector.Y);
        }

        public static Double3 operator + (Double3 vector, double sumNumber)
        {
            return new Double3(vector.X + sumNumber, vector.Y + sumNumber, vector.Z + sumNumber);
        }

        public static Double3 operator + (Double3 vector, Double3 sumVector)
        {
            return new Double3(vector.X + sumVector.X, vector.Y + sumVector.Y, vector.Z + sumVector.Z);
        }

        public static Double3 operator - (Double3 vector, double subNumber)
        {
            return new Double3(vector.X - subNumber, vector.Y - subNumber, vector.Z - subNumber);
        }

        public static Double3 operator - (Double3 vector, Double3 subVector)
        {
            return new Double3(vector.X - subVector.X, vector.Y - subVector.Y, vector.Z - subVector.Z);
        }

        public static Double3 operator * (Double3 vector, double mulNumber)
        {
            return new Double3(vector.X * mulNumber, vector.Y * mulNumber, vector.Z * mulNumber);
        }

        public static Double3 operator * (Double3 vector, Double3 mulVector)
        {
            return new Double3(vector.X * mulVector.X, vector.Y * mulVector.Y, vector.Z * mulVector.Z);
        }

        public static Double3 operator / (Double3 vector, double divNumber)
        {
            return new Double3(vector.X / divNumber, vector.Y / divNumber, vector.Z / divNumber);
        }

        public static Double3 operator / (Double3 vector, Double3 divVector)
        {
            return new Double3(vector.X / divVector.X, vector.Y / divVector.Y, vector.Z / divVector.Z);
        }

        public static bool operator == (Double3 vector, Double3 equalVector)
        {
            return vector.X == equalVector.X && vector.Y == equalVector.Y && vector.Z == equalVector.Z ? true : false;
        }

        public static bool operator != (Double3 vector, Double3 notEqualVector)
        {
            return vector.X != notEqualVector.X && vector.Y != notEqualVector.Y && vector.Z != notEqualVector.Z ? true : false;
        }

        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType())
                if(this == (Double3)obj)
                    return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return X + "|" + Y + "|" + Z;
        }
    }
}