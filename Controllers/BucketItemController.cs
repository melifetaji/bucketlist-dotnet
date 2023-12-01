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
    private readonly IBucketItemService _bucketItemService;

    public BucketItemController(ApplicationDbContext dbContext, IBucketItemRepository bucketItemRepository, IBucketItemService bucketItemService)
    {
        _dbContext = dbContext;
        _bucketItemRepository = bucketItemRepository;
        _bucketItemService = bucketItemService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        try
        {
            var bucketItems = _bucketItemService.GetAll();
            return View(bucketItems);
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"An error occurred: {e.Message}";
            return View("Error");
        }
    }

    [HttpGet]
    public IActionResult Add()
    {
        try
        {
            return View(new BucketItem());
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"An error occurred: {e.Message}";
            return View("Error");
        }
    }

    [HttpPost]
    public IActionResult Add(BucketItem bucketItem)
    {
        try
        {

            _bucketItemService.AddItem(bucketItem);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"An error occurred: {e.Message}";
            return View("Error");
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        try
        {
            var item = _bucketItemRepository.FindOne(id);
            return View(item);
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"An error occurred: {e.Message}";
            return View("Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _bucketItemService.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"An error occurred: {e.Message}";
            return View("Error");
        }
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        try
        {
            var item = _bucketItemRepository.FindOne(id);
            return View(item);
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"An error occurred: {e.Message}";
            return View("Error");
        }
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(BucketItem bucketItem)
    {
        try
        {
            await _bucketItemService.UpdateItemAsync(bucketItem);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"An error occurred: {e.Message}";
            return View("Error");
        }
    }
    [HttpPost]
    public async Task<IActionResult> MarkAsCompletedAsync(int id)
    {
        try
        {
            await _bucketItemRepository.MarkAsCompleteAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"An error occurred: {e.Message}";
            return View("Error");
        }
    }
};