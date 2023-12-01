using DB_CON.Models;
using DB_CON.Interfaces;
using Microsoft.EntityFrameworkCore;
using DB_CON.Controllers;
namespace DB_CON.Repositories
{
    public class BucketItemService : IBucketItemService
    {
        private readonly IBucketItemRepository _bucketItemRepository;

        public BucketItemService(IBucketItemRepository bucketItemRepository)
        {
            _bucketItemRepository = bucketItemRepository;
        }

        public List<BucketItem> GetAll()
        {
            try
            {
                var items = _bucketItemRepository.GetAll();
                return items;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AddItem(BucketItem bucketItem)
        {
            try
            {
                _bucketItemRepository.AddItem(bucketItem);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task DeleteItemAsync(int id)
        {
            try
            {
                var item = _bucketItemRepository.FindOne(id);

                if (item is null)
                {
                    throw new Exception("Item does not exist");
                }

                await _bucketItemRepository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task UpdateItemAsync(BucketItem bucketItem)
        {
            try
            {
                var item = _bucketItemRepository.FindOne(bucketItem.Id);

                item.CityName = bucketItem.CityName;
                item.CountryName = bucketItem.CountryName;
                item.Budget = bucketItem.Budget;
                item.IsComplete = bucketItem.IsComplete;

                await _bucketItemRepository.UpdateAsync(item);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task MarkAsCompleteAsync(int id)
        {
            try
            {
                var item = _bucketItemRepository.FindOne(id);

                if (item is null)
                {
                    throw new Exception("Item does not exist");
                }

                await _bucketItemRepository.MarkAsCompleteAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public BucketItem FindOne(int id)
        {
            try
            {
                var item = _bucketItemRepository.FindOne(id);
                if (item is null)
                {
                    throw new Exception("Item does not exist");
                }
                return item;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

};