using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookStoreCommon;
using BookStoreConsole.BookstoreBusiness;
using BookStoreConsole.ConsoleView;
using BookStoreConsole.Ninject;
using Ninject;

namespace BookstoreConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.Initialize(new StandardKernel(new NinjectSettings() {LoadExtensions =  true}),
                new ServiceBinding());
            var bookstoreBusiness = IoC.Get<IBookstoreBusiness>("TEXT");
            BookstoreConsole consoleView = new BookstoreConsole(bookstoreBusiness);
            consoleView.RunConsole();
        }
    }
}
