using JobBoardAPI.Data.Interfaces;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ApplicantController : ControllerBase
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantController(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    [HttpGet]
    public IActionResult GetApplicants()
    {
        var applicants = _applicantRepository.GetAllApplicants();
        return Ok(applicants);
    }

    [HttpGet("{id}")]
    public IActionResult GetApplicant(int id)
    {
        var applicant = _applicantRepository.GetApplicantById(id);
        if (applicant == null)
        {
            return NotFound();
        }

        return Ok(applicant);
    }

    [HttpPost]
    public IActionResult CreateApplicant([FromBody] Applicant applicant)
    {
        _applicantRepository.CreateApplicant(applicant);
        return CreatedAtAction(nameof(GetApplicant), new { id = applicant.Id }, applicant);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateApplicant(int id, [FromBody] Applicant applicant)
    {
        if (id != applicant.Id)
        {
            return BadRequest();
        }

        _applicantRepository.UpdateApplicant(applicant);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteApplicant(int id)
    {
        _applicantRepository.DeleteApplicant(id);
        return NoContent();
    }
}
