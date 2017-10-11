using Newtonsoft.Json;

namespace Tournament.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int GroupId { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }
    }
}