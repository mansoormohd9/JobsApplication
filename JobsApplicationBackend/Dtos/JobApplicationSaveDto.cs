using System.ComponentModel.DataAnnotations;

namespace JobsApplicationBackend.Dtos
{
    public class JobApplicationSaveDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string CvBlob { get; set; }
    }
}
