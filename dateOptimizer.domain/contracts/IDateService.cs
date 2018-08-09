using System.Threading.Tasks;
using dateOptimizer.domain.DataTransferObjects;

namespace dateOptimizer.domain.contracts
{
    public interface IDateService
    {
        DayRangeDto GetDatesByFip(int fip);
    }
}