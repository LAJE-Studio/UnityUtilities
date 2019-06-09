using UnityEngine;

namespace UnityUtilities
{
    public static class VectorUtility
    {
        public static string ToPrecisionString(this Vector2 vector)
        {
            return string.Format("({0}, {1})", vector.x, vector.y);
        }

        public static Vector2 Multiply(this Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 ToFloat(this Vector2Int a)
        {
            return new Vector2(a.x, a.y);
        }

        public static Vector3Int ToVector3(this Vector2Int a, int z = 0)
        {
            return new Vector3Int(a.x, a.y, z);
        }

        public static Vector2Int ToVector2(this Vector3Int a)
        {
            return new Vector2Int(a.x, a.y);
        }

        /// <summary>
        /// Get the minimum X and the minimum Y between the vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2Int Min(Vector2Int left, Vector2Int right)
        {
            return new Vector2Int(Mathf.Min(left.x, right.x), Mathf.Min(left.y, right.y));
        }

        /// <summary>
        /// Get the minimum X and the minimum Y between the vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 Min(Vector2 left, Vector2 right)
        {
            return new Vector2(Mathf.Min(left.x, right.x), Mathf.Min(left.y, right.y));
        }

        /// <summary>
        /// Get the maximum X and the minimum Y between the vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2Int Max(Vector2Int left, Vector2Int right)
        {
            return new Vector2Int(Mathf.Max(left.x, right.x), Mathf.Max(left.y, right.y));
        }

        /// <summary>
        /// Get the maximum X and the minimum Y between the vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 Max(Vector2 left, Vector2 right)
        {
            return new Vector2(Mathf.Max(left.x, right.x), Mathf.Max(left.y, right.y));
        }

        /// <summary>
        /// Get a new vector with X and Y round to down values
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2Int FloorToInt(this Vector2 vector)
        {
            return new Vector2Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
        }

        /// <summary>
        /// Get a new vector with X and Y round to down values
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 Floor(this Vector2 vector)
        {
            return new Vector2(Mathf.Floor(vector.x), Mathf.Floor(vector.y));
        }

        /// <summary>
        /// Get a new vector with X and Y rounded values
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2Int RoundToInt(this Vector2 vector)
        {
            return new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
        }

        /// <summary>
        /// Get a new vector with X and Y rounded values
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 Round(this Vector2 vector)
        {
            return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
        }

        /// <summary>
        /// Get a new vector with X and Y round to up values
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2Int CeilToInt(this Vector2 vector)
        {
            return new Vector2Int(Mathf.CeilToInt(vector.x), Mathf.CeilToInt(vector.y));
        }

        /// <summary>
        /// Get a new vector with X and Y round to up values
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 Ceil(this Vector2 vector)
        {
            return new Vector2(Mathf.Ceil(vector.x), Mathf.Ceil(vector.y));
        }

        /// <summary>
        /// Get a new vector with X and Y clamped
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static Vector2Int Clamp(this Vector2Int vector, int minValue, int maxValue)
        {
            return new Vector2Int(Mathf.Clamp(vector.x, minValue, maxValue), Mathf.Clamp(vector.y, minValue, maxValue));
        }

        /// <summary>
        /// Get a new vector with X and Y clamped
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static Vector2 Clamp(this Vector2 vector, float minValue, float maxValue)
        {
            return new Vector2(Mathf.Clamp(vector.x, minValue, maxValue), Mathf.Clamp(vector.y, minValue, maxValue));
        }

        /// <summary>
        /// Get a new vector with X and Y values always positive
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2Int Absolute(this Vector2Int vector)
        {
            return new Vector2Int(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }

        /// <summary>
        /// Get a new vector with X and Y values always positive
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 Absolute(this Vector2 vector)
        {
            return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }

        /// <summary>
        /// Return a new normalized vector
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 Normalized(this Vector2Int vector)
        {
            return ((Vector2)vector).normalized;
        }

        /// <summary>
        /// Converts a rad angle to Vector2
        /// </summary>
        /// <param name="radAngle"></param>
        /// <returns></returns>
        public static Vector2 RadToVector2(float radAngle)
        {
            return new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
        }

        /// <summary>
        /// Converts a degree angle to Vector2
        /// </summary>
        /// <param name="degAngle"></param>
        /// <returns></returns>
        public static Vector2 DegToVector2(float degAngle)
        {
            return RadToVector2(degAngle * Mathf.Deg2Rad);
        }

        /// <summary>
        /// Get the angle in Degree
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float AngleDegree(this Vector2Int vector)
        {
            return Mathf.Rad2Deg * Angle(vector);
        }

        /// <summary>
        /// Get the angle in Degree
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float AngleDegree(this Vector2 vector)
        {
            return Angle(vector) * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Get the angle in Rad
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float Angle(this Vector2Int vector)
        {
            return Mathf.Atan2(vector.y, vector.x);
        }

        /// <summary>
        /// Get the angle in Rad
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float Angle(this Vector2 vector)
        {
            return Mathf.Atan2(vector.y, vector.x);
        }
    }
}