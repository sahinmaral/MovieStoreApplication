namespace MovieStoreAppWebAPI.Exceptions
{
    public class EntityNullException : Exception
    {
        public EntityNullException(Type entity) : base($"{entity.Name} bulunamadı.")
        {
        }
    }
}
