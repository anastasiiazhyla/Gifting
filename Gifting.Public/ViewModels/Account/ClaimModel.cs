namespace Gifting.Public.ViewModels.Account
{
	public class ClaimModel
	{
		public ClaimModel(string type, string value)
		{
			Type = type;
			Value = value;
		}

		public string Type { get; set; }

		public string Value { get; set; }
	}
}
