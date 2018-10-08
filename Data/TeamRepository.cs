using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teams.API.Model;

namespace Teams.API.Data
{
    public class TeamRepository : ITeamRepository
    {
        private DataContext _dbContext;

        public TeamRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Team> AddTeam(Team team)
        {
            await _dbContext.Teams.AddAsync(team);
            await _dbContext.SaveChangesAsync();

            return team;

        }

        public async Task<bool> DeleteTeam(int id)
        {
            var teamToRemove = await _dbContext.Teams.FirstOrDefaultAsync(x => x.ID == id);
            if (teamToRemove != null)
            {
                _dbContext.Entry(teamToRemove).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Team>> GetAllTeam()
        {
            return await _dbContext.Teams.ToListAsync();
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _dbContext.Teams.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Team> GetTeamByName(string name)
        {
            return await _dbContext.Teams.FirstOrDefaultAsync(x => x.Name == name); 
        }

        public async Task<Projects> GetTeamProjects(int id)
        {
            return null;
        }

        public async Task<Team> UpdateTeam(Team team)
        {
            var teamToUpdate = await _dbContext.Teams.FirstOrDefaultAsync(x => x.ID == team.ID);
            if (teamToUpdate != null)
            {
                teamToUpdate.Name = team.Name;
                teamToUpdate.Project_ID= team.Project_ID;
                _dbContext.Entry(teamToUpdate).State = EntityState.Modified;  
                _dbContext.SaveChanges();
            }
            return await _dbContext.Teams.FirstOrDefaultAsync(x => x.ID == team.ID);

        }
    }
}