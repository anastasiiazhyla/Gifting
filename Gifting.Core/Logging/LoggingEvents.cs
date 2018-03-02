namespace Gifting.Core.Logging
{
	public class LoggingEvents
	{
		public class Info
		{
			public const int ListItems = 1000;
			public const int GetItem = 1001;
			public const int InsertItem = 1002;
			public const int UpdateItem = 1003;
			public const int DeleteItem = 1004;
		}

		public class Warning
		{
			public const int GetItemNotFound = 2000;
			public const int UpdateItemNotFound = 2001;
			public const int DeleteItemNotFound = 2002;
		}
	}
}
