using System;

namespace TextGL.Geometry.Bidimensional
{
    public struct Float2
    {
        public float X;
        public float Y;

        public Float2(float _x, float _y)
        {
            X = _x;
            Y = _y;
        }

        public static explicit operator Double2(Float2 vector)
        {
            return new Double2((double)vector.X, (double)vector.Y);
        }

        public static explicit operator Int2(Float2 vector)
        {
            return new Int2((int)vector.X, (int)vector.Y);
        }

        public static explicit operator Tridimensional.Float3(Float2 vector)
        {
            return new Tridimensional.Float3(vector.X, vector.Y, 0);
        }

        public static Float2 operator + (Float2 vector, float sumNumber)
        {
            return new Float2(vector.X + sumNumber, vector.Y + sumNumber);
        }

        public static Float2 operator + (Float2 vector, Float2 sumVector)
        {
            return new Float2(vector.X + sumVector.X, vector.Y + sumVector.Y);
        }

        public static Float2 operator - (Float2 vector, float subNumber)
        {
            return new Float2(vector.X - subNumber, vector.Y - subNumber);
        }

        public static Float2 operator - (Float2 vector, Float2 subVector)
        {
            return new Float2(vector.X - subVector.X, vector.Y - subVector.Y);
        }

        public static Float2 operator * (Float2 vector, float mulNumber)
        {
            return new Float2(vector.X * mulNumber, vector.Y * mulNumber);
        }

        public static Float2 operator * (Float2 vector, Float2 mulVector)
        {
            return new Float2(vector.X * mulVector.X, vector.Y * mulVector.Y);
        }

        public static Float2 operator / (Float2 vector, float divNumber)
        {
            return new Float2(vector.X / divNumber, vector.Y / divNumber);
        }

        public static Float2 operator / (Float2 vector, Float2 divVector)
        {
            return new Float2(vector.X / divVector.X, vector.Y / divVector.Y);
        }

        public static bool operator == (Float2 vector, Float2 equalVector)
        {
            return vector.X == equalVector.X && vector.Y == equalVector.Y ? true : false;
        }

        public static bool operator != (Float2 vector, Float2 notEqualVector)
        {
            return vector.X != notEqualVector.X && vector.Y != notEqualVector.Y ? true : false;
        }

        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType())
                if(this == (Float2)obj)
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