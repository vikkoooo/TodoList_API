using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList_API.Models;

namespace TodoList_API.Controllers
{
	[Route("api/TodoItems")] // api/TodoItems
	[ApiController]
	public class TodoItemsController : ControllerBase
	{
		private readonly TodoContext context;

		public TodoItemsController(TodoContext context)
		{
			this.context = context;
		}

		// GET: api/TodoItems
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
		{
			return await context.TodoItems
				.Select(item => ItemToDTO(item)) // transform every item to DTO item
				.ToListAsync();
		}

		// GET: api/TodoItems/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TodoItemDTO>> GetTodoItem(int id)
		{
			var todoItem = await context.TodoItems.FindAsync(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return ItemToDTO(todoItem);
		}

		// PUT: api/TodoItems/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTodoItem(int id, TodoItemDTO todoDTO)
		{
			if (id != todoDTO.Id)
			{
				return BadRequest();
			}

			var todoItem = await context.TodoItems.FindAsync(id);
			if (todoItem == null)
			{
				return NotFound();
			}

			todoItem.Title = todoDTO.Title;
			todoItem.IsCompleted = todoDTO.IsCompleted;
			todoItem.Timestamp = todoDTO.Timestamp;
			todoItem.Author = todoDTO.Author;

			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
			{
				return NotFound();
			}

			return NoContent();
		}

		// POST: api/TodoItems
		[HttpPost]
		public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
		{
			var todoItem = new TodoItem
			{
				Title = todoDTO.Title,
				IsCompleted = todoDTO.IsCompleted,
				Timestamp = DateTime.UtcNow,
				Author = todoDTO.Author
			};

			context.TodoItems.Add(todoItem);
			await context.SaveChangesAsync();

			return CreatedAtAction(
				nameof(GetTodoItem),
				new { id = todoItem.Id },
				ItemToDTO(todoItem));
		}

		// DELETE: api/TodoItems/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTodoItem(int id)
		{
			var todoItem = await context.TodoItems.FindAsync(id);
			if (todoItem == null)
			{
				return NotFound();
			}

			context.TodoItems.Remove(todoItem);
			await context.SaveChangesAsync();

			return NoContent();
		}

		private bool TodoItemExists(int id)
		{
			return context.TodoItems.Any(e => e.Id == id);
		}

		private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
			new TodoItemDTO
			{
				Id = todoItem.Id,
				Title = todoItem.Title,
				IsCompleted = todoItem.IsCompleted,
				Timestamp = todoItem.Timestamp,
				Author = todoItem.Author
			};
	}
}
