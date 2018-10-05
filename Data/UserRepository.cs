using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teams.API.Model;
using Teams.API.Data;

namespace Teams.API.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext _dbContext;

        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users> AddUsers(Users user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;

        }

        public async Task<bool> DeleteUsers(int id)
        {
            var userToRemove = await _dbContext.Users.FirstOrDefaultAsync(x => x.ID == id);
            if (userToRemove != null)
            {
                _dbContext.Entry(userToRemove).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<Users> GetUsersById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Users> GetUsersByName(string name)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Name == name); 
        }

        public async Task<Users> UpdateUsers(Users user)
        {
            var userToUpdate = await _dbContext.Users.FirstOrDefaultAsync(x => x.ID == user.ID);
            if (userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                userToUpdate.Age = user.Age;
                userToUpdate.Job_Title = user.Job_Title;
                _dbContext.Entry(userToUpdate).State = EntityState.Modified;  
                _dbContext.SaveChanges();
            }
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.ID == user.ID);

        }
    }
}