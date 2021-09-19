using System;
using System.Windows.Forms;
using BookstoreBusiness.BookstoreBusiness;
using BookstoreBusiness.Ninject;
using BookStoreCommon;
using BookStoreConsole.Mapper;
using Ninject;

namespace BookStorePresentation
{
    class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IoC.Initialize(new StandardKernel(new NinjectSettings() {LoadExtensions =  true}),
                new ServiceBinding(),
                new BookAutoMapperModule());
            //var bookstoreBusiness = IoC.Get<IBookstoreBusiness>("TEXT");
            var bookstoreBusiness = IoC.Get<IBookstoreBusiness>("JSON");
            Application.Run(new BookStoreManagerForm(bookstoreBusiness));

        }
    }
}
