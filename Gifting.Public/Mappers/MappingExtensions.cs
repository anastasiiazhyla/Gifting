using System;
using System.Collections.Generic;
using System.Linq;

namespace Gifting.Public.Mappers
{
	public static class MappingExtensions
	{
		public static List<T2> MapList<T2, T1>(this List<T1> list, Func<T1, T2> selector)
		{
			return list.Select(selector).ToList();
		}

		public static T2 Map<T2, T1>(this T1 model, Func<T1, T2> selector)
		{
			return selector(model);
		}
	}
}
