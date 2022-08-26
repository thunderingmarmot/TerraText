using System;

namespace TextGL.Geometry.Tridimensional
{
    public struct Int3
    {
        public int X;
        public int Y;
        public int Z;

        public Int3(int _x, int _y, int _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public static explicit operator Double3(Int3 vector)
        {
            return new Double3((double)vector.X, (double)vector.Y, (double)vector.Z);
        }

        public static explicit operator Float3(Int3 vector)
        {
            return new Float3((float)vector.X, (float)vector.Y, (float)vector.Z);
        }

        public static explicit operator Bidimensional.Int2(Int3 vector)
        {
            return new Bidimensional.Int2(vector.X, vector.Y);
        }

        public static Int3 operator + (Int3 vector, int sumNumber)
        {
            return new Int3(vector.X + sumNumber, vector.Y + sumNumber, vector.Z + sumNumber);
        }

        public static Int3 operator + (Int3 vector, Int3 sumVector)
        {
            return new Int3(vector.X + sumVector.X, vector.Y + sumVector.Y, vector.Z + sumVector.Z);
        }

        public static Int3 operator - (Int3 vector, int subNumber)
        {
            return new Int3(vector.X - subNumber, vector.Y - subNumber, vector.Z - subNumber);
        }

        public static Int3 operator - (Int3 vector, Int3 subVector)
        {
            return new Int3(vector.X - subVector.X, vector.Y - subVector.Y, vector.Z - subVector.Z);
        }

        public static Int3 operator * (Int3 vector, int mulNumber)
        {
            return new Int3(vector.X * mulNumber, vector.Y * mulNumber, vector.Z - mulNumber);
        }

        public static Int3 operator * (Int3 vector, Int3 mulVector)
        {
            return new Int3(vector.X * mulVector.X, vector.Y * mulVector.Y, vector.Z * mulVector.Z);
        }

        public static Int3 operator / (Int3 vector, int divNumber)
        {
            return new Int3(vector.X / divNumber, vector.Y / divNumber, vector.Z / divNumber);
        }

        public static Int3 operator / (Int3 vector, Int3 divVector)
        {
            return new Int3(vector.X / divVector.X, vector.Y / divVector.Y, vector.Z / divVector.Z);
        }

        public static bool operator == (Int3 vector, Int3 equalVector)
        {
            return vector.X == equalVector.X && vector.Y == equalVector.Y && vector.Z == equalVector.Z ? true : false;
        }

        public static bool operator != (Int3 vector, Int3 notEqualVector)
        {
            return vector.X != notEqualVector.X && vector.Y != notEqualVector.Y && vector.Z != notEqualVector.Z ? true : false;
        }

        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType())
                if(this == (Int3)obj)
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