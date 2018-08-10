using System;
using System.Threading.Tasks;
using dateOptimizer.domain.DataTransferObjects;

namespace dateOptimizer.domain.contracts {
    public interface IRepository : IDisposable
    {
        Task<FipInformationDto> GetDayRangeByFipAsync(int fip);
        Task<FipInformationDto> GetDayRangeByCountyAsync(CountyDto county);
    }
}