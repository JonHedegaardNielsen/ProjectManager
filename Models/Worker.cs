using ProjectManager;

namespace ProjectManager.Models;

public class Worker
{
	public Worker() { }
	public Worker(string name = "", Todo todo = null)
	{
		Name = name;
		currentTodo = todo;
	}
	public int WorkerId { get; set; } = 0;
	public string Name { get; set; } = "";
	public List<Team> Teams { get; set; } = [];
	public Todo currentTodo { get; set; }
	public List<Todo> Todos { get; set; } = [];
}
