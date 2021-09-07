using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreBusiness.BookstoreBusiness;
using BookstoreBusiness.Ninject;
using BookStoreCommon;
using BookStoreConsole.BookstoreDataAccess;
using BookStoreConsole.Data;
using FluentAssertions;
using Ninject;
using NSubstitute;
using NUnit.Framework;

namespace BookStoreTest
{
    [TestFixture]
    public class BookStoreTest
    {
        private IBookstoreBusiness _bookstoreBusiness;
        private IBookstoreDataAccess _mockBookstoreDataAccess;

        private List<Book> _listTestBooks;

        [OneTimeSetUp]
        public void InitBinding()
        {
            IoC.Initialize(new StandardKernel(new NinjectSettings() {LoadExtensions =  true}),
                new ServiceBinding());
            _bookstoreBusiness = IoC.Get<IBookstoreBusiness>("TEXT");
        }

        [SetUp]
        public void InitTest()
        {
            ResetListBook();
            _mockBookstoreDataAccess = GetMockBookstoreDa();
            _bookstoreBusiness.SetDataInterface(_mockBookstoreDataAccess);
        }

        public void ResetListBook()
        {
            _listTestBooks = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Author = "Author 1",
                    Name = "Name 1",
                    PublishYear = 2021
                },
                new Book()
                {
                    Id = 2,
                    Author = "Author 2",
                    Name = "Name 2",
                    PublishYear = 2020
                },
                new Book()
                {
                    Id = 3,
                    Author = "Author 3",
                    Name = "Name 3",
                    PublishYear = 2020
                }
            };
        }

        private IBookstoreDataAccess GetMockBookstoreDa()
        {
            var bookstoreDa = Substitute.For<IBookstoreDataAccess>();

            bookstoreDa.GetAllBooks().Returns(_listTestBooks);

            bookstoreDa.InsertBook(Arg.Do<Book>(x => _listTestBooks.Add(x)))
                .Returns(true);

            bookstoreDa.SaveBookList(Arg.Do<List<Book>>(x => _listTestBooks = x))
                .Returns(true);

            return bookstoreDa;
        }

        [Test]
        public void GetAllBookTest()
        {
            var allBook = _bookstoreBusiness.GetAllBooks();
            allBook.ShouldBeEquivalentTo(_listTestBooks);
        }

        [Test]
        public void InsertBookTest()
        {
            var insertBook = new Book()
            {
                Author = "Test insert",
                Name = "Test name",
                PublishYear = 1999
            };

            var listBook = _bookstoreBusiness.GetAllBooks().ToList();
            var insertResult = _bookstoreBusiness.InsertBook(insertBook);
            var listBookAfterInsert = _bookstoreBusiness.GetAllBooks();

            insertResult.Should().BeTrue();
            listBookAfterInsert.Count.Should().Be(listBook.Count + 1);
        }

        [Test]
        public void UpdateBookSuccessTest()
        {
            string newName = "Updated book name";
            var listBook = _bookstoreBusiness.GetAllBooks();
            listBook[0].Name = newName;

            var updateResult = _bookstoreBusiness.UpdateBook(listBook[0]);
            
            var listBookAfterUpdate = _bookstoreBusiness.GetAllBooks();

            updateResult.Should().BeTrue();
            listBookAfterUpdate[0].Name.Should().Be(newName);
        }

        [Test]
        public void UpdateBookNotAvailableTest()
        {
            var newBook = new Book()
            {
                Author = "Test author",
                Name = "Test name",
                PublishYear = 2000
            };
            Action action = () => _bookstoreBusiness.UpdateBook(newBook);
            action.ShouldThrow<ArgumentException>("Can't find book to update");
        }

        [Test]
        public void DeleteBookSuccessTest()
        {
            var listBook = _bookstoreBusiness.GetAllBooks().ToList();
            var deleteBook = listBook[0];
            var deleteResult = _bookstoreBusiness.DeleteBook(deleteBook.Id);

            var listBookAfterDelete = _bookstoreBusiness.GetAllBooks();

            deleteResult.Should().BeTrue();
            listBookAfterDelete.Should().HaveCount(listBook.Count - 1);

            var deletedBook = listBookAfterDelete.FirstOrDefault(x => x.Id == deleteBook.Id);
            deletedBook.Should().BeNull();
        }

        [Test]
        public void DeleteBookNotAvailableTest()
        {
            var newBook = new Book()
            {
                Id = 4,
                Author = "Test author",
                Name = "Test name",
                PublishYear = 2000
            };
            Action action = () => _bookstoreBusiness.DeleteBook(newBook.Id);
            action.ShouldThrow<ArgumentException>("Can't find book to delete");
        }

        [Test]
        public void SearchBookByNameTest()
        {
            var books= _bookstoreBusiness.SearchBook("Name 1", string.Empty, null);
            books.Should().ContainSingle();
            books[0].Name.Should().Be("Name 1");
            books[0].Author.Should().Be("Author 1");
            books[0].PublishYear.Should().Be(2021);
        }

        [Test]
        public void SearchBookByYearTest()
        {
            var books= _bookstoreBusiness.SearchBook(string.Empty, string.Empty, 2020);
            books.Should().HaveCount(2);
            books.TrueForAll(x => x.PublishYear == 2020);
        }

        [Test]
        public void SearchBookComplexTest()
        {
            var books= _bookstoreBusiness.SearchBook("Name 2", "Author 2", 2020);

            books.Should().ContainSingle();
            books[0].Name.Should().Be("Name 2");
            books[0].Author.Should().Be("Author 2");
            books[0].PublishYear.Should().Be(2020);
        }
    }
}
