using JobsApplicationBackend.Models;

namespace JobsApplicationBackend.Repositories
{
    public class JobApplicationRepository: IJobApplicationRepository
    {
        private readonly JobsApplicationContext _context;

        public JobApplicationRepository(JobsApplicationContext context)
        {
            _context = context;
        }

        public IList<JobApplication> GetJobApplications()
        {
            return _context.JobApplications.ToList();
        }

        public async Task<int> SaveJobApplication(JobApplication jobApplication)
        {
            _context.JobApplications.Add(jobApplication);
            var savedJobApplication = await _context.SaveChangesAsync();

            return savedJobApplication;
        }

        public async Task DeleteJobApplication(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication != null)
            {
                _context.JobApplications.Remove(jobApplication);
                await _context.SaveChangesAsync();
            }
        }

        public bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.Id == id);
        }
    }
}
