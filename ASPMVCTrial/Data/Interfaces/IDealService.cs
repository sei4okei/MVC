using ASPMVCTrial.Models;

namespace ASPMVCTrial.Data.Interfaces
{
    public interface IDealService
    {
        Task<IEnumerable<Deal>> GetAll();
        Task<Deal> GetById(int id);
        bool Add(Deal deal);
        bool Update(Deal deal);
        bool Delete(Deal deal);
        bool Save();
    }
}
