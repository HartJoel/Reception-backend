using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.VisitItem;
using api.Model;

namespace api.Mapper
{
    public static class VisitItemMapper
    {
        public static VisitItemDto ToVisitItemDto(this VisitItem item)
        {
            return new VisitItemDto
            {
                Id = item.Id,
                SerialNumber = item.SerialNumber,
                LaptopModel = item.LaptopModel,
                VisitId = item.VisitId
            };
        }

        public static VisitItem ToVisitItemFromCreateDto(this CreateVisitItemDto dto)
        {
            return new VisitItem
            {
                SerialNumber = dto.SerialNumber,
                LaptopModel = dto.LaptopModel,
                VisitId = dto.VisitId
            };
        }

    }
}