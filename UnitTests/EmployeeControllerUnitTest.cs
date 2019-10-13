using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class EmployeeControllerUnitTest
    {
        [Fact(DisplayName = "Employee count should return 1")]
        public async Task Employee_count_should_return_1()
        {
            // Arrange
            var _dbName = nameof(EmployeeControllerUnitTest) + "." + nameof(Employee_count_should_return_1);
            using (var dbContext = DbContextMocker.GetApiDbContext(_dbName))
            {
                var controller = new WebApi.Controllers.EmployeeController(null, new WebApi.Services.EmployeeService(dbContext));

                //Act
                var response = await controller.Get();

                //Assert
                Assert.True(response.Count == 1);
            }
        }

        
    }
}