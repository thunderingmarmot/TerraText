using System;

namespace TextGL.Geometry.Bidimensional
{
    public struct Int2
    {
        public int X;
        public int Y;

        public Int2(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public static explicit operator Double2(Int2 vector)
        {
            return new Double2((double)vector.X, (double)vector.Y);
        }

        public static explicit operator Float2(Int2 vector)
        {
            return new Float2((float)vector.X, (float)vector.Y);
        }

        public static explicit operator Tridimensional.Int3(Int2 vector)
        {
            return new Tridimensional.Int3(vector.X, vector.Y, 0);
        }

        public static Int2 operator + (Int2 vector, int sumNumber)
        {
            return new Int2(vector.X + sumNumber, vector.Y + sumNumber);
        }

        public static Int2 operator + (Int2 vector, Int2 sumVector)
        {
            return new Int2(vector.X + sumVector.X, vector.Y + sumVector.Y);
        }

        public static Int2 operator - (Int2 vector, int subNumber)
        {
            return new Int2(vector.X - subNumber, vector.Y - subNumber);
        }

        public static Int2 operator - (Int2 vector, Int2 subVector)
        {
            return new Int2(vector.X - subVector.X, vector.Y - subVector.Y);
        }

        public static Int2 operator * (Int2 vector, int mulNumber)
        {
            return new Int2(vector.X * mulNumber, vector.Y * mulNumber);
        }

        public static Int2 operator * (Int2 vector, Int2 mulVector)
        {
            return new Int2(vector.X * mulVector.X, vector.Y * mulVector.Y);
        }

        public static Int2 operator / (Int2 vector, int divNumber)
        {
            return new Int2(vector.X / divNumber, vector.Y / divNumber);
        }

        public static Int2 operator / (Int2 vector, Int2 divVector)
        {
            return new Int2(vector.X / divVector.X, vector.Y / divVector.Y);
        }

        public static bool operator == (Int2 vector, Int2 equalVector)
        {
            return vector.X == equalVector.X && vector.Y == equalVector.Y ? true : false;
        }

        public static bool operator != (Int2 vector, Int2 notEqualVector)
        {
            return vector.X != notEqualVector.X && vector.Y != notEqualVector.Y ? true : false;
        }

        public override bool Equals(object obj)
        {
            if(this.GetType() == obj.GetType())
                if(this == (Int2)obj)
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