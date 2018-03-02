using System;

namespace Gifting.Core
{
	public class EntityNotFoundException : Exception
	{
		public EntityNotFoundException(int id, Type type) : this(id, $"{type.Name} with id={id} not found")
		{
		}

		public EntityNotFoundException(int id, string message) : base(message)
		{
			Id = id;
		}

		public int Id { get; }
	}
}