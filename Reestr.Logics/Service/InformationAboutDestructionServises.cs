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
    public class InformationAboutDestructionServises
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContextReestr _dbContextReestr;

        public InformationAboutDestructionServises(IUnitOfWork unitOfWork, DbContextReestr dbContextReestr)
        {
            _unitOfWork = unitOfWork;
            _dbContextReestr = dbContextReestr;
        }
   
        public async Task<IQueryable<InformationAboutDestruction>> GetInformationAboutDestructions(Query query = null)
        {
            var items = _dbContextReestr.InformationAboutDestruction.AsQueryable();

            items = items.Include(i => i.RegisterOfEmergencyBuildings);

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

        public async Task<InformationAboutDestruction> GetInformationAboutDestructionByIdInformationAboutDestruction(int? idInformationAboutDestruction)
        {
            var items = _dbContextReestr.InformationAboutDestruction
                              .AsNoTracking()
                              .Where(i => i.IdInformationAboutDestruction == idInformationAboutDestruction);

            items = items.Include(i => i.RegisterOfEmergencyBuildings);

            var itemToReturn = items.FirstOrDefault();

            return await Task.FromResult(itemToReturn);
        }

        public void Reset() => _dbContextReestr.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task<InformationAboutDestruction> UpdateInformationAboutDestruction(int? idInformationAboutDestruction, InformationAboutDestruction informationAboutDestruction)
        {
          
            var itemToUpdate = _dbContextReestr.InformationAboutDestruction
                              .Where(i => i.IdInformationAboutDestruction == idInformationAboutDestruction)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

          
            var entryToUpdate = _dbContextReestr.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(informationAboutDestruction);
            entryToUpdate.State = EntityState.Modified;
            await _dbContextReestr.SaveChangesAsync();

            return informationAboutDestruction;
        }

        public async Task<InformationAboutDestruction> CreateInformationAboutDestruction(InformationAboutDestruction informationAboutDestruction)
        {
            var existingItem = _dbContextReestr.InformationAboutDestruction
                              .Where(i => i.IdInformationAboutDestruction == informationAboutDestruction.IdInformationAboutDestruction)
                              .FirstOrDefault();

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _dbContextReestr.InformationAboutDestruction.Add(informationAboutDestruction);
                await _dbContextReestr.SaveChangesAsync();
            }
            catch
            {
                _dbContextReestr.Entry(informationAboutDestruction).State = EntityState.Detached;
                informationAboutDestruction.RegisterOfEmergencyBuildings = null;
                throw;
            }

            return informationAboutDestruction;
        }
    }
}
