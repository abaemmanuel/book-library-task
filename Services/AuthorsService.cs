using my_books.Data;
using my_books.Data.Models;
using my_books.Data.ViewModel;
using System.Linq;

namespace my_books.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void AddAuthor(AuthorVM book)
        {
            var author = new Author()
            {
                FullName = book.FullName
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        //Gettings Books of an Author (Many-to-Many relationship)
        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var authors = _context.Authors.Where(x => x.Id == authorId).Select(x => new AuthorWithBooksVM()
            {
                FullName = x.FullName,
                BookTitles = x.Book_Authors.Select(x => x.Book.Title).ToList()
            }).FirstOrDefault();
            return authors;
        }
    }
}
