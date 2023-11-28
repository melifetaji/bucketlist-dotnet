using DB_CON.Models;
using DB_CON.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DB_CON.Repositories
{
    public class BucketItemRepository : IBucketItemRepository
    {
        // Initializing DB Context
        private readonly ApplicationDbContext _dbContext;

        public BucketItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // ----------------------------------------------------------------------

        public List<BucketItem> GetAll()
        {
            return _dbContext.BucketItems.ToList();
        }


        public void AddItem(BucketItem item)
        {
            _dbContext.BucketItems.Add(item);
            _dbContext.SaveChanges();
        }
        public async Task DeleteAsync(int id)
        {
            var itemToDelete = await _dbContext.BucketItems.FindAsync(id);
            if (itemToDelete == null)
            {
                throw new Exception("Item does not exist");
            }

            _dbContext.BucketItems.Remove(itemToDelete);
            await _dbContext.SaveChangesAsync();
        }
        public BucketItem FindOne(int id)
        {
            var item = _dbContext.BucketItems.Find(id);
            if (item == null)
            {
                throw new Exception("Item does not exist");
            }

            return item;
        }
    }
}