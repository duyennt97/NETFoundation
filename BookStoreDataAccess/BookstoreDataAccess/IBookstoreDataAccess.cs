using System.Collections.Generic;
using BookStoreDataAccess;

namespace BookStoreConsole.BookstoreDataAccess
{
    public interface IBookstoreDataAccess
    {
        void SetDataFile(string filePath);
        List<Book> GetAllBooks();
        bool SaveBookList(List<Book> books);
        bool InsertBook(Book book);
    }
}
