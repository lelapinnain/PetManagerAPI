namespace PetManager.Utilities
{
    public interface IUtility<T>
    {
        Task<T> Execute();
    }
}
