using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Radzen;
using Reestr.Logics.Infrastructure.UnitOfWorks;
using Reestr.Logics.Service;

namespace Reestr.Logics.Modul.GoeJson
{
    public class GoeJsonSerialize
    {


        public async Task Test()
        {
           // var reestrDbGetRegisterOfEmergencyBuildingsResult = await _unitOfWork.RegisterOfEmergencyBuildingsUnitOfWork.GetInclude("AddressingApi");

            //var point = new List<Point>();

            //foreach (var itemGeo in reestrDbGetRegisterOfEmergencyBuildingsResult)
            //{
            //    if (itemGeo.AddressingApi != null)
            //    {
            //        point.Add(new Point(new Position(Convert.ToDouble(itemGeo.AddressingApi.Lat), Convert.ToDouble(itemGeo.AddressingApi.Longi))));
            //    }               
            //}

            //var multiPoint = new MultiPoint(point);
            //var acualJson = JsonConvert.SerializeObject(new Feature(multiPoint, null));
       

        }
    }
}
