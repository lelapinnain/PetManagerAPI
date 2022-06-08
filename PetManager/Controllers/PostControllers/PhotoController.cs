using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure.Photos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PetManager.Utilities.Photo;


namespace PetManager.Controllers.PostControllers
{
    //public class PhotoController : AbstractPhotoController<IFormFile>
    //{

        

    //    private readonly Cloudinary _Cloudinary;
    //    public PhotoController(IOptions<CloudinarySettings> opt)
    //    {
    //        var account = new Account(
    //         opt.Value.CloudName,
    //         opt.Value.ApiKey,
    //         opt.Value.ApiSecret
    //     );
    //        _Cloudinary = new Cloudinary(account);
    //    }
    //    [Route("PetManager/Photos")]
    //    public override async Task<IActionResult> Photo([FromForm] IFormFile File)
    //    {
    //        AddPhoto p = new AddPhoto(_Cloudinary);
    //        var res = await p.FileUpload(File);

    //        return Ok("ok");
    //    }

        
       
        

    //}
}
