using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interface
{
    public interface IVisitorRepository
    {
        Task<List<Visitor>> GetAllAsync();
        Task<Visitor?> GetByIdAsync(int id);
        Task<Visitor> CreateAsync(Visitor visitorModel);
        Task<Visitor?> UpdateAsync(int id, Visitor visitorModel);
        Task<Visitor?> DeleteAsync(int id);
    }
}