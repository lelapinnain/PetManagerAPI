namespace PetManager.Models.Quereies
{
    public abstract class AbstractQuery<T>
    {
        public abstract Task<string> RunQuery();

        public abstract T GetResult();
    }
}
