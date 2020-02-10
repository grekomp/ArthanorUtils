using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Athanor
{
	public static class StringParsingExtensions
	{
		public static bool TryParseFloatMulticultural(this string value, out float result)
		{
			if (!float.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
				!float.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
				!float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				result = default;
				return false;
			}

			return true;
		}
		public static bool TryParseIntMulticultural(this string value, out int result)
		{
			if (!int.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
				!int.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
				!int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				result = default;
				return false;
			}

			return true;
		}
		public static bool TryParseDoubleMulticultural(this string value, out double result)
		{
			if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
				!double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
				!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				result = default;
				return false;
			}

			return true;
		}
	}
}
