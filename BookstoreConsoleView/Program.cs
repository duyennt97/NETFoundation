using BookstoreBusiness.BookstoreBusiness;
using BookstoreBusiness.Ninject;
using BookStoreCommon;
using BookstoreConsoleView.ConsoleView;
using Ninject;

namespace BookstoreConsoleView
{
    class Program
    {
        static void Main()
        {
            IoC.Initialize(new StandardKernel(new NinjectSettings() {LoadExtensions =  true}),
                new ServiceBinding());
            var bookstoreBusiness = IoC.Get<IBookstoreBusiness>("TEXT");
            BookstoreConsole consoleView = new BookstoreConsole(bookstoreBusiness);
            consoleView.RunConsole();
        }
    }
}
