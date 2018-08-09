using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dateOptimizer.domain.contracts;
using dateOptimizer.domain.DataTransferObjects;

namespace dateOptimizer.data {
    public class DateOptimizerRepository : IRepository {
        
        private DateOptimizerContext _dateOptimizerContext;

        public DateOptimizerRepository(DateOptimizerContext dateOptimizerContext) {
            _dateOptimizerContext = dateOptimizerContext ?? throw new ArgumentNullException();
        }
        public void Dispose()
        {
            _dateOptimizerContext.Dispose();
        }

        public DayRangeDto GetDayRange(int fip) 
        {
            DayRangeDto DayRange = new DayRangeDto {
                StartDay = 1,
                DayRange = 3
            };

            return DayRange;
        }
    }
}