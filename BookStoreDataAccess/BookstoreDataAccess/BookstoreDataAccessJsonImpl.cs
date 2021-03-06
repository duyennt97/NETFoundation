using System.Collections.Generic;
using System.IO;
using BookStoreConsole.BookstoreDataAccess;
using Newtonsoft.Json;

namespace BookStoreDataAccess.BookstoreDataAccess
{
    public class BookstoreDataAccessJsonImpl : IBookstoreDataAccess
    {
        private string _filePath = $"{Directory.GetCurrentDirectory()}\\..\\..\\..\\BookStoreDataAccess\\Data\\BooksDataJson.json";

        public List<Book> GetAllBooks()
        {
            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Book>>(json);
        }

        public bool SaveBookList(List<Book> books)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, books);
               
            }
            return true;
        }

        public bool InsertBook(Book book)
        {
            var books = GetAllBooks();
            books.Add(book);
            return SaveBookList(books);
        }
    }
}
