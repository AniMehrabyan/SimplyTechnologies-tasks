using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        internal class Book
        {
            internal string FindBook()
            {
                return "Find a book for  borrowing";
            }
            internal string Returned()
            {
                return "The book is returned";
            }
        }
        internal class Person
        {
            internal string Return()
            {
                return "Person returns a book. ";
            }
            internal string Borrow()
            {
                return "Person borrows a book. ";
            }
        }
        public static class Facade
        {
            static Book book = new Book();
            static Person person = new Person();
            public static void ReturnBook()
            {
                Console.WriteLine(person.Return());
                Console.WriteLine(book.Returned());
            }

            public static void BorrowBook()
            {
                Console.WriteLine(book.FindBook());
                Console.WriteLine(person.Borrow());
            }
        }
        static void Main()
        {
            Facade.BorrowBook();
            Facade.ReturnBook();
        }
    }
}
