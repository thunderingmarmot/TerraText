using System;

namespace TextGL.Geometry.Tridimensional
{
    public struct Float3
    {
        public float X;
        public float Y;
        public float Z;

        public Float3(float _x, float _y, float _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public static explicit operator Double3(Float3 vector)
        {
            return new Double3((double)vector.X, (double)vector.Y, (double)vector.Z);
        }

        public static explicit operator Int3(Float3 vector)
        {
            return new Int3((int)vector.X, (int)vector.Y, (int)vector.Z);
        }

        public static explicit operator Bidimensional.Float2(Float3 float3)
        {
            return new Bidimensional.Float2(float3.X, float3.Y);
        }

        public static Float3 operator + (Float3 vector, float sumNumber)
        {
            return new Float3(vector.X + sumNumber, vector.Y + sumNumber, vector.Z + sumNumber);
        }

        public static Float3 operator + (Float3 vector, Float3 sumVector)
        {
            return new Float3(vector.X + sumVector.X, vector.Y + sumVector.Y, vector.Z + sumVector.Z);
        }

        public static Float3 operator - (Float3 vector, float subNumber)
        {
            return new Float3(vector.X - subNumber, vector.Y - subNumber, vector.Z - subNumber);
        }

        public static Float3 operator - (Float3 vector, Float3 subVector)
        {
            return new Float3(vector.X - subVector.X, vector.Y - subVector.Y, vector.Z - subVector.Z);
        }

        public static Float3 operator * (Float3 vector, float mulNumber)
        {
            return new Float3(vector.X * mulNumber, vector.Y * mulNumber, vector.Z * mulNumber);
        }

        public static Float3 operator * (Float3 vector, Float3 mulVector)
        {
            return new Float3(vector.X * mulVector.X, vector.Y * mulVector.Y, vector.Z * mulVector.Z);
        }

        public static Float3 operator / (Float3 vector, float divNumber)
        {
            return new Float3(vector.X / divNumber, vector.Y / divNumber, vector.Z / divNumber);
        }

        public static Float3 operator / (Float3 vector, Float3 divVector)
        {
            return new Float3(vector.X / divVector.X, vector.Y / divVector.Y, vector.Z / divVector.Z);
        }

        public static bool operator == (Float3 vector, Float3 equalVector)
        {
            return vector.X == equalVector.X && vector.Y == equalVector.Y && vector.Z == equalVector.Z ? true : false;
        }

        public static bool operator != (Float3 vector, Float3 notEqualVector)
        {
            return vector.X != notEqualVector.X && vector.Y != notEqualVector.Y && vector.Z != notEqualVector.Z ? true : false;
        }

        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType())
                if(this == (Float3)obj)
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