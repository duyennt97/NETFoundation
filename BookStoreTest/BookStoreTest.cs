using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreBusiness.BookstoreBusiness;
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

        [SetUp]
        public void InitTest()
        {
            var testKernel = new StandardKernel();
            testKernel.Bind<IBookstoreBusiness>().To<BookstoreBusinessImpl>();
            _mockBookstoreDataAccess = GetMockBookstoreDa(_listTestBooks);
            testKernel.Bind<IBookstoreDataAccess>().ToConstant(_mockBookstoreDataAccess);
            _bookstoreBusiness = testKernel.Get<IBookstoreBusiness>();

        }

        private readonly List<Book> _listTestBooks = new List<Book>()
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
      

        private IBookstoreDataAccess GetMockBookstoreDa(List<Book> listTestBook)
        {
            var listBook = new List<Book>(listTestBook);
            var bookstoreDa = Substitute.For<IBookstoreDataAccess>();

            bookstoreDa.GetAllBooks().Returns(listBook);

            bookstoreDa.InsertBook(Arg.Do<Book>(x => listBook.Add(x)))
                .Returns(true);

            bookstoreDa.SaveBookList(Arg.Do<List<Book>>(x => listBook = x))
                .Returns(true);

            return bookstoreDa;
        }

        [Test]
        public void Test_GetAllBook_Success()
        {
            var allBook = _bookstoreBusiness.GetAllBooks();
            allBook.ShouldBeEquivalentTo(_listTestBooks);
        }

        [Test]
        public void Test_InsertBook_Success()
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
            listBookAfterInsert.Should().HaveCount(listBook.Count + 1);
        }

        [Test]
        public void Test_UpdateBook_Success()
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
        public void Test_UpdateBook_ThrowException()
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
        public void Test_DeleteBook_Success()
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
        public void Test_DeleteBook_ThrowException()
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
        public void Test_SearchBook_ByName_Success()
        {
            var books= _bookstoreBusiness.SearchBook("Name 1", string.Empty, null);
            books.Should().ContainSingle();
            books[0].Name.Should().Be("Name 1");
            books[0].Author.Should().Be("Author 1");
            books[0].PublishYear.Should().Be(2021);
        }

        [Test]
        public void Test_SearchBook_ByYear_Success()
        {
            var books= _bookstoreBusiness.SearchBook(string.Empty, string.Empty, 2020);
            books.Should().HaveCount(2);
            books.TrueForAll(x => x.PublishYear == 2020);
        }

        [Test]
        public void Test_SearchBook_Complex_Success()
        {
            var books= _bookstoreBusiness.SearchBook("Name 2", "Author 2", 2020);

            books.Should().ContainSingle();
            books[0].Name.Should().Be("Name 2");
            books[0].Author.Should().Be("Author 2");
            books[0].PublishYear.Should().Be(2020);
        }
    }
}
