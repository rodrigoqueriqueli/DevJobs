namespace DevJobs.API.Models
{
    //Models - DTOS
    public record AddJobVacancyInputModel(
        string Title, 
        string Description,
        string Company,
        bool IsRemote,
        string SalaryRange)
    {

    }
}
