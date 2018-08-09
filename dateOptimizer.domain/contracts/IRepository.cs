using System;
using dateOptimizer.domain.DataTransferObjects;

namespace dateOptimizer.domain.contracts {
    public interface IRepository : IDisposable
    {
        FipInformationDto GetDayRange(int fip);
    }
}