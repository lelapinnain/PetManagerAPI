namespace PetManager.Utilities.Photo
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string PublicId);
    }
}
