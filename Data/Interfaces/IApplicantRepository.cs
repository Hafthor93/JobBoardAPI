using JobBoardAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JobBoardAPI.Data.Interfaces
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetAllApplicants();
        Applicant GetApplicantById(int id);
        void CreateApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        void DeleteApplicant(int id);
    }
}

