using System;
using System.Threading.Tasks;
using dateOptimizer.domain.contracts;
using dateOptimizer.domain.DataTransferObjects;

namespace dateOptimizer.domain.services
{
    public class DateService : IDateService
    {
        private IRepository _repository;

        public DateService(IRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException();
        }
        public DayRangeDto GetDatesByFip(int fip)
        {

            DayRangeDto DayRange = _repository.GetDayRange(fip);

            return DayRange;
        }
    }
}