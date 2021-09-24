using System.Collections.Generic;
using BookStoreDataAccess;

namespace BookStoreConsole.BookstoreDataAccess
{
    public interface IBookstoreDataAccess
    {
        List<Book> GetAllBooks();
        bool SaveBookList(List<Book> books);
        bool InsertBook(Book book);
    }
}
