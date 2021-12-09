using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers.GetControllers
{
    [ApiController]
    public abstract class AbstractControllerGet<T> : ControllerBase
    {
        [HttpGet]
        public abstract IActionResult Get([FromQuery] T input);
    }
}
