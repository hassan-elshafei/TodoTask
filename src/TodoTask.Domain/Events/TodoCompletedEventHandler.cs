using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace TodoTask.Events
{
	public class TodoCompletedEventHandler : ILocalEventHandler<TodoCompletedEvent>, ITransientDependency
	{
		public Task HandleEventAsync(TodoCompletedEvent eventData)
		{
			Console.WriteLine($"[✔️ EVENT] Todo Completed: {eventData.Entity}");
			return Task.CompletedTask;
		}
	}
}
