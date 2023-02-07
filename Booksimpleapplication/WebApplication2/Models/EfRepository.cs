using System;
using System.Collections.Generic;
using System.Linq;


namespace WebApplication2.Models
{
    public class EfRepository : IRepository
    {
        private booksContext context;
        public EfRepository(booksContext context)
        {
            this.context = context;
        }

        public IQueryable<Book> Books => context.Books;

        public void Create(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();  
        }

        public void Delete(int id)
        {
            var entity = context.Books.Find(id);
            context.Books.Remove(entity);
            context.SaveChanges();
        }

        public Book GetById(int bookId)
        {
            return context.Books.Where(i => i.Id == bookId).FirstOrDefault(); // tek değer için // find birden fazla id için kullanılabilir.       }

        }

        public void Update(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();
            //var entity = context.Books.Find(book.Id);
            /*if(entity == null)
            {
                entity.Id = book.Id;
                entity.Author = book.Author;
                entity.Title = book.Title;
                entity.Class = book.Class;
                
                context.SaveChanges();
            }*/
        }
    }
}

