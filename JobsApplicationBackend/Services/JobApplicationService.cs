using JobsApplicationBackend.Models;
using JobsApplicationBackend.Repositories;

namespace JobsApplicationBackend.Services
{
    public class JobApplicationService: IJobApplicationService
    {
        private readonly IJobApplicationRepository _repository;

        public JobApplicationService(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<(bool status, string message)> DeleteJobApplication(int id)
        {
            var jobApplicationExists = _repository.JobApplicationExists(id);
            if (!jobApplicationExists)
            {
                return (false, "JobApplication does not exists");
            }

            await _repository.DeleteJobApplication(id);
            return (true, string.Empty);
        }

        public IList<JobApplication> GetJobApplications()
        {
            return _repository.GetJobApplications();
        }

        public Task<int> SaveJobApplication(JobApplication jobApplication)
        {
            return _repository.SaveJobApplication(jobApplication);
        }
    }
}
