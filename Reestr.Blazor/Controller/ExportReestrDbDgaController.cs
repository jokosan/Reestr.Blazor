using Microsoft.AspNetCore.Mvc;
using Reestr.Database.Context;
using Reestr.Logics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reestr.Blazor.Controller
{
    public partial class ExportReestrDbDgaController : ExportController
    {
        private readonly DbContextReestr context;
        private readonly RegisterOfEmergencyBuildingsServices service;
        public ExportReestrDbDgaController(DbContextReestr context, RegisterOfEmergencyBuildingsServices service)
        {
            this.service = service;
            this.context = context;
        }


        [HttpGet("/export/ReestrDbDga/registerofemergencybuildings/csv")]
        [HttpGet("/export/ReestrDbDga/registerofemergencybuildings/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRegisterOfEmergencyBuildingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRegisterOfEmergencyBuildings(), Request.Query), fileName);
        }

        [HttpGet("/export/ReestrDbDga/registerofemergencybuildings/excel")]
        [HttpGet("/export/ReestrDbDga/registerofemergencybuildings/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRegisterOfEmergencyBuildingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRegisterOfEmergencyBuildings(), Request.Query), fileName);
        }
    }

}
