namespace PROG7312.Models
{
    public class Issues
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Files { get; set; }

    }
}
