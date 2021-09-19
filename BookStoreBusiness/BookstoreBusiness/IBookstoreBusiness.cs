using System.Collections.Generic;
using BookStoreBusiness;

namespace BookstoreBusiness.BookstoreBusiness
{
    public interface IBookstoreBusiness
    {
        List<BookEntity> GetAllBooks();
        bool InsertBook(BookEntity book);
        bool UpdateBook(BookEntity book);
        bool DeleteBook(int bookId);
        string GetCurrentFormat();
        List<BookEntity> SearchBook(string bookName, string author, int? year);
    }
}
