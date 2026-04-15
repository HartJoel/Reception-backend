using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Visit
    {
    public int Id { get; set; }
    public Visitor Visitor { get; set; } = null!;
    public required int VisitorId { get; set; }
    public string PurposeOfVisit { get; set; } = string.Empty;

    public string? TagNumber { get; set; }
    public string FloorNumber { get; set; } = string.Empty;
    public string? HostName { get; set; }
    public string? HostDepartment { get; set; }

    public DateTime? RescheduleDate { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public DateTime CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public required string CheckedOutBy { get; set; }

    public VisitStatus Status { get; set; } = VisitStatus.Pending;
    public ICollection<VisitItem> VisitItems { get; set; } = new List<VisitItem>();


    }
}