using System.Collections.Generic;
using System.Threading.Tasks;
using Teams.API.Model;

namespace Teams.API.Data
{
    public interface IUserRepository
    {
         Task<IEnumerable<Users>> GetAllUsers();

         Task<Users> GetUsersById(int id);

         Task<Users> AddUsers (Users user);

         Task<bool> DeleteUsers(int id);

         Task<Users> GetUsersByName(string name);

         Task<Users> UpdateUsers(Users user);
    }
}