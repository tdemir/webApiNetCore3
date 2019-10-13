using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Extensions;

namespace WebApi.Services
{
    public class EmployeeService
    {
        private readonly Models.ApiDbContext dbContext;
        public EmployeeService(Models.ApiDbContext dbContext)
        {
            this.dbContext = dbContext;

            dbContext.EnsureSeedDataForContext();
        }

        public Task<List<Models.Tables.Employee>> GetEmployees()
        {
            return dbContext.Employees.ToListAsync();
        }

    }
}