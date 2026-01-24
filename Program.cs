using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;
using ProjectManager;

seedWorkers();

// using BloggingContext context = new ();
// Console.WriteLine(context.TeamWorkers.Count());
//
// Console.WriteLine(context.Teams.Count());
// Console.WriteLine(context.Workers.Count());
// Console.WriteLine(context.Todos.Count());
// Console.WriteLine(context.Tasks.Count());



static void seedWorkers()
{
	using BloggingContext context = new();
	context.TeamWorkers.ExecuteDelete();
	context.Teams.ExecuteDelete();
	context.Workers.ExecuteDelete();
	context.Tasks.ExecuteDelete();
	context.Todos.ExecuteDelete();
	ProjectManager.Task task = new("jon");
	Team frontend = new() { Name = "Frontend", CurrentTask = new() };
	Team backend = new() { Name = "Backend" };
	Team testers = new() { Name = "Testere" };

	// Worker steenSecher = new() { Name = "Steen Secher" };
	Worker ejvindMealler = new("Ejvind Møller", new("spis kage"));
	Worker konradLadeMann = new("Konrad LadeMann");
	Worker konradSommer = new("Konrad Sommer");
	Worker sofusLofus = new("Sofus Lotus");
	Worker remoLademann = new("Remo Lademann");
	Worker anneDam = new("Anne Dam");
	Worker ellaFanth = new("Ella Fanth");
	TeamWorker[] teamWorkers = [
	// new()
	// {
	// 	Team = frontend,
	// 	Worker = steenSecher,
	// },
	new()
	{
		Team = frontend,
		Worker = ejvindMealler,
	},
	// new()
	// {
	// 	Team = frontend,
	// 	Worker = konradSommer,
	// },
	// new()
	// {
	// 	Team = backend,
	// 	Worker = konradLadeMann,
	// },
	// new()
	// {
	// 	Team = backend,
	// 	Worker = sofusLofus,
	// },
	// new()
	// {
	// 	Team = backend,
	// 	Worker = remoLademann,
	// },
	// new()
	// {
	// 	Team = testers,
	// 	Worker = ellaFanth,
	// },
	// new()
	// {
	// 	Team = testers,
	// 	Worker = anneDam,
	// },
	// new()
	// {
	// 	Team = testers,
	// 	Worker = steenSecher,
	// },
	];

	//
	context.TeamWorkers.AddRange(teamWorkers);
	context.SaveChanges();

}

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
