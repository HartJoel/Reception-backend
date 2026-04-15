using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.VisitItem
{
    public class VisitItemDto
    {
    public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public string? LaptopModel { get; set; }
    public int VisitId { get; set; }
    }
}