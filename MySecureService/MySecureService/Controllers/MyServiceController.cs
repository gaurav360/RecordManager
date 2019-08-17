using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySecureService.Models;
using MySecureService.Service;
using System;

namespace MySecureService.Controllers
{
   
    [Route("myservice")]    
    public class MyServiceController : Controller
    {
        private readonly IMyService service;

        public MyServiceController(IMyService _myService)
        {
            service = _myService;
        }

        
        [Route("getall")]
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.GetMyRecords());
            }
            catch (Exception)
            {
                return StatusCode(500, "Service error");
            }
        }

        
        [Route("getbyid")]
        [Authorize(Roles = "user")]
        [HttpGet("{recordId}")]
        public IActionResult Get(string recordId)
        {
            try
            {
                return Ok(service.FindByRecordId(recordId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Service error");
            }
        }
        
       
        [Route("saverecord")]
        [HttpPost]
        public IActionResult Post([FromBody]MyRecords record)
        {
            try
            {
                return Ok(service.SaveRecord(record));
            }            
            catch (Exception)
            {
                return StatusCode(500, "Service error");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("health")]
        public IActionResult HealthCheck()
        {
            try
            {
                return Ok("Healthy...");
            }
            catch (Exception)
            {
                return StatusCode(500, "Service error");
            }
        }
    }
}