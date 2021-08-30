using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreConsole.ConsoleView;

namespace BookStoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BookstoreConsole consoleView = new BookstoreConsole();
            consoleView.RunConsole();
        }
    }
}
