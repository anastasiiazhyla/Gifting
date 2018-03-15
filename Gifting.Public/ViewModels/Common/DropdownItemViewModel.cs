namespace Gifting.Public.ViewModels.Common
{
	public struct DropdownItemViewModel
	{
		public DropdownItemViewModel(long id, string name)
		{
			Id = id;
			Name = name;
		}

		public long Id { get; set; }

		public string Name { get; set; }
	}
}
