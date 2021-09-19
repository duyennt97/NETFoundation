using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStoreBusiness;
using BookStoreCommon;
using BookStoreConsole.BookstoreDataAccess;
using BookStoreConsole.Exception;
using BookStoreDataAccess;
using BookStoreDataAccess.BookstoreDataAccess;

namespace BookstoreBusiness.BookstoreBusiness
{
    public class BookstoreBusinessImpl : IBookstoreBusiness
    {
        public IBookstoreDataAccess _bookstoreDa { get; set; }

        public IMapper _bookMapper;

        public BookstoreBusinessImpl(IBookstoreDataAccess dataAccessList, IMapper mapper)
        {
            _bookstoreDa = dataAccessList;
            _bookMapper = mapper;

        }

        public string GetCurrentFormat()
        {
            if (_bookstoreDa.GetType() == typeof(BookstoreDataAccessImpl))
            {
                return "Text";
            }

            return "Json";
        }

        public List<BookEntity> SearchBook(string bookName, string author, int? year)
        {
            var allBook = _bookstoreDa.GetAllBooks();
            var allBookEntities = _bookMapper.Map<List<Book>, List<BookEntity>>(allBook);
            return allBookEntities.Where(b =>
                ((string.IsNullOrEmpty(bookName) || b.Name == bookName) &&
                 (string.IsNullOrEmpty(author) || b.Author == author) &&
                 (!year.HasValue || b.PublishYear == year.Value))).ToList();
        }

        public List<BookEntity> GetAllBooks()
        {
            return  _bookMapper.Map<List<Book>, List<BookEntity>>(_bookstoreDa.GetAllBooks());
        }

        public bool InsertBook(BookEntity book)
        {
            return _bookstoreDa.InsertBook(_bookMapper.Map<BookEntity, Book>(book));
        }

        public bool UpdateBook(BookEntity book)
        {
            var bookList = GetAllBooks();
            var bookToUpdate = bookList.FirstOrDefault(b => b.Id == book.Id);
            if (bookToUpdate == null)
            {
                throw new BookNotFoundException("Can't find book to update");
            }
            bookList[bookList.IndexOf(bookToUpdate)] = book;
            return SaveBookList(bookList);
        }

        public bool DeleteBook(int bookId)
        {
            var bookList = GetAllBooks();
            var deletedBook = bookList.FirstOrDefault(b => b.Id == bookId);
            if (deletedBook == null)
            {
                throw new BookNotFoundException("Can't find book to delete");
            }
            bookList.Remove(deletedBook);
            return SaveBookList(bookList);
        }

        private bool SaveBookList(List<BookEntity> listBook)
        {
            return  _bookstoreDa.SaveBookList(_bookMapper.Map<List<BookEntity>, List<Book>>(listBook));
        }
    }
}
