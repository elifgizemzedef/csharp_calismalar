namespace WebApplication2.Models
{
    public interface IRepository
    {
        IQueryable<Book> Books { get; }
        Book GetById(int bookId); 
        void Create (Book book);
        void Update (Book book);
        void Delete (int id);
        
    }
}
