using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Model;
using api.Data;

namespace api.Repository
{
    public class VisitRepository : IVisitRepository
    {
        private readonly ApplicationDBContext _context;

        public VisitRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Visit>> GetAllAsync()
        {
            return await _context.Visit
                .Include(v => v.VisitItems)
                .ToListAsync();
        }

        public async Task<Visit?> GetByIdAsync(int id)
        {
            return await _context.Visit
                .Include(v => v.VisitItems)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Visit> CreateAsync(Visit visitModel)
        {
            await _context.Visit.AddAsync(visitModel);
            await _context.SaveChangesAsync();
            return visitModel;
        }

        public async Task<Visit?> UpdateAsync(int id, Visit visitModel)
        {
            var existing = await _context.Visit.FindAsync(id);
            if (existing == null) return null;

            existing.Status = visitModel.Status;
            existing.CheckOutTime = visitModel.CheckOutTime;
            existing.CheckedOutBy = visitModel.CheckedOutBy;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Visit?> DeleteAsync(int id)
        {
            var visit = await _context.Visit.FindAsync(id);
            if (visit == null) return null;

            _context.Visit.Remove(visit);
            await _context.SaveChangesAsync();
            return visit;
        }

        public async Task<List<Visit>> GetByVisitorIdAsync(int visitorId)
        {
            return await _context.Visit
                .Where(v => v.VisitorId == visitorId)
                .ToListAsync();
        }

        public async Task<List<Visit>> GetByStatusAsync(VisitStatus status)
        {
            return await _context.Visit
                .Where(v => v.Status == status)
                .ToListAsync();
        }
    }
}