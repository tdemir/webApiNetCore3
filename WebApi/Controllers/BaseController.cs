using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger  logger;

        // [System.Runtime.CompilerServices.Dependency]
        // protected Models.ApiDbContext dbContext;

        public BaseController(ILogger logger)
        {
            this.logger = logger;
            
        }

    }
}