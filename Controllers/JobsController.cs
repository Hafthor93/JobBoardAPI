using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly INewJobRepository _jobRepository;

        public JobsController(INewJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            try
            {
                return Ok(await _jobRepository.GetAllJobs());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database, Details: {ex.Message}");
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            try
            {
                var job = await _jobRepository.GetJobById(id);
                if (job == null)
                {
                    return NotFound();
                }
                return Ok(job);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database, Details: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            try
            {
                await _jobRepository.UpdateJob(job);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating data, Details: {ex.Message}");
            }
        }

       
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            try
            {
                Console.WriteLine($"Received new job: {job.Title}, {job.Location}, {job.Type}, ...");

                await _jobRepository.AddJob(job);
                return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating new job: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating new job, Details: {ex.Message}");
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            try
            {
                await _jobRepository.DeleteJob(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting job, Details: {ex.Message}");
            }
        }
    }
}
