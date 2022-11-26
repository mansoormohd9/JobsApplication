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
    }
}
