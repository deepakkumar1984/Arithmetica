#region Using directives
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Arithmetica.LinearAlgebra.Single;
#endregion


namespace Arithmetica.Geometry2D
{
	/// <summary>
	/// Provides methods for computing diatnces between geometric primitives
	/// in 2D space.
	/// </summary>
	public static class DistanceMethods
	{
		#region Point-Point
		/// <summary>
		/// Calculates the squared distance between two points.
		/// </summary>
		/// <param name="p0">A <see cref="Vector2"/> instance.</param>
		/// <param name="p1">A <see cref="Vector2"/> instance.</param>
		/// <returns>The squared distance between the two points.</returns>
		public static float SquaredDistance(Vector2 p0, Vector2 p1)
		{
			Vector2 diff = p0 - p1;
			return diff.GetLengthSquared();
		}
		/// <summary>
		/// Calculates the distance between two points.
		/// </summary>
		/// <param name="p0">A <see cref="Vector2"/> instance.</param>
		/// <param name="p1">A <see cref="Vector2"/> instance.</param>
		/// <returns>The distance between the two points.</returns>
		public static float Distance(Vector2 p0, Vector2 p1)
		{
			Vector2 diff = p0 - p1;
			return diff.GetLength();
		}
		#endregion

		#region Point-Segment
		/// <summary>
		/// Calculates the squared distance between a point and a segment.
		/// </summary>
		/// <param name="point">A <see cref="Vector2"/> instance.</param>
		/// <param name="segment">A <see cref="Segment"/> instance.</param>
		/// <returns>The squared distance between the point and the segment.</returns>
		public static float SquaredDistance(Vector2 point, Segment segment)
		{
			Vector2 D = segment.P1 - segment.P0;
			Vector2 diffPointP0 = point - segment.P0;
			float t = Vector2.DotProduct(D, diffPointP0);

			if (t <= 0)
			{
				// segment.P0 is the closest to point.
				return Vector2.DotProduct(diffPointP0, diffPointP0);
			}

			float DdD = Vector2.DotProduct(D, D);
			if (t >= DdD)
			{
				// segment.P1 is the closest to point.
				Vector2 diffPointP1 = point - segment.P1;
				return Vector2.DotProduct(diffPointP1, diffPointP1);
			}
			
			// Closest point is inside the segment.
			return Vector2.DotProduct(diffPointP0, diffPointP0) - t * t / DdD;
		}
		/// <summary>
		/// Calculates the squared distance between a point and a segment.
		/// </summary>
		/// <param name="point">A <see cref="Vector2"/> instance.</param>
		/// <param name="segment">A <see cref="Segment"/> instance.</param>
		/// <returns>The squared distance between the point and the segment.</returns>
		public static float Distance(Vector2 point, Segment segment)
		{
			return (float)System.Math.Sqrt(SquaredDistance(point, segment));
		}
		#endregion

		#region Point-Ray
		/// <summary>
		/// Calculates the squared distance between a given point and a given ray.
		/// </summary>
		/// <param name="point">A <see cref="Vector2"/> instance.</param>
		/// <param name="ray">A <see cref="Ray"/> instance.</param>
		/// <returns>The squared distance between the point and the ray.</returns>
		public static float SquaredDistance(Vector2 point, Ray ray)
		{
			Vector2 diff = point - ray.Origin;
			float t = Vector2.DotProduct(diff, ray.Direction);

			if (t <= 0.0f)
			{
				return diff.GetLengthSquared();
			}
			else
			{
				t = (t * t) / ray.Direction.GetLengthSquared();
				return diff.GetLengthSquared() - t;
			}
		}
		/// <summary>
		/// Calculates the distance between a given point and a given ray.
		/// </summary>
		/// <param name="point">A <see cref="Vector2"/> instance.</param>
		/// <param name="ray">A <see cref="Ray"/> instance.</param>
		/// <returns>The distance between the point and the ray.</returns>
		public static float Distance(Vector2 point, Ray ray)
		{
			return (float)System.Math.Sqrt(SquaredDistance(point, ray));
		}
		#endregion

		#region Point-Oriented Box
		/// <summary>
		/// Calculates the squared distance between a point and an oriented box.
		/// </summary>
		/// <param name="point">A <see cref="Vector2"/> instance.</param>
		/// <param name="box">An <see cref="OrientedBox"/> instance.</param>
		/// <returns>The squared distance between the point and the oriented box.</returns>
		public static float SquaredDistance(Vector2 point, OrientedBox box)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// Calculates the distance between a point and an oriented box.
		/// </summary>
		/// <param name="point">A <see cref="Vector2"/> instance.</param>
		/// <param name="box">An <see cref="OrientedBox"/> instance.</param>
		/// <returns>The distance between the point and the oriented box.</returns>
		public static float Distance(Vector2 point, OrientedBox box)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Ray-Ray
		/// <summary>
		/// Calculates the squared distance between two rays.
		/// </summary>
		/// <param name="r0">A <see cref="Ray"/> instance.</param>
		/// <param name="r1">A <see cref="Ray"/> instance.</param>
		/// <returns>Returns the squared distance between two rays.</returns>
		public static float SquaredDistance(Ray r0, Ray r1)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// Calculates the distance between two rays.
		/// </summary>
		/// <param name="r0">A <see cref="Ray"/> instance.</param>
		/// <param name="r1">A <see cref="Ray"/> instance.</param>
		/// <returns>Returns the distance between two rays.</returns>
		public static float Distance(Ray r0, Ray r1)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Segment-Segment
		/// <summary>
		/// Calculates the squared distance between two segments.
		/// </summary>
		/// <param name="s0">A <see cref="Segment"/> instance.</param>
		/// <param name="s1">A <see cref="Segment"/> instance.</param>
		/// <returns>Returns the squared distance between two segments.</returns>
		public static float SquaredDistance(Segment s0, Segment s1)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// Calculates the distance between two segments.
		/// </summary>
		/// <param name="s0">A <see cref="Segment"/> instance.</param>
		/// <param name="s1">A <see cref="Segment"/> instance.</param>
		/// <returns>Returns the distance between two segments.</returns>
		public static float Distance(Segment s0, Segment s1)
		{
			throw new NotImplementedException();
		}
		#endregion


	}
}
