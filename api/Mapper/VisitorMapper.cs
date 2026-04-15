using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Visitor;
using api.Model;

namespace api.Mapper
{
    public static class VisitorMapper
    {
        public static VisitorDto ToVisitorDto(this Visitor visitor)
        {
            return new VisitorDto
            {
                Id = visitor.Id,
                FullName = visitor.FullName,
                PhoneNumber = visitor.PhoneNumber,
                PhotoPath = visitor.PhotoPath,
                VisitorType = visitor.VisitorType.ToString(),
                CreatedAt = visitor.CreatedAt,
               Visits = visitor.Visits.Select(v => v.ToVisitDto()).ToList()
            };
        }

          public static Visitor ToVisitorFromCreateDto(this CreateVisitorDto dto)
             {
        return new Visitor
        {
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber,
            PhotoPath = dto.PhotoPath,
            VisitorType = dto.VisitorType
        };
    }
    }
}