using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers.GetControllers
{
    [ApiController]
    public abstract class AbstractControllerGet<T> : ControllerBase
    {
        [HttpGet]
        public abstract Task<IActionResult> Get([FromQuery] T input);
    }
}
