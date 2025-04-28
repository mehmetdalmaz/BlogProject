
using BlogProject.Data.Abstract;
using BlogProject.Data.Context;

namespace BlogProject.Data.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly BlogContext _context;
        public GenericRepository(BlogContext context)
        {
            _context = context;
        }
        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
                throw new Exception("Entity not found");
            return entity;

        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}