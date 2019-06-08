#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;
using System.ComponentModel;
using Arithmetica.LinearAlgebra.Single;

#endregion

namespace Arithmetica.Geometry3D
{
	/// <summary>
	/// Represents a polygon in 3D space.
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Polygon : ICloneable
	{
		#region Private fields
		private List<Vector3> _points = new List<Vector3>();
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Polygon"/> class.
		/// </summary>
		public Polygon()
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Polygon"/> class.
		/// </summary>
		/// <param name="points">An array of <see cref="Vector3"/> instances.</param>
		public Polygon(Vector3[] points)
		{
			_points.AddRange(points);
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Polygon"/> class.
		/// </summary>
		/// <param name="points">A list containing <see cref="Vector3"/> instances.</param>
		public Polygon(List<Vector3> points)
		{
			_points.AddRange(points);
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Polygon"/> classu sing coordinates from another instance.
		/// </summary>
		/// <param name="polygon">A <see cref="Polygon"/> instance.</param>
		public Polygon(Polygon polygon)
		{
			_points.AddRange(polygon._points);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets the polygon's list of points.
		/// </summary>
		[XmlArrayItem(Type = typeof(Vector3))]
		public List<Vector3> Points
		{
			get { return _points; }
		}
		/// <summary>
		/// Gets the number of vertices in the polygon.
		/// </summary>
		public int Count
		{
			get
			{
				return _points.Count;
			}
		}
		#endregion

		#region ICloneable Members
		/// <summary>
		/// Creates an exact copy of this <see cref="Polygon"/> object.
		/// </summary>
		/// <returns>The <see cref="Polygon"/> object this method creates, cast as an object.</returns>
		object ICloneable.Clone()
		{
			return new Polygon(this);
		}
		/// <summary>
		/// Creates an exact copy of this <see cref="Polygon"/> object.
		/// </summary>
		/// <returns>The <see cref="Polygon"/> object this method creates.</returns>
		public Polygon Clone()
		{
			return new Polygon(this);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Flips the polygon.
		/// </summary>
		public void Flip()
		{
			_points.Reverse();
		}
		#endregion
	}
}
