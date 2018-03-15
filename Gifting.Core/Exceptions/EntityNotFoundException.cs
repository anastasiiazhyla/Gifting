using System;

namespace Gifting.Core
{
	public class EntityNotFoundException : Exception
	{
		public EntityNotFoundException(long id, Type type) : this(id, $"{type.Name} with id={id} not found")
		{
		}

		public EntityNotFoundException(long id, string message) : base(message)
		{
			Id = id;
		}

		public long Id { get; }
	}
}