using JobsApplicationBackend.Repositories;
using JobsApplicationBackend.Services;
using Moq;

namespace JobsApplicationBackendTests
{
    [TestClass]
    public class JobApplicationServiceTests
    {
        public readonly Mock<IJobApplicationRepository> jobApplicationRepository = new Mock<IJobApplicationRepository>();
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
            jobApplicationRepository.Setup(x => x.JobApplicationExists(It.IsAny<int>())).Returns(false);
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
            jobApplicationRepository.Setup(x => x.JobApplicationExists(It.IsAny<int>())).Returns(true);
            jobApplicationRepository.Setup(x => x.DeleteJobApplication(It.IsAny<int>())).Verifiable();
            var expectedResult = true;

            //act
            var actual = await _jobApplicationService.DeleteJobApplication(jobApplicationId);

            //result
            Assert.AreEqual(expectedResult, actual.status);
        }
    }
}