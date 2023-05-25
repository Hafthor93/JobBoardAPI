using System;
using System.Threading.Tasks;
using JobboardAPI.Models;
using JobBoardAPI.Data.Interfaces;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobBoardAPI.Data
{
    public interface INewJobRepository
    {
        Task<Job> AddJob(Job job);
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobById(int id);
        Task<Job> UpdateJob(Job job);
        Task DeleteJob(int id);
    }

    public class NewJobRepository : INewJobRepository
    {
        private AppDbContext _dbContext;

        public NewJobRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Job> AddJob(Job job)
        {
            _dbContext.Jobs.Add(job);
            await _dbContext.SaveChangesAsync();
            return job;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _dbContext.Jobs.ToListAsync();
        }

        public async Task<Job> GetJobById(int id)
        {
            var job = await _dbContext.Jobs.FindAsync(id);
            if (job == null)
            {
                throw new Exception($"Job with id {id} not found");
            }

            return job;
        }

        public async Task<Job> UpdateJob(Job job)
        {
            var existingJob = await _dbContext.Jobs.FindAsync(job.Id);
            if (existingJob == null)
            {
                throw new Exception($"Job with id {job.Id} not found");
            }

            existingJob.Title = job.Title;
            existingJob.Location = job.Location;
            existingJob.Type = job.Type;
            existingJob.Company = job.Company;
            existingJob.Logo = job.Logo;
            existingJob.Description = job.Description;
            existingJob.Requirements = job.Requirements;
            existingJob.Date = job.Date;
            existingJob.Info = job.Info;
            existingJob.Infrastructure = job.Infrastructure;
            existingJob.Goals = job.Goals;

            _dbContext.Jobs.Update(existingJob);
            await _dbContext.SaveChangesAsync();
            return existingJob;
        }

        public async Task DeleteJob(int id)
        {
            var job = await _dbContext.Jobs.FindAsync(id);
            if (job == null)
            {
                throw new Exception($"Job with id {id} not found");
            }

            _dbContext.Jobs.Remove(job);
            await _dbContext.SaveChangesAsync();
        }


    }

}


