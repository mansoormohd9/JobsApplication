using JobsApplicationBackend.Models;

namespace JobsApplicationBackend.Services
{
    public interface IJobApplicationService
    {
        IList<JobApplication> GetJobApplications();
        Task<int> SaveJobApplication(JobApplication jobApplication);
        Task<(bool status, string message)> DeleteJobApplication(int id);
    }
}
