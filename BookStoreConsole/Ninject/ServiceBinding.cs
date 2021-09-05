using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreConsole.BookstoreBusiness;
using BookStoreConsole.BookstoreDataAccess;
using Ninject.Modules;

namespace BookStoreConsole.Ninject
{
    public class ServiceBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookstoreBusiness>().To<BookstoreBusinessImpl>().Named("TEXT");
            Bind<IBookstoreBusiness>().To<BookstoreBusinessImpl>().Named("JSON");
            Bind<IBookstoreDataAccess>().To<BookstoreDataAccessImpl>().WhenAnyAnchestorNamed("TEXT");
            Bind<IBookstoreDataAccess>().To<BookstoreDataAccessJsonImpl>().WhenAnyAnchestorNamed("JSON");
        }
    }
}
