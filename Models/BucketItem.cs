using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DB_CON.Models;

public class BucketItem
{
    [Key] public int Id { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string Budget { get; set; }
    public bool IsComplete { get; set; }
}