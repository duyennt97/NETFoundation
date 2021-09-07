using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreConsole.BookstoreDataAccess;
using BookStoreConsole.Data;

namespace BookStoreConsole.BookstoreBusiness
{
    public class BookstoreBusinessImpl : IBookstoreBusiness
    {
        public IBookstoreDataAccess _bookstoreDa { get; set; }

        public BookstoreBusinessImpl(IBookstoreDataAccess dataAccessList)
        {
            _bookstoreDa = dataAccessList;
        }

        public string GetCurrentFormat()
        {
            if (_bookstoreDa.GetType() == typeof(BookstoreDataAccessImpl))
            {
                return "Text";
            }

            return "Json";
        }

        public List<Book> SearchBook(string bookName, string author, int? year)
        {
            var allBook = _bookstoreDa.GetAllBooks();
            return allBook.Where(b =>
                ((string.IsNullOrEmpty(bookName) || b.Name == bookName) &&
                 (string.IsNullOrEmpty(author) || b.Author == author) &&
                 (!year.HasValue || b.PublishYear == year.Value))).ToList();
        }

        public void SetDataInterface(IBookstoreDataAccess dataAccessService)
        {
            _bookstoreDa = dataAccessService;
        }

        public List<Book> GetAllBooks()
        {
            return _bookstoreDa.GetAllBooks();
        }

        public bool InsertBook(Book book)
        {
            return _bookstoreDa.InsertBook(book);
        }

        public bool UpdateBook(Book book)
        {
            var bookList = _bookstoreDa.GetAllBooks();
            var bookToUpdate = bookList.FirstOrDefault(b => b.Id == book.Id);
            if (bookToUpdate == null)
            {
                throw new ArgumentException("Can't find book to update");
            }
            bookList[bookList.IndexOf(bookToUpdate)] = book;
            return _bookstoreDa.SaveBookList(bookList);
        }

        public bool DeleteBook(int bookId)
        {
            var bookList = _bookstoreDa.GetAllBooks();
            var deletedBook = bookList.FirstOrDefault(b => b.Id == bookId);
            if (deletedBook == null)
            {
                throw new ArgumentException("Can't find book to delete");
            }
            bookList.Remove(deletedBook);
            return _bookstoreDa.SaveBookList(bookList);
        }


    }
}
