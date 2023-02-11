namespace Routing.Models
{
	public class Cow
	{
		private static int nextID = 0;
		public int? Id { get; set; } = nextID++;
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageLocation { get; set; }

		public Cow() { }

		public Cow(string Name, string Description, string ImageLocation)
		{ 
			this.Name = Name;
			this.Description = Description;
			this.ImageLocation = ImageLocation;
		}

	}
}
