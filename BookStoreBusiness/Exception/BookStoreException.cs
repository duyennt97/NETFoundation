using System;

namespace BookStoreConsole.Exception
{
    public class BookNotFoundException : System.Exception
    {
        public BookNotFoundException(String message)
            : base(message) {
        }
    }
}
