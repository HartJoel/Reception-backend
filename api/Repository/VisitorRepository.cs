using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class VisitorRepository: IVisitorRepository
    {
        private readonly ApplicationDBContext _context;

        public VisitorRepository(ApplicationDBContext context)
        {
            _context = context;
        }

  public async Task<List<Visitor>> GetAllAsync()
        {
            return await _context.Visitor
            .Include(v => v.Visits)
            .ThenInclude(visit => visit.VisitItems)
            .ToListAsync();
        }

        public async Task<Visitor?> GetByIdAsync(int id)
        {
            return await _context.Visitor.FindAsync(id);
        }
        

        public async Task<Visitor> CreateAsync(Visitor visitorModel)
        {
            await _context.Visitor.AddAsync(visitorModel);
            await _context.SaveChangesAsync();
            return visitorModel;
        }

        public async Task<Visitor?> UpdateAsync(int id, Visitor visitorModel)
        {
            var existing = await _context.Visitor.FindAsync(id);
            if (existing == null) return null;

            existing.FullName = visitorModel.FullName;
            existing.PhoneNumber = visitorModel.PhoneNumber;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Visitor?> DeleteAsync(int id)
        {
            var visitor = await _context.Visitor.FindAsync(id);
            if (visitor == null) return null;

            _context.Visitor.Remove(visitor);
            await _context.SaveChangesAsync();
            return visitor;
        }
    }
}