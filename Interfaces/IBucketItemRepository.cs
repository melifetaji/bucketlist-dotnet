using DB_CON.Models;
namespace DB_CON.Interfaces
{
    public interface IBucketItemRepository
    {
        List<BucketItem> GetAll();
        void AddItem(BucketItem bucketItem);
        Task DeleteAsync(int id);

        BucketItem FindOne(int id);
        // Task MarkAsCompleteAsync(int id);
        Task UpdateAsync(BucketItem bucketItem);
    }
}