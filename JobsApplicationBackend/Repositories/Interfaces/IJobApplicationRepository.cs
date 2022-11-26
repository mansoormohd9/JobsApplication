using JobsApplicationBackend.Models;

namespace JobsApplicationBackend.Repositories
{
    public interface IJobApplicationRepository
    {
        IList<JobApplication> GetJobApplications();
        Task<int> SaveJobApplication(JobApplication jobApplication);
        Task DeleteJobApplication(int id);
        bool JobApplicationExists(int id);

    }
}
