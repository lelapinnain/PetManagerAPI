using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers.DeleteControllers
{
    [ApiController]
    public abstract class AbstractControllerDelete<T> : ControllerBase
    {
        [HttpDelete]
        public abstract IActionResult Delete([FromBody] T input);
    }
}
