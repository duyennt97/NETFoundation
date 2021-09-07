using System;
using System.Windows.Forms;
using BookstoreBusiness.BookstoreBusiness;
using BookstoreBusiness.Ninject;
using BookStoreCommon;
using Ninject;

namespace BookStorePresentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [Obsolete]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IoC.Initialize(new StandardKernel(new NinjectSettings() {LoadExtensions =  true}),
                new ServiceBinding());
            var bookstoreBusiness = IoC.Get<IBookstoreBusiness>("TEXT");
            //var bookstoreBusiness = IoC.Get<IBookstoreBusiness>("JSON");
            Application.Run(new BookStoreManagerForm(bookstoreBusiness));
        }
    }
}
