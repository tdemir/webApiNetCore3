using System.Collections.Generic;
using System.Linq;
using WebApi.Models;
using WebApi.Models.Tables;

namespace WebApi.Extensions
{
    public static class ApiDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this ApiDbContext context)
        {
            if (context.Departments.Any())
            {
                return;
            }

            var department = new Department
            {
                Name = "IT",
                // Employees = new List<Employee>
                // {
                //     new Employee() {Name = "Ahmet"},
                //     new Employee() {Name = "Mehmet"},
                //     new Employee() {Name = "Veli"}
                // }
            };

            context.Departments.Add(department);

            context.Employees.Add(new Employee() { DepartmentId = department.Id, Name = "Ahmet" });
            context.Employees.Add(new Employee() { DepartmentId = department.Id, Name = "Mehmet" });
            context.Employees.Add(new Employee() { DepartmentId = department.Id, Name = "Veli" });

            var employee = new Employee
            {
                Name = "Deli",
                Surname = "",
                DepartmentId = department.Id
            };

            context.Employees.Add(employee);
            context.SaveChanges();
        }

        
    }

    public static class IQueryableExtensions
    {
        public static IQueryable<TModel> Paging<TModel>(this IQueryable<TModel> query, int pageSize = 0, int pageNumber = 0) where TModel : class
            => pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
    }
}