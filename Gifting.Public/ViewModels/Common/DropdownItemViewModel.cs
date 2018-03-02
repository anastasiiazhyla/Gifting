namespace Gifting.Public.ViewModels.Common
{
	public struct DropdownItemViewModel
	{
		public DropdownItemViewModel(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; set; }

		public string Name { get; set; }
	}
}
