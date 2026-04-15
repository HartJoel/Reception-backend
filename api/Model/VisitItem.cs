using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class VisitItem
    {
     public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public string? LaptopModel { get; set; }
    public int VisitId { get; set; }
    public Visit Visit { get; set; } = null!;
    }
}