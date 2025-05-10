using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoTask.Entities;
using TodoTask.Events;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Local;

namespace TodoTask;

/* Inherit your application services from this class.
 */
public class TodoTaskAppService : ApplicationService, ITodoTaskAppService
{
    private readonly IRepository<Todo, Guid> _todoRepository;
    private readonly ILocalEventBus _localEventBus;
    public TodoTaskAppService(IRepository<Todo, Guid> todoRepository, ILocalEventBus localEventBus)
    {
        _todoRepository = todoRepository;
        _localEventBus = localEventBus;
    }

    public async Task<List<TodoDto>> GetListAsync(string? status, string? priority, DateTime? from, DateTime? to, string? sortBy)
    {
        var query = await _todoRepository.GetQueryableAsync();

        if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<TodoStatus>(status, out var st))
            query = query.Where(x => x.Status == st);

        if (!string.IsNullOrWhiteSpace(priority) && Enum.TryParse<PriorityLevel>(priority, out var pr))
            query = query.Where(x => x.Priority == pr);

        if (from.HasValue)
            query = query.Where(x => x.DueDate >= from);

        if (to.HasValue)
            query = query.Where(x => x.DueDate <= to);

        query = sortBy switch
        {
            "due" => query.OrderBy(x => x.DueDate),
            "priority" => query.OrderBy(x => x.Priority),
            _ => query.OrderByDescending(x => x.CreatedDate)
        };

        var result = await AsyncExecuter.ToListAsync(query);
        return ObjectMapper.Map<List<Todo>, List<TodoDto>>(result);
    }

    public async Task<TodoDto> GetAsync(Guid id)
    {
        var todo = await _todoRepository.GetAsync(id);
        return ObjectMapper.Map<Todo, TodoDto>(todo);
    }

    public async Task<TodoDto> CreateAsync(CreateUpdateTodoDto input)
    {
        var todo = ObjectMapper.Map<CreateUpdateTodoDto, Todo>(input);
        var created = await _todoRepository.InsertAsync(todo);
        return ObjectMapper.Map<Todo, TodoDto>(created);
    }

    public async Task<TodoDto> UpdateAsync(Guid id, CreateUpdateTodoDto input)
    {
        var todo = await _todoRepository.GetAsync(id);
        ObjectMapper.Map(input, todo);
        todo.LastModifiedDate = DateTime.UtcNow;
        return ObjectMapper.Map<Todo, TodoDto>(todo);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _todoRepository.DeleteAsync(id);
    }

    public async Task MarkCompleteAsync(Guid id)
    {
        var todo = await _todoRepository.GetAsync(id);
        todo.Status = TodoStatus.Completed;
        todo.LastModifiedDate = DateTime.UtcNow;

        await _localEventBus.PublishAsync(new TodoCompletedEvent(todo.Id));
    }
}
