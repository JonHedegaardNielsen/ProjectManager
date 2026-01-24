namespace ProjectManager.Models;

public class TeamWorker
{
	public int TeamId { get; set; }
	public Team Team { get; set; }
	public int WorkerId { get; set; }
	public Worker Worker { get; set; }
}
