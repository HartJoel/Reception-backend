using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interface
{
    public interface IVisitItemRepository
    {
        Task<List<VisitItem>> GetAllAsync();
        Task<VisitItem?> GetByIdAsync(int id);
        Task<VisitItem> CreateAsync(VisitItem itemModel);
        Task<VisitItem?> UpdateAsync(int id, VisitItem itemModel);
        Task<VisitItem?> DeleteAsync(int id);

        // 🔥 Very important for your use case
        Task<List<VisitItem>> GetByVisitIdAsync(int visitId);
    }
}