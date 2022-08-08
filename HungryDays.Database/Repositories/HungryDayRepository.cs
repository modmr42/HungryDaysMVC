﻿using HungryDays.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryDays.Database.Repositories
{
    public class HungryDayRepository
    {
        private HungryDaysDbContext _dbContext;
        public HungryDayRepository(HungryDaysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<HungryDayEntity>> GetHungryDaysAsync()
        {
            return await _dbContext.HungryDays
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<HungryDayEntity> GetHungryDayAsync(int id)
        {
            return await _dbContext.HungryDays
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync() =>
            await _dbContext.SaveChangesAsync();

        //public async Task UpdateHungryDayAsync(HungryDayEntity hungryDayEntity)
        //{
        //    if (hungryDayEntity == null)
        //        throw new ArgumentNullException(nameof(hungryDayEntity));

        //    var hungryDay = await _dbContext.HungryDays.FirstOrDefaultAsync(x => x.Id == hungryDayEntity.Id);

        //    await _dbContext.SaveChangesAsync();
        //}
    }
}