using ASPMVCTrial.Data.Interfaces;
using ASPMVCTrial.Data;
using ASPMVCTrial.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPMVCTrial.Services
{
    public class DealService : IDealService
    {
        private readonly ApplicationContext context;

        public DealService(ApplicationContext _context)
        {
            context = _context;
        }
        public bool Add(Deal deal)
        {
            context.Deal.Add(deal);
            return Save();
        }

        public bool Delete(Deal deal)
        {
            context.Deal.Remove(deal);
            return Save();
        }

        public async Task<IEnumerable<Deal>> GetAll() => await context.Deal.ToListAsync();

        public async Task<Deal> GetById(int id) => await context.Deal.FirstOrDefaultAsync(d => d.Id == id);

        public bool Save() => context.SaveChanges() > 0 ? true : false;

        public bool Update(Deal deal)
        {
            context.Deal.Update(deal);
            return Save();
        }
    }
}
