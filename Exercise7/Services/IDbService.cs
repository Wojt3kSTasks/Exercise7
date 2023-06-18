using Exercise7.Models.DTOs;
using Exercise7.Models;

namespace Exercise7.Services
{
    public interface IDbService
    {
        Task<Team> GetTeamProjects(int prescriptionId);
        Task AddNewTeam(Team team);
        Task<bool> DoesTeamExist(int teamId);
    }
}