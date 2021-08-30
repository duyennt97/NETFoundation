﻿using System.Collections.Generic;
using System.Linq;
using BookStoreConsole.BookstoreDataAccess;
using BookStoreConsole.Data;

namespace BookStoreConsole.BookstoreBusiness
{
    public class BookstoreBusinessImpl : IBookstoreBusiness
    {
        private IBookstoreDataAccess _bookstoreDa;
        private IBookstoreDataAccess[] _listDataAccesses;

        public BookstoreBusinessImpl(IBookstoreDataAccess[] dataAccessList)
        {
            _listDataAccesses = dataAccessList;
            _bookstoreDa = dataAccessList.First();
        }

        public void ChangeDataAccessType()
        {
            var currentType = _bookstoreDa.GetType();
            _bookstoreDa = _listDataAccesses.First(d => d.GetType() != currentType);
        }

        public string GetCurrentFormat()
        {
            if (_bookstoreDa.GetType() == typeof(BookstoreDataAccessImpl))
            {
                return "Text";
            }

            return "Json";
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
            var bookToUpdate = bookList.First(b => b.Id == book.Id);
            bookList[bookList.IndexOf(bookToUpdate)] = book;
            return _bookstoreDa.SaveBookList(bookList);
        }

        public bool DeleteBook(int bookId)
        {
            var bookList = _bookstoreDa.GetAllBooks();
            bookList.Remove(bookList.First(b => b.Id == bookId));
            return _bookstoreDa.SaveBookList(bookList);
        }
    }
}
