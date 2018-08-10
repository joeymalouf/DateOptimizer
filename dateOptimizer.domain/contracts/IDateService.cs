using System.Threading.Tasks;
using dateOptimizer.domain.DataTransferObjects;

namespace dateOptimizer.domain.contracts
{
    public interface IDateService
    {
        Task<DayRangeDto> GetDatesByFipAsync(int fip);

        Task<DayRangeDto> GetDatesByCountyAsync(CountyDto county);
    }
}