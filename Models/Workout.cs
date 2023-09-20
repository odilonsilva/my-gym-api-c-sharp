namespace api.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int EditorId { get; set; }
    }
}
