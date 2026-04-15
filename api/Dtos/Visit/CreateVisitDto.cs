using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Visit
{
    public class CreateVisitDto
    {  
    [Required]
    [StringLength(500)]
    public string PurposeOfVisit { get; set; } = string.Empty;
    [Required]
    public string FloorNumber { get; set; } = string.Empty;
    public string? HostName { get; set; }
    public string? HostDepartment { get; set; }
    [Required]
    public DateTime CheckInTime { get; set; }
    }
}