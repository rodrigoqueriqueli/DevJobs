using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly DevJobsContext _context;

        public JobApplicationsController(DevJobsContext context) //passando classe pra Dep Inj
        {
            _context = context;
        }

        [HttpPost] //cadastro uma nova aplicacao de vaga..id passado como parametro identificador da vaga
        public IActionResult Register(int id, AddJobAplicationInputModel model)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(jb => jb.Id == id);

            if (jobVacancy == null)
                return NotFound();

            var jobApplication = new JobApplication(
                model.ApplicantName,
                model.ApplicantEmail,
                id);

            jobVacancy.Applications.Add(jobApplication);  //lista de aplicacacoes da vaga e adicionar
            

            return NoContent();
        }
    }
}
