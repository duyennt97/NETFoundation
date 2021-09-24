using BookstoreBusiness.BookstoreBusiness;
using BookstoreBusiness.Ninject;
using BookStoreCommon;
using BookStoreConsole.Mapper;
using BookstoreConsoleView.ConsoleView;
using Ninject;

namespace BookstoreConsoleView
{
    class Program
    {
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            IoC.Initialize(new StandardKernel(new NinjectSettings() {LoadExtensions =  true}),
                new ServiceBinding(),
                new BookAutoMapperModule());
            var bookstoreBusiness = IoC.Get<IBookstoreBusiness>("TEXT");

            BookstoreConsole consoleView = new BookstoreConsole(bookstoreBusiness);
            consoleView.RunConsole();
        }
    }
}
