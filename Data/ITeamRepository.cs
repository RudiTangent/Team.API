using System.Collections.Generic;
using System.Threading.Tasks;
using Teams.API.Model;

namespace Teams.API.Data
{
    public interface ITeamRepository
    {
         Task<IEnumerable<Team>> GetAllTeam();

         Task<Team> GetTeamById(int id);

         Task<Team> AddTeam (Team team);

         Task<bool> DeleteTeam(int id);

         Task<Team> GetTeamByName(string name);

         Task<Team> UpdateTeam(Team team);

         Task<Projects> GetTeamProjects(int id);
    }
}