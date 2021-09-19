using System;
using System.Collections.Generic;
using System.IO;
using BookStoreCommon;
using BookStoreConsole.BookstoreDataAccess;

namespace BookStoreDataAccess.BookstoreDataAccess
{
    public class BookstoreDataAccessImpl : IBookstoreDataAccess
    {
        private string _filePath = $"{Directory.GetCurrentDirectory()}\\..\\..\\..\\BookStoreDataAccess\\Data\\BooksData.txt";

        public void SetDataFile(string filePath)
        {
            _filePath = filePath;
        }

        public List<Book> GetAllBooks()
        {
            LogService.LogCurrentMethod();
            var result = new List<Book>();
            using (var reader = new StreamReader(_filePath))
            {
                string bookLine;
                while ((bookLine = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(bookLine))
                    {
                        var bookInfo = bookLine.Split(';');
                        var book = new Book()
                        {
                            Id = result.Count + 1,
                            Name = bookInfo[0],
                            Author = bookInfo[1],
                            PublishYear = bookInfo[2],
                            Price = bookInfo[3]
                        };
                        result.Add(book);
                    }
                }
            }

            return result;
        }

        public bool SaveBookList(List<Book> books)
        {
            LogService.LogCurrentMethod();
            using (var writer = new StreamWriter(_filePath))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"{book.Name};{book.Author};{book.PublishYear};{book.Price}");
                }
            }

            return true;
        }

        public bool InsertBook(Book book)
        {
            LogService.LogCurrentMethod();
            using (StreamWriter writer = File.AppendText(_filePath))
            {
                writer.Write($"\r\n{book.Name};{book.Author};{book.PublishYear};{book.Price}");
            }

            return true;
        }
    }
}
