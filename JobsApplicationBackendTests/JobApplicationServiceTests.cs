using JobsApplicationBackend.Dtos;
using JobsApplicationBackend.Models;
using JobsApplicationBackend.Repositories;
using JobsApplicationBackend.Services;
using Microsoft.AspNetCore.Http;
using Moq;

namespace JobsApplicationBackendTests
{
    [TestClass]
    public class JobApplicationServiceTests
    {
        public readonly Mock<IJobApplicationRepository> jobApplicationRepository = new Mock<IJobApplicationRepository>();
        public readonly Mock<IFormFile> formFile = new Mock<IFormFile>();
        public IJobApplicationService _jobApplicationService;

        [TestInitialize]
        public void TestInitialize()
        {
            _jobApplicationService = new JobApplicationService(jobApplicationRepository.Object);
        }

        [TestMethod]
        public async Task TestDeleteIfNotExists()
        {
            //arrange
            var jobApplicationId = 10;
            JobApplication jobApplication = null;
            jobApplicationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(jobApplication);
            var expectedResult = false;

            //act
            var actual = await _jobApplicationService.DeleteJobApplication(jobApplicationId);

            //result
            Assert.AreEqual(expectedResult, actual.status);
        }

        [TestMethod]
        public async Task TestDeleteIfExists()
        {
            //arrange
            var jobApplicationId = 10;
            formFile.Setup(x => x.FileName).Returns("test.pdf");
            jobApplicationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new JobApplication { CvBlob = "Test.pdf"});
            jobApplicationRepository.Setup(x => x.DeleteJobApplication(It.IsAny<int>())).Verifiable();
            var expectedResult = true;

            //act
            var actual = await _jobApplicationService.DeleteJobApplication(jobApplicationId);

            //result
            Assert.AreEqual(expectedResult, actual.status);
        }

        [TestMethod]
        public async Task TestSaveIfDuplicate()
        {
            //arrange
            var jobApplication = new JobApplicationSaveDto();
            jobApplicationRepository.Setup(x => x.CheckIfAlreadyApplied(It.IsAny<JobApplicationSaveDto>())).Returns(true);
            var expectedResult = false;

            //act
            var actual = await _jobApplicationService.SaveJobApplication(jobApplication);

            //result
            Assert.AreEqual(expectedResult, actual.status);
        }
    }
}