using System.Collections.Generic;
using BookstoreBusiness.BookstoreBusiness;
using BookStoreConsole.BookstoreDataAccess;
using BookStoreDataAccess;
using Ninject.Modules;
using NSubstitute;

namespace BookstoreTest.Ninject
{
    public class TestServiceBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookstoreBusiness>().To<BookstoreBusinessImpl>();
            var mockBookstoreDataAccess = GetMockBookstoreDa(_listTestBooks);
            Bind<IBookstoreDataAccess>().ToConstant(mockBookstoreDataAccess);
        }

        private List<Book> _listTestBooks = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Author = "Author 1",
                Name = "Name 1",
                PublishYear = "2021",
                Price = "80"
            },
            new Book()
            {
                Id = 2,
                Author = "Author 2",
                Name = "Name 2",
                PublishYear = "2020",
                Price = "1800"
            },
            new Book()
            {
                Id = 3,
                Author = "Author 3",
                Name = "Name 3",
                PublishYear = "2020",
                Price = "800"
            }
        };
      

        private IBookstoreDataAccess GetMockBookstoreDa(List<Book> listTestBook)
        {
            var listBook = new List<Book>(listTestBook);
            var bookstoreDa = Substitute.For<IBookstoreDataAccess>();

            bookstoreDa.GetAllBooks().Returns(listBook);

            bookstoreDa.InsertBook(Arg.Do<Book>(x => listBook.Add(x)))
                .Returns(true);

            bookstoreDa.SaveBookList(Arg.Do<List<Book>>(x =>
                {
                    listBook.Clear();
                    listBook.AddRange(x);
                }))
                .Returns(true);

            return bookstoreDa;
        }
    }
}
