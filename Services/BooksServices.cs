using my_books.Data;
using my_books.Data.Models;
using my_books.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Services
{
    public class BooksServices
    {
        private readonly AppDbContext _context;

        public BooksServices(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var books = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(books);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var book_author = new Book_Author()
                {
                    BookId = books.Id,
                    AuthorId = id
                };

                _context.Books_Authors.Add(book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }
        //public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBookById(int bookId)
        {
            var allBook = _context.Books.FirstOrDefault(x => x.Id == bookId);
            return allBook;
        }
        public BookWithAuthorsVM GetBookByIdWithAuthors(int bookId)
        {
            var bookWithAuthors = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

            return bookWithAuthors;
        }
        public Book UpdateBookById(int bookId, BookVM book)
        {
            var bookUpdate = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if (bookUpdate != null)
            {
                bookUpdate.Title = book.Title;
                bookUpdate.Description = book.Description;
                bookUpdate.IsRead = book.IsRead;
                bookUpdate.DateRead = book.IsRead ? book.DateRead.Value : null;
                bookUpdate.Rate = book.IsRead ? book.Rate.Value : null;
                bookUpdate.Genre = book.Genre;
                bookUpdate.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return bookUpdate;
        }

        public void DeleteBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
