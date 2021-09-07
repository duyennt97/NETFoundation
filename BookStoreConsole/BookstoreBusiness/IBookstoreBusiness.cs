﻿using System.Collections.Generic;
using BookStoreConsole.BookstoreDataAccess;
using BookStoreConsole.Data;

namespace BookStoreConsole.BookstoreBusiness
{
    public interface IBookstoreBusiness
    {
        List<Book> GetAllBooks();
        bool InsertBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int bookId);
        string GetCurrentFormat();
        List<Book> SearchBook(string bookName, string author, int? year);
        void SetDataInterface(IBookstoreDataAccess dataAccessService);
    }
}
