namespace ProjectManager.Models;

public class Customer : Person
{
	public int CustomerId { get; set; } = 0;
	public string CustomerNumber { get; set; } = "";
	public int CreditMax { get; set; } = 0;
}
