using JobsApplicationBackend.Dtos;
using JobsApplicationBackend.Models;
using JobsApplicationBackend.Repositories;

namespace JobsApplicationBackend.Services
{
    public class JobApplicationService: IJobApplicationService
    {
        private const string fileUploadPath = "UploadedFiles";
        private readonly IJobApplicationRepository _repository;

        public JobApplicationService(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<(bool status, string message)> DeleteJobApplication(int id)
        {
            var jobApplication = _repository.Get(id);
            if (jobApplication == null)
            {
                return (false, "JobApplication does not exists");
            }

            //Delete cv
            RemoveCv(jobApplication.CvBlob);

            await _repository.DeleteJobApplication(id);
            return (true, string.Empty);
        }

        public IList<JobApplication> GetJobApplications()
        {
            return _repository.GetJobApplications();
        }

        public async Task<(int createdId, bool status, string message)> SaveJobApplication(JobApplicationSaveDto jobApplicationDto)
        {
            //error if already submitted
            var alreadySubmitted = _repository.CheckIfAlreadyApplied(jobApplicationDto);

            if(alreadySubmitted)
            {
                return (0, false, "Already Submitted");
            }

            //Upload
            var fileName = SaveCv(jobApplicationDto.CvBlob);

            //Save file
            var jobApplication = new JobApplication
            {
                Name = jobApplicationDto.Name,
                Email = jobApplicationDto.Email,
                DateOfBirth = jobApplicationDto.DateOfBirth,
                JobType = jobApplicationDto.JobType,
                CvBlob = fileName
            };
            var createdId = await _repository.SaveJobApplication(jobApplication);

            return (createdId, true, "submitted Successfully");
        }

        private string SaveCv(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + "." + file.FileName.Split(".").LastOrDefault();
            var savePath = Path.Combine(fileUploadPath, fileName);
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }

        private void RemoveCv(string fileName)
        {
            var path = Path.Combine(fileUploadPath, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
