using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teams.API.Model;

namespace Teams.API.Data
{
    public interface IProjectRepository
    {
         Task<IEnumerable<Projects>> GetAllProjects();

         Task<Projects> GetProjectById(int id);

         Task<Projects> AddProject (Projects project);

         Task<bool> DeleteProject(int id);

         Task<Projects> GetProjectsByName(string name);

         Task<Projects> UpdateProject(Projects project);
        
    }
}