namespace api.Models
{
    public class WorkoutStudent
    {
        public int Id { get; set; }
        public int WorkoutId {  get; set; }
        public int StudentId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime expiryAt { get; set; } 
    }
}
