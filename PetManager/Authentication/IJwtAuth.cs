namespace PetManager.Authentication
{
    public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}
