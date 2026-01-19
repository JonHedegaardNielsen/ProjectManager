namespace ProjeckManager.Models;

public class Worker
{
	public int WorkerId { get; set; } = 0;
	public string Name { get; set; } = "";
	public List<Team> Teams { get; set; } = [];

}
