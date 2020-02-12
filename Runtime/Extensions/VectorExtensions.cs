using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Athanor
{
	public static class VectorExtensions
	{
		#region Converting to colors
		/// <summary>
		/// Converts this vector into a color directly
		/// </summary>
		public static Color ToColor(this Vector3 vector)
		{
			return new Color(vector.x, vector.y, vector.z);
		}
		/// <summary>
		/// Converts this vector into a color, multiplying all values by the multiplier provided.
		/// </summary>
		public static Color ToColor(this Vector3 vector, float multiplier)
		{
			return new Color(vector.x * multiplier, vector.y * multiplier, vector.z * multiplier);
		}
		/// <summary>
		/// Converts this vector into a color, mapping all values to the [0,1] range.
		/// </summary>
		public static Color ToColor(this Vector3 vector, float minValue, float maxValue)
		{
			float multiplier = 1f / (maxValue - minValue);
			return new Color((vector.x + minValue) * multiplier, (vector.y + minValue) * multiplier, (vector.z + minValue) * multiplier);
		}
		#endregion
	}
}
