using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reestr.Logics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reestr.Api.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterOfEmergencyBuildingsController : ControllerBase
    {
        private readonly RegisterOfEmergencyBuildingsServices _registerOfEmergencyBuildingsServices;

        public RegisterOfEmergencyBuildingsController(
            RegisterOfEmergencyBuildingsServices registerOfEmergencyBuildingsServices)
        {
            _registerOfEmergencyBuildingsServices = registerOfEmergencyBuildingsServices;
        }

        // GET: api/<RegisterOfEmergencyBuildingsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _registerOfEmergencyBuildingsServices.GetQuerie());
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        //// GET api/<RegisterOfEmergencyBuildingsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<RegisterOfEmergencyBuildingsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<RegisterOfEmergencyBuildingsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RegisterOfEmergencyBuildingsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
