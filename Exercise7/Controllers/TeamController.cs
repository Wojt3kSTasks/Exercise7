using Exercise7.Models;
using Exercise7.Models.DTOs;
using Exercise7.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercise7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly IDbService _dbService;
    public TeamController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{teamId}/team-projects")]
    public async Task<IActionResult> GetTeamProjects(int teamId)
    {
        if (!await _dbService.DoesTeamExist(teamId))
        {
            return NotFound($"Team with given ID - {teamId} doesn't exist");
        }
        var team = await _dbService.GetTeamProjects(teamId);
        return Ok(new TeamSummaryDTO
        {
            ID = team.ID,
            Name = team.Name,
            DevelopersCount = team.Developers.Count(),
            Projects = team.ProjectTeams.Select(p => new ProjectDTO
            {
                ID = p.ProjectID,
                ProjectStatus = p.Project.ProjectStatus.Name,
                Name = p.Project.Name,
                Deadline = p.Project.Deadline
            }).ToList()
        });
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewTeam(NewTeamDTO newTeam)
    {
        foreach (var newTeamDeveloper in newTeam.Developers)
        {
            if (!await _dbService.DoesDeveloperExist(newTeamDeveloper))
            {
                return NotFound($"Developer with given name - {newTeamDeveloper.FirstName} " +
                                $"{newTeamDeveloper.LastName} doesn't exist");
            }
        }
        Team team = new Team()
        {
            Name = newTeam.Name,
            Developers = newTeam.Developers.Select(d => new Developer()
            {
                FirstName = d.FirstName,
                LastName = d.LastName
            }).ToList()
        };
        await _dbService.AddNewTeam(team);
        return Created("api/teams/add", "");
    }
}