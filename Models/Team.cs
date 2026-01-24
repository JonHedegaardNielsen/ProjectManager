namespace ProjectManager.Models;

public class Team
{
	public Team() { }
	public Team(string name = "", ProjectManager.Task task = null)
	{
		Name = name;
		CurrentTask = task;
	}
	public int TeamId { get; set; } = 0;
	public string Name { get; set; } = "";
	public List<Worker> Workers { get; set; } = [];
	public ProjectManager.Task CurrentTask { get; set; }
	public List<ProjectManager.Task> Tasks { get; set; } = [];

}
