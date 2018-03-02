namespace Gifting.DataAccess
{
	public static class StoredProcedures
	{
		public static class User
		{
			public static string GetById = "User_GetById";
			public static string GetByUsername = "User_GetByUsername";
			public static string Create = "User_Create";
			public static string Update = "User_Update";
		}
	}
}