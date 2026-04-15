using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Visit;
using api.Model;

namespace api.Mapper
{
    public static class VisitMapper
    {
          public static VisitDto ToVisitDto(this Visit visit)
        {
            return new VisitDto
            {
                Id = visit.Id,
                VisitorId = visit.VisitorId,
                PurposeOfVisit = visit.PurposeOfVisit,
                TagNumber = visit.TagNumber,
                FloorNumber = visit.FloorNumber,
                HostName = visit.HostName,
                HostDepartment = visit.HostDepartment,
                RescheduleDate = visit.RescheduleDate,
                RegisteredAt = visit.RegisteredAt,
                CheckInTime = visit.CheckInTime,
                CheckOutTime = visit.CheckOutTime,
                CheckedOutBy = visit.CheckedOutBy,
                Status = visit.Status,

                VisitItems = visit.VisitItems
                    .Select(item => item.ToVisitItemDto())
                    .ToList()
            };
        }

        public static Visit ToVisitFromCreateDto(this CreateVisitDto dto, int visitorId)
        {
            return new Visit
            {
                VisitorId = visitorId,
                PurposeOfVisit = dto.PurposeOfVisit,
                FloorNumber = dto.FloorNumber,
                HostName = dto.HostName,
                HostDepartment = dto.HostDepartment,
                CheckInTime = dto.CheckInTime,
                RegisteredAt = DateTime.UtcNow,
                Status = VisitStatus.Pending,
                 CheckedOutBy = ""
            };
        }
    
    }
}