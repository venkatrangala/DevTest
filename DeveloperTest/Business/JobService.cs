using System;
using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;
        private readonly ICustomerService _customerService;
        public JobService(ApplicationDbContext context, ICustomerService customerService)
        {
            this.context = context;
            _customerService = customerService;
        }

        public JobModel[] GetJobs()
        {
            var data= context.Jobs.Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerId = x.CustomerId,
                Customer = x.CustomerId.HasValue ? _customerService.GetCustomerById(x.CustomerId.Value) : null
            }).ToArray();
            return data;
        }
       
        public JobModel GetJob(int jobId)
        {
            return context.Jobs.Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerId = x.CustomerId,
                Customer = x.CustomerId.HasValue ? _customerService.GetCustomerById(x.CustomerId.Value) : null
            }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.CustomerId,
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                When = addedJob.Entity.When,
                CustomerId = addedJob.Entity.CustomerId,
            };
        }
    }
}
