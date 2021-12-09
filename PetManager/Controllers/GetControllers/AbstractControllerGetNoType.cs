using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers.GetControllers
{
    [ApiController]
    public abstract class AbstractControllerGetNoType : ControllerBase
    {
        [HttpGet]
        public abstract IActionResult Get();
    }
}
