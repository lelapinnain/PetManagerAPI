namespace PetManager.Models.NonQueries
{
    public abstract class AbstractNonQuery<T>
    {
        public abstract void RunQuery();

        public abstract T GetResult();
    }
}


