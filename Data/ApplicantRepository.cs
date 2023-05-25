using JobboardAPI.Models;
using JobBoardAPI.Data.Interfaces;
using JobBoardAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicantRepository : IApplicantRepository
{
    private readonly AppDbContext _context;

    public ApplicantRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Applicant> GetAllApplicants()
    {
        return _context.Applicants.ToList();
    }

    public Applicant GetApplicantById(int id)
    {
        return _context.Applicants.Find(id);
    }

    public void CreateApplicant(Applicant applicant)
    {
        _context.Applicants.Add(applicant);
        _context.SaveChanges();
    }

    public void UpdateApplicant(Applicant applicant)
    {
        _context.Entry(applicant).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteApplicant(int id)
    {
        var applicant = _context.Applicants.Find(id);
        if (applicant != null)
        {
            _context.Applicants.Remove(applicant);
            _context.SaveChanges();
        }
    }
}
