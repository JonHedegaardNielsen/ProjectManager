using Microsoft.EntityFrameworkCore;
using ProjectManager;

await Seedtask();
printIncompleteTasksAndTodos();

// await Seedtask();
//
// using BloggingContext context = new();
//
// var tasks = context.Tasks.Include(task => task.Todos);
// Console.WriteLine("Hello World " + tasks.Count()); ;
// foreach (var task in tasks)
// {
// 	Console.WriteLine(task.Name);
// 	foreach (var todo in task.Todos)
// 	{
// 		Console.WriteLine($"- {todo.Name}");
// 	}
// }

static async System.Threading.Tasks.Task printIncompleteTasksAndTodos()
{
	BloggingContext context = new();
	var tasks = context.Tasks.Include(task => task.Todos.Where(todo => todo.IsComplete))
		.Where(task => task.Todos
			.Any(todo => todo.IsComplete));


	foreach (var task in tasks)
	{
		Console.WriteLine(task.Name);
		foreach (var todo in task.Todos)
		{
			Console.WriteLine($"- {todo.Name}");
		}
	}
}

static async System.Threading.Tasks.Task Seedtask()
{
	BloggingContext context = new();
	context.Todos.ExecuteDelete();
	context.Tasks.ExecuteDelete();
	ProjectManager.Task[] tasks = [
	new(){
		Todos = [
			new() {Name = "Write code", IsComplete = true},
			new() {Name = "Compile Source"},
			new() {Name = "Test Program", IsComplete = true },
		],
		Name = "Product software",
	},
	new(){
		Name = "Brew Cofee",
		Todos = [
			new() {Name = "Pour Water" },
			new() {Name = "Pour Coffee"},
			new() {Name = "Turn On" },
		],
	}
	];
	await context.Tasks.AddRangeAsync(tasks);
	await context.SaveChangesAsync();
}
