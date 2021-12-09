using Microsoft.AspNetCore.Mvc;

namespace PetManager.Controllers.PutControllers
{
 
        public abstract class AbstractControllerPut<T> : ControllerBase
        {
            [HttpPut]
            public abstract IActionResult Put([FromBody] T input);
        }
    
}
