namespace Gifting.Public.ViewModels.Common
{
	public struct DropdownItemViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public DropdownItemViewModel(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
