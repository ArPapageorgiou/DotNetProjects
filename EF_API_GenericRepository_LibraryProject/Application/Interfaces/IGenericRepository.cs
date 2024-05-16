namespace Application.Interfaces
{

    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool DoesItemExist(int id);
        void Add(T entity);
        void Delete(int id);

    }
}
