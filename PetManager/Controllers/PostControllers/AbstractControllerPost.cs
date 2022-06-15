using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers.PostControllers
{
    public abstract class AbstractControllerPost<T>:ControllerBase
    {
           [HttpPost]
        public abstract Task<IActionResult> Post([FromBody] T input);
    }
}
