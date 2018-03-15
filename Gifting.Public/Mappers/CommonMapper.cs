using System;
using Gifting.Public.ViewModels.Common;

namespace Gifting.Public.Mappers
{
	public static class CommonMapper
	{
		public static DropdownItemViewModel MapToDropdownItemViewModel<T>(this T value, Func<T, long> idSelector, Func<T, string> nameSelector)
		{
			return new DropdownItemViewModel(idSelector(value), nameSelector(value));
		}
	}
}
