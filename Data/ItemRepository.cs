using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teams.API.Model;

namespace Teams.API.Data
{
    public class ItemRepository : IItemRepository
    {
        private DataContext _dbContext;

        public ItemRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Items> AddItems(Items item)
        {
            await _dbContext.Items.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return item;

        }
        
        public async Task<bool> DeleteItem(int id)
        {
            var itemToRemove = await _dbContext.Items.FirstOrDefaultAsync(x => x.ID == id);
            if (itemToRemove != null)
            {
                _dbContext.Entry(itemToRemove).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Items>> GetAllItems()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task<Items> GetItemById(int id)
        {
            return await _dbContext.Items.FirstOrDefaultAsync(x => x.ID == id);
        }

        public Task<Projects> GetItemByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Items> GetItemsByName(string name)
        {
            return await _dbContext.Items.FirstOrDefaultAsync(x => x.Name == name); 
        }

        public Task<Projects> UpdateItem(Items item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Items> UpdateItems(Items item)
        {
            var itemToUpdate = await _dbContext.Items.FirstOrDefaultAsync(x => x.ID == item.ID);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Description = item.Description;
                itemToUpdate.Points = item.Points;
                itemToUpdate.User_ID = item.User_ID;
                _dbContext.Entry(itemToUpdate).State = EntityState.Modified;  
                _dbContext.SaveChanges();
            }
            return await _dbContext.Items.FirstOrDefaultAsync(x => x.ID == item.ID);

        }
    }
}