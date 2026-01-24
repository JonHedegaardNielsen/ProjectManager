using System.ComponentModel.DataAnnotations;

namespace ProjectManager;

public class Task
{
	public Task() { }
	public Task(string name = "")
	{
		Name = name;
	}
	public int TaskId { get; set; } = 0;
	public string Name { get; set; } = "";
	public List<Todo> Todos { get; set; } = [];
}
