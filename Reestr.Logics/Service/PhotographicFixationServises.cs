using Microsoft.EntityFrameworkCore;
using Radzen;
using Reestr.Database.Context;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class PhotographicFixationServises
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContextReestr _dbContextReestr;

        public PhotographicFixationServises(IUnitOfWork unitOfWork, DbContextReestr dbContextReestr)
        {
            _unitOfWork = unitOfWork;
            _dbContextReestr = dbContextReestr;
        }

        public IEnumerable<Database.Model.PhotographicFixation> GetPagingCard(int skip, int take)
        {
            return _dbContextReestr.PhotographicFixations.Include("RegisterOfEmergencyBuildings").Include("RegisterOfEmergencyBuildings.AddressingApi").Skip(skip).Take(take).ToList();
        }

        public async Task<IQueryable<Database.Model.PhotographicFixation>> GetPhotographicFixations(Query query = null)
        {
            var items = _dbContextReestr.PhotographicFixations.AsQueryable();

            items = items.Include(i => i.RegisterOfEmergencyBuildings.AddressingApi);
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

        public async Task<Database.Model.PhotographicFixation> DeletePhotographicFixation(int? idPhotographicFixation)
        {
            var itemToDelete = _dbContextReestr.PhotographicFixations
                              .Where(i => i.IdPhotographicFixation == idPhotographicFixation)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
                throw new Exception("Item no longer available");
            }

            _dbContextReestr.PhotographicFixations.Remove(itemToDelete);

            try
            {
                _dbContextReestr.SaveChanges();
            }
            catch
            {
                _dbContextReestr.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            return itemToDelete;
        }

        public async Task<Database.Model.PhotographicFixation> CreateAddressing(Database.Model.PhotographicFixation photographicFixation)
        {
            var existingItem = await _unitOfWork.PhotographicFixationUnitOfWork.GetById(photographicFixation.IdPhotographicFixation);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _unitOfWork.PhotographicFixationUnitOfWork.Insert(photographicFixation);
                await _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception($"Update photo Error: {e.Message}");
            }

            return photographicFixation;
        }

        public async Task<IEnumerable<Database.Model.PhotographicFixation>> GetById(int id)
            => await _unitOfWork.PhotographicFixationUnitOfWork.QueryObjectGraph(x => x.RegisterOfEmergencyBuildingsId == id);
    }
}
