using System;
using BookstoreBusiness.BookstoreBusiness;
using BookStoreConsole.Data;

namespace BookstoreConsoleView.ConsoleView
{
    class BookstoreConsole
    {
        private IBookstoreBusiness _bookstoreBusiness;

        public BookstoreConsole(IBookstoreBusiness business)
        {
            _bookstoreBusiness = business;
        }

        private void ShowOptions()
        {
            Console.WriteLine("Welcome to Bookstore!");
            Console.WriteLine("Please choose action:");
            Console.WriteLine("1/ Display all books");
            Console.WriteLine("2/ Insert a new book");
            Console.WriteLine("3/ Update a book");
            Console.WriteLine("4/ Delete a book");
            Console.WriteLine("----");
            Console.WriteLine("0/ Exit");
            Console.WriteLine("Enter action number:");
        }

        public void Process(int option)
        {
            Console.WriteLine("\n----------------------\n\n");

            switch (option)
            {
                case 0:
                    Console.WriteLine("Bye!");
                    break;
                case 1: 
                    DisplayAllBooks();
                    break;
                case 2: 
                    InsertBook();
                    break;
                case 3: 
                    UpdateBook();
                    break;
                case 4: 
                    DeleteBook();
                    break;
                default:
                    Console.WriteLine("Option is not available!");
                    break;
            }
        }

        private void DeleteBook()
        {
            DisplayAllBooks();
            Console.WriteLine("Enter book's ID to delete:");
            var id = Convert.ToInt32(Console.ReadLine());
            var result = _bookstoreBusiness.DeleteBook(id);
            if (result)
            {
                Console.WriteLine("Book is deleted");
            }
        }

        private void UpdateBook()
        {
            DisplayAllBooks();
            Console.WriteLine("Enter book's ID to update:");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter book's name:");
            var name = Console.ReadLine(); 
            Console.WriteLine("Enter book's author:");
            var author = Console.ReadLine();
            Console.WriteLine("Enter book's publish year:");
            var year = Convert.ToInt32(Console.ReadLine());

            var result = _bookstoreBusiness.UpdateBook(new Book()
            {
                Id = id,
                Name = name,
                Author = author,
                PublishYear = year
            });

            if (result)
            {
                Console.WriteLine("Book is updated.");
            }
        }

        private void InsertBook()
        {
           Console.WriteLine("Enter book's name:");
           var name = Console.ReadLine(); 
           Console.WriteLine("Enter book's author:");
           var author = Console.ReadLine();
           Console.WriteLine("Enter book's publish year:");
           var year = Convert.ToInt32(Console.ReadLine());

           var result = _bookstoreBusiness.InsertBook(new Book()
           {
               Name = name,
               Author = author,
               PublishYear = year
           });
           if (result)
           {
               Console.WriteLine("Book is inserted.");
           }
        }

        private void DisplayAllBooks()
        {
            Console.WriteLine("All Books:\n");

            var books = _bookstoreBusiness.GetAllBooks();
            
            foreach (var b in books)
            {
                Console.WriteLine($"Book {b.Id}:\n\tName: {b.Name}\n\tAuthor: {b.Author}\n\tYear:{b.PublishYear}\n");
            }
        }

        public void RunConsole()
        {
            int option;
            do
            {
                Console.Clear();
                ShowOptions();
                option = Convert.ToInt32(Console.ReadLine());
                Process(option);
                Console.ReadLine();
            } while (option > 0);
        }
    }
}
