using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Reestr.Logics.Model;
using Reestr.Logics.Contract.ServiceContract;
using Reestr.Database.Model;
using Reestr.Database.Context;
using Radzen;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Reestr.Logics.Service
{
    public class StreetsService : IStreets
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContextReestr _dbContextReestr;

        public StreetsService(
            IUnitOfWork unitOfWork, DbContextReestr dbContextReestr)
        {
            _unitOfWork = unitOfWork;
            _dbContextReestr = dbContextReestr;
        }

        public async Task<IQueryable<Streets>> GetStreets(Query query = null)
        {
            var items = _dbContextReestr.Streets.AsQueryable();

            items = items.Include(i => i.StreetCategory);

            items = items.Include(i => i.Solution);

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

        public async Task<Streets> CreateStreet(Streets streets)
        {
            var existingItem = await _unitOfWork.StreetCategoryUnitOfWork.GetById(streets.IdStreets);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _unitOfWork.StreetsUnitOfWork.Insert(streets);
                await _unitOfWork.Save();
            }
            catch
            {
                throw;
            }

            return streets;
        }

        public async Task<Streets> UpdateStreet(int? idStreet, Streets streets)
        {
            var itemToUpdate = await _unitOfWork.StreetsUnitOfWork.GetById(idStreet);

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            _unitOfWork.StreetsUnitOfWork.Update(streets);
            await _unitOfWork.Save();

            return streets;
        }

        public async Task<Streets> GetStreetByIdStreets(int? idStreets)
        {
            var items = await _unitOfWork.StreetsUnitOfWork.FirstOrDefaultAsyncInclude(x => x.IdStreets ==idStreets, "StreetCategory", "Solution");

            return await Task.FromResult(items);
        }
    }
}
