using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly DevJobsContext _context;

        public JobVacanciesController(DevJobsContext context) //passando classe pra Dep Inj
        {
            _context = context;
        } 

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _context.JobVacancies;

            return Ok(jobVacancies);
        }

        [HttpGet("{id}")] //passando o id como parametro (na url) na request
        public IActionResult GetById(int id)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);

            if (jobVacancy == null)
                return NotFound();

            return Ok(jobVacancy);
        }

        [HttpPost]
        public IActionResult Register(AddJobVacancyInputModel model)
        {
            //traducao de valores, entre o que esta chegando para a minha entidade de dominio
            var jobVacancy = new JobVacancy(model.Title, 
                model.Description, 
                model.Company, 
                model.IsRemote, 
                model.SalaryRange);

            _context.JobVacancies.Add(jobVacancy);

            return CreatedAtAction(
                "GetById", 
                new { id = jobVacancy.Id},
                jobVacancy); //retorna codigo 201 com essas informacoes na resposta
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(jb => jb.Id == id);

            if (jobVacancy == null)
                return NotFound();

            jobVacancy.Update(model.Title, model.Description);
           
            return NoContent();
        }
    }
}
