using System.Collections.Generic;
using System.Threading.Tasks;
using DB_CON.Models;

namespace DB_CON.Interfaces;
public interface IBucketItemService
{
    List<BucketItem> GetAll();

    void AddItem(BucketItem bucketItem);
    Task DeleteItemAsync(int id);
    Task UpdateItemAsync(BucketItem bucketItem);
    Task MarkAsCompleteAsync(int id);
}
