using Microsoft.EntityFrameworkCore;
using Radzen;
using Reestr.Database.Context;
using Reestr.Database.Model;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Reestr.Logics.Service
{
    public class AddressingServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContextReestr _dbContextReestr;

        public AddressingServices(IUnitOfWork unitOfWork, DbContextReestr dbContextReestr)
        {
            _unitOfWork = unitOfWork;
            _dbContextReestr = dbContextReestr;
        }

        //public async Task<IQueryable<Addressing>> GetAddressings()
        //{
        //    var items = await _unitOfWork.AddressingUnitOfWork.GetInclude("District","Postcode","AddressType", "Streets", "Streets.StreetCategory");

        //   // var items = await _unitOfWork.AddressingUnitOfWork.Include();

        //    return await Task.FromResult(items.AsQueryable());
        //}

        public async Task<IQueryable<Addressing>> GetAddressings(Query query = null)
        {
            var items = _dbContextReestr.Addressings.AsQueryable();

            items = items.Include(i => i.Streets);
            items = items.Include(i => i.Districts);
            items = items.Include(i => i.Postcode);
            items = items.Include(i => i.AddressType);
            items = items.Include(i => i.Streets.StreetCategory);

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

        public async Task<Addressing> CreateAddressing(Addressing addressing)
        {
            var existingItem = await GetAddressingByIdAddressing(addressing.IdAddressing);

            if (existingItem != null)
            {
                throw new Exception("Item already available");
            }

            try
            {
                _unitOfWork.AddressingUnitOfWork.Insert(addressing);
                await _unitOfWork.Save();
            }
            catch
            {
                throw;
            }

            return addressing;
        }

        public async Task<Addressing> UpdateAddressing(int? idAddressing, Addressing addressing)
        {
            var itemToUpdate = GetAddressingByIdAddressing(idAddressing);

            if (itemToUpdate == null)
            {
                throw new Exception("Item no longer available");
            }

            _unitOfWork.AddressingUnitOfWork.Update(addressing);
            await _unitOfWork.Save();

            return addressing;
        }

        public async Task<Addressing> GetAddressingByIdAddressing(int? idAddressing)
        {
            //var items = await _unitOfWork.AddressingUnitOfWork.QueryObjectGraph(x => x.IdAddressing == idAddressing,  "Street", "District", "Postcode", "AddressType");

            //var itemToReturn = items.FirstOrDefault();

            //return await Task.FromResult(itemToReturn);

            var items = _dbContextReestr.Addressings
                              .AsNoTracking()
                              .Where(i => i.IdAddressing == idAddressing);

            items = items.Include(i => i.Streets);

            items = items.Include(i => i.Districts);

            items = items.Include(i => i.Postcode);

            items = items.Include(i => i.AddressType);

            var itemToReturn = items.FirstOrDefault();

            return await Task.FromResult(itemToReturn);
        }

    }
}
