using System.Collections.Generic;
using System.IO;
using BookStoreDataAccess;
using Newtonsoft.Json;

namespace BookStoreConsole.BookstoreDataAccess
{
    public class BookstoreDataAccessJsonImpl : IBookstoreDataAccess
    {
        private string _filePath = $"{Directory.GetCurrentDirectory()}\\..\\..\\..\\BookStoreDataAccess\\Data\\BooksDataJson.json";

        public void SetDataFile(string filePath)
        {
            _filePath = filePath;
        }

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
