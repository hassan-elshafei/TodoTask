using System;
using System.ComponentModel.DataAnnotations;

namespace TodoTask.Entities
{
	public class CreateUpdateTodoDto
	{
		[Required]
		[MaxLength(100)]
		public string Title { get; set; } = string.Empty;

		public string? Description { get; set; }

		public string Status { get; set; } = "Pending";
		public string Priority { get; set; } = "Medium";

		public DateTime? DueDate { get; set; }
	}
}
