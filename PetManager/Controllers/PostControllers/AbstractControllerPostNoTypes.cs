using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers.PostControllers
{
    public abstract class AbstractControllerPostNoTypes:ControllerBase
    {
           [HttpPost]
        public abstract IActionResult Post();
    }
}
