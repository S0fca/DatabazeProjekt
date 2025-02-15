namespace DatabazeProjekt.database
{
    internal interface IGenericDAO<T>
    {

        void Add(T entity);
        T GetById(int id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(int id);

    }
}
