using Microsoft.EntityFrameworkCore;
using TodoList_API.Models;

namespace TodoList_API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddDbContext<TodoContext>(opt => // Adds the database context to the DI container.
			opt.UseInMemoryDatabase("TodoList")); // Specifies that the database context will use an in-memory database.

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
