using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoTask.Entities;
using TodoTask.Web.Services;

namespace TodoTask.Pages.TodoTask
{
    public class IndexModel : PageModel
    {
        private readonly ITodoTaskService _todoService;

        public IndexModel(ITodoTaskService todoService)
        {
            _todoService = todoService;
        }

        public List<TodoDto> Todos { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public TodoFilter Filter { get; set; } = new();

        public List<SelectListItem> StatusOptions { get; } = new List<SelectListItem>
        {
            new SelectListItem("All", ""),
            new SelectListItem("Pending", "Pending"),
            new SelectListItem("In Progress", "InProgress"),
            new SelectListItem("Completed", "Completed")
        };

        public List<SelectListItem> PriorityOptions { get; } = new List<SelectListItem>
        {
            new SelectListItem("All", ""),
            new SelectListItem("High", "High"),
            new SelectListItem("Medium", "Medium"),
            new SelectListItem("Low", "Low")
        };

        public async Task OnGetAsync()
        {
            Todos = await _todoService.GetTodosAsync(
                Filter.Status,
                Filter.Priority,
                Filter.From,
                Filter.To
            );
        }

        public IActionResult OnGetCreateForm()
        {
            return Partial("_TodoFormPartial", new CreateUpdateTodoDto());
        }

        public async Task<IActionResult> OnGetEditFormAsync(Guid id)
        {
            try
            {
                var todo = await _todoService.GetTodoAsync(id);
                var model = new CreateUpdateTodoDto
                {
                    Title = todo.Title,
                    Description = todo.Description,
                    Priority = todo.Priority,
                    DueDate = todo.DueDate
                };
                return Partial("_TodoFormPartial", new TodoFormModel
                {
                    Id = id,
                    Todo = model
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostSaveTodoAsync(TodoFormModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Partial("_TodoFormPartial", model);
            }

            try
            {
                if (model.Id.HasValue)
                {
                    await _todoService.UpdateTodoAsync(model.Id.Value, model.Todo);
                }
                else
                {
                    await _todoService.CreateTodoAsync(model.Todo);
                }

                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { success = false, error = ex.Message });
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            try
            {
                await _todoService.DeleteTodoAsync(id);
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { success = false, error = ex.Message });
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostCompleteAsync(Guid id)
        {
            try
            {
                await _todoService.MarkCompleteAsync(id);
                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { success = false, error = ex.Message });
            }
        }
    }

    public class TodoFilter
    {
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class TodoFormModel
    {
        public Guid? Id { get; set; }
        public CreateUpdateTodoDto Todo { get; set; } = new CreateUpdateTodoDto();
    }
}