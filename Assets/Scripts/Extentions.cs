using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
	public static class Extentions
	{
		public static bool TryBool(this string self)
		{
			return Boolean.TryParse(self, out var res) && res;
		}
	}
}
