namespace DatabazeProjekt.database
{
    internal interface IGenericDAO<T>
    {

        void Add(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(int id);

    }
}
