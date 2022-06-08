using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers.PostControllers
{
    public abstract class AbstractPhotoController<T> : ControllerBase
    {
        [HttpPost]
        // public abstract Task<IActionResult> Photo([FromForm] T File);
        public abstract Task<IActionResult> Post([FromForm] T input);
    }
}

