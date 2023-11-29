using System.CodeDom.Compiler;
using DB_CON.Models;
using DB_CON.Repositories;
using DB_CON.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DB_CON.Controllers;

public class BucketItemController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IBucketItemRepository _bucketItemRepository;

    public BucketItemController(ApplicationDbContext dbContext, IBucketItemRepository bucketItemRepository)
    {
        _dbContext = dbContext;
        _bucketItemRepository = bucketItemRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var bucketItems = _bucketItemRepository.GetAll();
        return View(bucketItems);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View(new BucketItem());
    }

    [HttpPost]
    public IActionResult Add(BucketItem bucketItem)
    {
        if (ModelState.IsValid)
        {
            _bucketItemRepository.AddItem(bucketItem);
            return RedirectToAction("Index");
        }
        return View(bucketItem);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _bucketItemRepository.DeleteAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var item = _bucketItemRepository.FindOne(id);
        return View(item);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var item = _bucketItemRepository.FindOne(id);
        return View(item);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(BucketItem bucketItem)
    {
        var item = _bucketItemRepository.FindOne(bucketItem.Id);

        item.CityName = bucketItem.CityName;
        item.CountryName = bucketItem.CountryName;
        item.Budget = bucketItem.Budget;
        item.IsComplete = bucketItem.IsComplete;

        await _bucketItemRepository.UpdateAsync(item);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> MarkAsCompletedAsync(int id)
    {
        await _bucketItemRepository.MarkAsCompleteAsync(id);
        return RedirectToAction("Index");
    }
};