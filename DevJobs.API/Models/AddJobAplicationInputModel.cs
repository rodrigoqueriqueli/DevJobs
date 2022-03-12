namespace DevJobs.API.Models
{
    //Models - DTOS
    public record AddJobAplicationInputModel(
        string ApplicantName,
        string ApplicantEmail,
        int IdJobVacancy)
    {
    }
}