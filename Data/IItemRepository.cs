using System.Collections.Generic;
using System.Threading.Tasks;
using Teams.API.Model;

namespace Teams.API.Data
{
    public interface IItemRepository
    {
         Task<IEnumerable<Items>> GetAllItems();

         Task<Items> GetItemById(int id);

         Task<Items> AddItems (Items item);

         Task<bool> DeleteItem(int id);

         Task<Items> GetItemByName(string name);

         Task<Items> UpdateItem(Items item);
    }
}