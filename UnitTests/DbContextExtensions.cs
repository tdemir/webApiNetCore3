using System;
using WebApi.Models;
using WebApi.Models.Tables;
using Xunit;

namespace UnitTests
{
    public static class DbContextExtensions
    {
        public static void Seed(this ApiDbContext dbContext)
        {
            var department = new Department(){
                Name = "IT"
            };
            dbContext.Departments.Add(department);
            dbContext.Employees.Add(new Employee(){
                Name = "Ali",DepartmentId = department.Id
            });
            dbContext.SaveChanges();
        }
    }
}