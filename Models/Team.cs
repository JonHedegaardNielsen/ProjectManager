namespace ProjeckManager.Models;

public class Team
{

	public int TeamId { get; set; } = 0;
	public string Name { get; set; } = "";
	public List<Worker> Workers { get; set; } = [];

}
