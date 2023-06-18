using Exercise7.Data;
using Exercise7.Models;
using Exercise7.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Exercise7.Services
{
    public class DbService : IDbService
    {
        private readonly DeveloperContext _context;

        public DbService(DeveloperContext context)
        {
            _context = context;
        }

        public async Task<Team> GetTeamProjects(int teamId)
        {
            return await _context.Teams
                .Include(e => e.Developers)
                .Include(e => e.ProjectTeams)
                .ThenInclude(e => e.Project)
                .ThenInclude(e => e.ProjectStatus)
                .Where(p => p.ID == teamId)
                .FirstAsync();
        }

        public async Task AddNewTeam(Team team)
        {
            await _context.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DoesTeamExist(int teamId)
        {
            return await _context.Teams.AnyAsync(e => e.ID == teamId);
        }

        public async Task<bool> DoesDeveloperExist(NewDeveloperDTO newTeamDeveloper)
        {
            return await _context.Developers.AnyAsync(e =>
                e.FirstName == newTeamDeveloper.FirstName && e.LastName == newTeamDeveloper.LastName);
        }
    }
}