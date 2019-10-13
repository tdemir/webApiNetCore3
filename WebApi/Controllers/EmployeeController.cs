using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly EmployeeService service;
        public EmployeeController(ILogger<EmployeeController> logger, EmployeeService service) : base(logger)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<Models.Tables.Employee>> Get()
        {
            var list = await service.GetEmployees().ConfigureAwait(false);
            return list;
        }
    }
}