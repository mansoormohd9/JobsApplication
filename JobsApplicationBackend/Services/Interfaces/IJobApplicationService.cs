﻿using JobsApplicationBackend.Dtos;
using JobsApplicationBackend.Models;

namespace JobsApplicationBackend.Services
{
    public interface IJobApplicationService
    {
        IList<JobApplication> GetJobApplications();
        Task<int> SaveJobApplication(JobApplicationSaveDto jobApplicationDto);
        Task<(bool status, string message)> DeleteJobApplication(int id);
    }
}
