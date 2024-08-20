using System.ComponentModel.DataAnnotations;

namespace TodoList_API.Models
{
	public class TodoItem
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public bool IsCompleted { get; set; }
		public DateTime Timestamp { get; set; }
		[Required]
		public string Author { get; set; }
	}
}