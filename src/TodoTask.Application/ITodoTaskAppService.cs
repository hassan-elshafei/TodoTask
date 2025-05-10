using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoTask.Entities;
using Volo.Abp.Application.Services;

namespace TodoTask
{
	public interface ITodoTaskAppService : IApplicationService
	{
		Task<List<TodoDto>> GetListAsync(string? status = null, string? priority = null, DateTime? from = null, DateTime? to = null, string? sortBy = null);
		Task<TodoDto> GetAsync(Guid id);
		Task<TodoDto> CreateAsync(CreateUpdateTodoDto input);
		Task<TodoDto> UpdateAsync(Guid id, CreateUpdateTodoDto input);
		Task DeleteAsync(Guid id);
		Task MarkCompleteAsync(Guid id);
	}
}
