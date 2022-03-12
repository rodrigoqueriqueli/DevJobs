using DevJobs.API.Entities;

namespace DevJobs.API.Persistence
{
    //class que representa o contexto de dados da aplicacao
    public class DevJobsContext
    {
        //public List<JobApplication> JobApplications { get; set; }
        public List<JobVacancy> JobVacancies { get; set; }

        public DevJobsContext()
        {
            JobVacancies = new List<JobVacancy>();  
        }
    }
}
