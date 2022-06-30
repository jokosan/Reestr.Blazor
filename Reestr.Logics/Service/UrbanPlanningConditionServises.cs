using Microsoft.EntityFrameworkCore;
using Radzen;
using Reestr.Database.Context;
using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class UrbanPlanningConditionServises
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContextReestr _dbContext;

        public UrbanPlanningConditionServises(IUnitOfWork unitOfWork, DbContextReestr dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public async Task<IQueryable<UrbanPlanningConditions>> GetUrbanPlanningConditions(Query query = null)
        {
            var items = _dbContext.UrbanPlanningConditions.AsQueryable();

            items = items.Include(i => i.Land);

            items = items.Include(i => i.DocumentStatus);

            items = items.Include(i => i.TypeOfConstruction);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach (var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            return await Task.FromResult(items);
        }

        public async Task<UrbanPlanningConditions> GetUrbanPlanningConditionByIdUrbanPlanningConditions(int? idUrbanPlanningConditions)
        {
            var items = _dbContext.UrbanPlanningConditions
                              .AsNoTracking()
                              .Where(i => i.IdUrbanPlanningConditions == idUrbanPlanningConditions);

            items = items.Include(i => i.Land);

            items = items.Include(i => i.DocumentStatus);

            items = items.Include(i => i.TypeOfConstruction);

            var itemToReturn = items.FirstOrDefault();

            return await Task.FromResult(itemToReturn);
        }


        public async Task<UrbanPlanningConditions> CreateUrbanPlanningCondition(UrbanPlanningConditions urbanPlanningCondition)
        {
            var existingItem = await _unitOfWork.UrbanPlanningConditionsUnitOfWork
                              .QueryObjectGraph(i => i.IdUrbanPlanningConditions == urbanPlanningCondition.IdUrbanPlanningConditions);

            var existingItemFirst = existingItem.FirstOrDefault();

            if (existingItemFirst != null)
            {
                throw new Exception("Item already available");
            }

            _unitOfWork.UrbanPlanningConditionsUnitOfWork.Insert(urbanPlanningCondition);
            await _unitOfWork.Save();

            return urbanPlanningCondition;
        }

        public async Task<UrbanPlanningConditions> UpdateUrbanPlanningCondition(int? idUrbanPlanningConditions, UrbanPlanningConditions urbanPlanningCondition)
        {
            var itemToUpdate = await _unitOfWork.UrbanPlanningConditionsUnitOfWork
                              .QueryObjectGraph(i => i.IdUrbanPlanningConditions == urbanPlanningCondition.IdUrbanPlanningConditions);

            var itemToUpdateFirst = itemToUpdate.FirstOrDefault();

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            _unitOfWork.UrbanPlanningConditionsUnitOfWork.Update(urbanPlanningCondition);
            await _unitOfWork.Save();

            return urbanPlanningCondition;
        }

        public void Reset() => _dbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
    }
}
