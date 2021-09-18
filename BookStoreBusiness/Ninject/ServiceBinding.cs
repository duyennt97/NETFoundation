using BookstoreBusiness.BookstoreBusiness;
using BookStoreConsole.BookstoreDataAccess;
using Ninject.Modules;

namespace BookstoreBusiness.Ninject
{
    public class ServiceBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookstoreBusiness>().To<BookstoreBusinessImpl>().Named("TEXT");
            Bind<IBookstoreBusiness>().To<BookstoreBusinessImpl>().Named("JSON");
            Bind<IBookstoreDataAccess>().To<BookstoreDataAccessImpl>().WhenAnyAncestorNamed("TEXT");
            Bind<IBookstoreDataAccess>().To<BookstoreDataAccessJsonImpl>().WhenAnyAncestorNamed("JSON");
        }
    }
}
