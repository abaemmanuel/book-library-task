using my_books.Data;
using my_books.Data.Models;
using my_books.Data.ViewModel;
using System.Linq;

namespace my_books.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void AddPublisher(PublisherVM pub)
        {
            var publish = new Publisher()
            {
                Name = pub.Name
            };
            _context.Publishers.Add(publish);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var publisherData = _context.Publishers.Where(x => x.Id == publisherId)
                .Select(x => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = x.Name,
                    BookAuthors = x.Books.Select(x => new BookAuthorVM()
                    {
                        BookName = x.Title,
                        BookAuthors = x.Book_Authors.Select(x => x.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return publisherData;
        }
    }
}
