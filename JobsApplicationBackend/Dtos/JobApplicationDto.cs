namespace JobsApplicationBackend.Dtos
{
    public class JobApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobType { get; set; }
        public string CvBlob { get; set; }
    }
}
