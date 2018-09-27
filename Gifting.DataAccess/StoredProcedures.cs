namespace Gifting.DataAccess
{
	public static class StoredProcedures
	{
		public static class Idea
		{
			public static string Delete = "Idea_Delete";
			public static string Create = "Idea_Create";
			public static string Update = "Idea_Update";
			public static string GetById = "Idea_GetById";
			public static string GetByUserId = "Idea_GetByUserId";
			public static string GetAll = "Idea_GetAll";
		}

		public static class User
		{
			public static string GetById = "User_GetById";
			public static string GetByUsername = "User_GetByUsername";
			public static string Create = "User_Create";
			public static string Update = "User_Update";
			public static string Delete = "User_Delete";
		}

		public static class Grantee
		{
			public static string Create = "Grantee_Create";
			public static string Update = "Grantee_Update";
			public static string Delete = "Grantee_Delete";
			public static string GetById = "Grantee_GetById";
			public static string GetByUserId = "Grantee_GetByUserId";
		}

		public static class Occasion
		{
			public static string Create = "Occasion_Create";
			public static string Update = "Occasion_Update";
			public static string Delete = "Occasion_Delete";
			public static string GetById = "Occasion_GetById";
			public static string GetByUserId = "Occasion_GetByUserId";
		}

		public static class IdeaGrantee
		{
			public static string Create = "IdeaGrantee_Create";
			public static string Update = "IdeaGrantee_Update";
		}

		public static class IdeaOccasion
		{
			public static string Create = "IdeaOccasion_Create";
			public static string Update = "IdeaOccasion_Update";
		}
	}
}