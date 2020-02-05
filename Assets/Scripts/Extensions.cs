using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Shooter
{
	public static partial class Extensions
	{
		public static Bounds GrowBounds(this Bounds a, Bounds b)
		{
			var max = Vector3.Max(a.max, b.max);
			var min = Vector3.Min(a.min, b.min);

			a = new Bounds((max + min) * 0.5f, max - min);

			return a;
		}

		public static bool TryBool(this string self)
		{
			return Boolean.TryParse(self, out var res) && res;
		}

		public static float TrySingle(this string self)
		{
			if (Single.TryParse(self, out var res))
			{
				return res;
			}
			return 0;
		}
	}
}
