namespace GameZone.Models
{
	public class Category :BaseEntity
	{
		public ICollection<Game> game { get; set; } = new List<Game>();

    }
}
