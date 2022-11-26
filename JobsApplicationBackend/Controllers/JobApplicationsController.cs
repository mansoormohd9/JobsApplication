using Microsoft.AspNetCore.Mvc;
using JobsApplicationBackend.Models;
using JobsApplicationBackend.Services;
using JobsApplicationBackend.Dtos;

namespace JobsApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _service;

        public JobApplicationsController(IJobApplicationService service)
        {
            _service = service;
        }

        // GET: api/JobApplications
        [HttpGet]
        public ActionResult<IEnumerable<JobApplication>> GetJobApplications()
        {
            var jobApplications = _service.GetJobApplications();
            return Ok(jobApplications);
        }

        // POST: api/JobApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobApplication>> PostJobApplication([FromForm] JobApplicationSaveDto jobApplication)
        {
            var result= await _service.SaveJobApplication(jobApplication);

            if(!result.status)
            {
                return BadRequest(result.message);
            }

            return Ok(result.createdId);
        }

        // DELETE: api/JobApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobApplication(int id)
        {
            var (success, message) = await _service.DeleteJobApplication(id);
            if (!success)
            {
                return NotFound(message);
            }

            return NoContent();
        }
    }
}
