namespace PetManager.Models.Quereies
{
    public abstract class AbstractQuery<T>
    {
        public abstract void RunQuery();

        public abstract T GetResult();
    }
}
