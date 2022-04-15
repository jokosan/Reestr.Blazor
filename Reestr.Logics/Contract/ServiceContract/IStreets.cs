﻿using Reestr.Database.Model;
using Reestr.Logics.Contract.GenericContract;
using Reestr.Logics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reestr.Logics.Contract.ServiceContract
{
    public interface IStreets 
    {
        Task<IEnumerable<Streets>> GetStreets();
        Task<Streets> CreateStreet(Streets streets);
        Task<Streets> GetStreetByIdStreets(int? idStreets);
    }
}