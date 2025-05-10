using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace TodoTask.Entities
{
	public enum TodoStatus { Pending, InProgress, Completed }
	public enum PriorityLevel { Low, Medium, High }

	public class Todo : Entity<Guid>
	{
		[Required]
		[MaxLength(100)]
		public string Title { get; set; } = string.Empty;

		public string? Description { get; set; }

		public TodoStatus Status { get; set; } = TodoStatus.Pending;

		public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;

		public DateTime? DueDate { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
	}
}
