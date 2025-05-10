using System;
using Volo.Abp.Domain.Entities.Events;

namespace TodoTask.Events
{
	public class TodoCompletedEvent : EntityEventData<Guid>
	{
		public TodoCompletedEvent(Guid entityId) : base(entityId)
		{
		}
	}
}
