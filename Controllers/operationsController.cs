using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using azure_test.Data;
using azure_test.Models;
using azure_test.Services;

namespace azure_test.Controllers
{
    [Route("api")]
    [ApiController]
    public class operationsController : ControllerBase
    {
        private readonly azure_testContext _context;

        public operationsController(azure_testContext context)
        {
            _context = context;
        }

        // GET: api/operations
        [Route("/operations")]
        [HttpGet]
        public async Task<IActionResult> getAllOperations()
        {

            try
            {
                operationsServices services = new operationsServices(_context);
                var result = await services.ListOperations();
                return Ok(new { operations = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [Route("/newOperation")]
        [HttpPost]
        public async Task<IActionResult> createAnOperation(operationsModel o)
        {

            try
            {
                operationsServices services = new operationsServices(_context);
                var results = await services.calculateOperation(o);

                return Ok(new { result = results});

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

       
    }
}
