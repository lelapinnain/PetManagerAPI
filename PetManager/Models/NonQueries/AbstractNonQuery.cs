namespace PetManager.Models.NonQueries
{
    public abstract class AbstractNonQuery<T>
    {
        public abstract Task<string> RunQuery();

        public abstract T GetResult();
    }
}


