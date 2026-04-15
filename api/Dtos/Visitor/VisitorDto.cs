using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Visit;

namespace api.Dtos.Visitor
{
    public class VisitorDto
    {
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PhotoPath { get; set; } = string.Empty;
    public string VisitorType { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<VisitDto> Visits { get; set; } = new();
    }
}