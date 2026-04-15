using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface IVisitRepository
    {
        Task<List<Visit>> GetAllAsync();
        Task<Visit?> GetByIdAsync(int id);
        Task<Visit> CreateAsync(Visit visitModel);
        Task<Visit?> UpdateAsync(int id, Visit visitModel);
        Task<Visit?> DeleteAsync(int id);

        Task<List<Visit>> GetByVisitorIdAsync(int visitorId);
        Task<List<Visit>> GetByStatusAsync(VisitStatus status);
    }
}