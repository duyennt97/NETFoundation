using System;
using System.Collections.Generic;
using System.IO;
using BookStoreConsole.Data;

namespace BookStoreConsole.BookstoreDataAccess
{
    public class BookstoreDataAccessImpl : IBookstoreDataAccess
    {
        private string _filePath = "C:\\Users\\DTH\\Documents\\NETFoundation\\BookStoreConsole\\Data\\BooksData.txt";

        public List<Book> GetAllBooks()
        {
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
                            PublishYear = Convert.ToInt32(bookInfo[2])
                        };
                        result.Add(book);
                    }
                }
            }

            return result;
        }

        public bool SaveBookList(List<Book> books)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"{book.Name};{book.Author};{book.PublishYear}");
                }
            }

            return true;
        }

        public bool InsertBook(Book book)
        {
            using (StreamWriter writer = File.AppendText(_filePath))
            {
                writer.Write($"\n{book.Name};{book.Author};{book.PublishYear}");
            }

            return true;
        }
    }
}
