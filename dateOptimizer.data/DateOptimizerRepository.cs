using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using dateOptimizer.domain.contracts;
using dateOptimizer.domain.DataTransferObjects;
using dateOptimizer.data.entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dateOptimizer.data
{
    public class DateOptimizerRepository : IRepository
    {

        private DateOptimizerContext _dateOptimizerContext;

        public DateOptimizerRepository(DateOptimizerContext dateOptimizerContext)
        {
            _dateOptimizerContext = dateOptimizerContext ?? throw new ArgumentNullException();

        }
        public void Dispose()
        {
            _dateOptimizerContext.Dispose();
        }

        public async Task<FipInformationDto> GetDayRangeByCountyAsync(CountyDto county)
        {
            CountyInfoEntity countyEntity = await _dateOptimizerContext.CountyInfo.SingleOrDefaultAsync(x => x.County == county.County && x.State == county.State).ConfigureAwait(false);
            DayRangeEntitity entity = await _dateOptimizerContext.AppraisalPercentages.SingleOrDefaultAsync(x => x.Fip == countyEntity.Fip).ConfigureAwait(false);


            FipInformationDto fipDto = new FipInformationDto
            {
                fip = entity.Fip,
                Days = new double[11],
            };

            fipDto.Days[0] = entity.Day0;
            fipDto.Days[1] = entity.Day1;
            fipDto.Days[2] = entity.Day2;
            fipDto.Days[3] = entity.Day3;
            fipDto.Days[4] = entity.Day4;
            fipDto.Days[5] = entity.Day5;
            fipDto.Days[6] = entity.Day6;
            fipDto.Days[7] = entity.Day7;
            fipDto.Days[8] = entity.Day8;
            fipDto.Days[9] = entity.Day9;
            fipDto.Days[10] = entity.Day10;

            return fipDto;
        }

        public async Task<FipInformationDto> GetDayRangeByFipAsync(int fip)
        {

            DayRangeEntitity entity = await _dateOptimizerContext.AppraisalPercentages.SingleOrDefaultAsync(x => x.Fip == fip).ConfigureAwait(false);
            
            FipInformationDto fipDto = new FipInformationDto
            {
                fip = entity.Fip,
                Days = new double[11],
            };

            fipDto.Days[0] = entity.Day0;
            fipDto.Days[1] = entity.Day1;
            fipDto.Days[2] = entity.Day2;
            fipDto.Days[3] = entity.Day3;
            fipDto.Days[4] = entity.Day4;
            fipDto.Days[5] = entity.Day5;
            fipDto.Days[6] = entity.Day6;
            fipDto.Days[7] = entity.Day7;
            fipDto.Days[8] = entity.Day8;
            fipDto.Days[9] = entity.Day9;
            fipDto.Days[10] = entity.Day10;

            return fipDto;
        }

        public void SeedDatabaseAppraisalPercentages()
        {
            string data = "../dateOptimizer.data/SeedData/data.csv";
            List<DayRangeEntitity> rows = new List<DayRangeEntitity>();
            using (var reader = new StreamReader(data))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    rows.Add(new DayRangeEntitity
                    {
                        Fip = int.Parse(values[0]),
                        Day0 = double.Parse(values[1]),
                        Day1 = double.Parse(values[2]),
                        Day2 = double.Parse(values[3]),
                        Day3 = double.Parse(values[4]),
                        Day4 = double.Parse(values[5]),
                        Day5 = double.Parse(values[6]),
                        Day6 = double.Parse(values[7]),
                        Day7 = double.Parse(values[8]),
                        Day8 = double.Parse(values[9]),
                        Day9 = double.Parse(values[10]),
                        Day10 = double.Parse(values[11]),
                    });
                }
            };

            _dateOptimizerContext.AppraisalPercentages.AddRange(rows);

            _dateOptimizerContext.SaveChanges();
        }
        public void SeedDatabaseCountyInfo()
        {
            string data = "../dateOptimizer.data/SeedData/countyInfo.csv";
            List<CountyInfoEntity> rows = new List<CountyInfoEntity>();
            using (var reader = new StreamReader(data))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    rows.Add(new CountyInfoEntity
                    {
                        Fip = int.Parse(values[0]),
                        County = values[1],
                        State = values[2],
                    });
                }
            };

            _dateOptimizerContext.CountyInfo.AddRange(rows);

            _dateOptimizerContext.SaveChanges();
        }
    }
}