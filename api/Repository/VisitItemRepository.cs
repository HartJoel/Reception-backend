using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Model;
using api.Data;
using api.Interface;

namespace api.Repository
{
    public class VisitItemRepository : IVisitItemRepository
    {
        private readonly ApplicationDBContext _context;

        public VisitItemRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<VisitItem>> GetAllAsync()
        {
            return await _context.VisitItem.ToListAsync();
        }

        public async Task<VisitItem?> GetByIdAsync(int id)
        {
            return await _context.VisitItem.FindAsync(id);
        }

        public async Task<VisitItem> CreateAsync(VisitItem itemModel)
        {
            await _context.VisitItem.AddAsync(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<VisitItem?> UpdateAsync(int id, VisitItem itemModel)
        {
            var existing = await _context.VisitItem.FindAsync(id);
            if (existing == null) return null;

            existing.SerialNumber = itemModel.SerialNumber;
            existing.LaptopModel = itemModel.LaptopModel;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<VisitItem?> DeleteAsync(int id)
        {
            var item = await _context.VisitItem.FindAsync(id);
            if (item == null) return null;

            _context.VisitItem.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<VisitItem>> GetByVisitIdAsync(int visitId)
        {
            return await _context.VisitItem
                .Where(i => i.VisitId == visitId)
                .ToListAsync();
        }
    }
}