namespace JobsApplicationBackend.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CvBlob { get; set; }
    }
}
