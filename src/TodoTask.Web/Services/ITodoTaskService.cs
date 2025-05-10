using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoTask.Entities;

namespace TodoTask.Web.Services
{
	public interface ITodoTaskService
	{
		Task<List<TodoDto>> GetTodosAsync(string? status = null, string? priority = null,
										 DateTime? from = null, DateTime? to = null,
										 string? sortBy = null);
		Task<TodoDto> GetTodoAsync(Guid id);
		Task CreateTodoAsync(CreateUpdateTodoDto todo);
		Task UpdateTodoAsync(Guid id, CreateUpdateTodoDto todo);
		Task DeleteTodoAsync(Guid id);
		Task MarkCompleteAsync(Guid id);
	}
}
