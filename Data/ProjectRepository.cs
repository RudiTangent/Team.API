using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teams.API.Model;

namespace Teams.API.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private DataContext _dbContext;

        public ProjectRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Projects> AddProject(Projects project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project;

        }

        public async Task<bool> DeleteProject(int id)
        {
            var projectToRemove = await _dbContext.Projects.FirstOrDefaultAsync(x => x.ID == id);
            if (projectToRemove != null)
            {
                _dbContext.Entry(projectToRemove).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Projects>> GetAllProjects()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Projects> GetProjectById(int id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Projects> GetProjectsByName(string name)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(x => x.Name == name); 
        }

        public async Task<Projects> UpdateProject(Projects project)
        {
            var projectToUpdate = await _dbContext.Projects.FirstOrDefaultAsync(x => x.ID == project.ID);
            if (projectToUpdate != null)
            {
                projectToUpdate.Name = project.Name;
                projectToUpdate.StartDate = project.StartDate;
                projectToUpdate.EndDate = project.EndDate;
                projectToUpdate.Description = project.Description;
                _dbContext.Entry(projectToUpdate).State = EntityState.Modified;  
                _dbContext.SaveChanges();
            }
            return await _dbContext.Projects.FirstOrDefaultAsync(x => x.ID == project.ID);

        }
    }
}