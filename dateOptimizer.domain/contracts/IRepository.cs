using System;
using dateOptimizer.domain.DataTransferObjects;

namespace dateOptimizer.domain.contracts {
    public interface IRepository : IDisposable
    {
        DayRangeDto GetDayRange(int fip);
    }
}