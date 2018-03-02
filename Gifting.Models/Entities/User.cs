namespace Gifting.Models.Entities
{
	public class User
	{
		public User()
		{
		}

		public User(string firstName, string lastName, string email, string username, string passwordHash)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Username = username;
			PasswordHash = passwordHash;
		}

		public User(long id, string firstName, string lastName, string email, string username, string passwordHash) : this (firstName, lastName, email, username, passwordHash)
		{
			Id = id;
		}

		public long Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Username { get; set; }

		public string PasswordHash { get; set; }
	}
}
