using SchoolAdmin.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin.Facilities
{
    class BookQueries
    {
        // STEP 1 - Establish the datasource, a list of Book objects
        public IEnumerable<Book> books = new List<Book>()
        {
            new Book() { Title = "Things Fall Apart", Author = "Chinua Achebe"},
            new Book() { Title = "The Pilgrim’s Progress", Author = "John Bunyan"},
            new Book() { Title =  "Robinson Crusoe ", Author = "Daniel Defoe"},
            new Book() { Title = "Gulliver’s Travels ", Author = "Jonathan Swift"},
            new Book() { Title = " Clarissa", Author = " Samuel Richardson" },
            new Book() { Title = "Tom Jones ", Author = "Henry Fielding"},
            new Book() { Title = " No longer at ease ", Author = "Chinua Achebe"},
            new Book() { Title = "The Education", Author = "Chinua Achebe" },
            new Book() { Title = "The trial of Brother Jero", Author = "Wole Soyinka"},
            new Book() { Title = "The interpreters", Author = "Wole Soyinka"},
        };

        // 1.Ability to fetch all books in the library, sorted by title in ascending order.
        // STEP 1 - Write a bunch of queries using expression syntax
        public void GetBooksSortedByTitle1()
        {
            IEnumerable<Book> titleSortQuery = from book in books
                                               orderby book.Title 
                                               select book;

            Console.WriteLine("List of books, sorted by title in ascending order [EXPRESSION SYNTAX]");
            Console.WriteLine("Title");

            foreach (Book objBook in titleSortQuery)
            {
                Console.WriteLine($"{objBook.Title}");
            }

        }

        // STEP 2 - Repeat the above the queries using method syntax
        //1.Ability to fetch all books in the library, sorted by title in ascending order.
        public void GetBooksSortedByTitle2()
        {
            IEnumerable<Book> titleSortQuery = books.OrderBy(b => b.Title);
            Console.WriteLine("\n\n List of books, sorted by title in ascending order [METHOD SYNTAX]");
            Console.WriteLine("Title");

            foreach (Book objBook in titleSortQuery)
            {
                Console.WriteLine($"{objBook.Title}");
            }

        }

        // STEP 1 - Write a bunch of queries using expression syntax
        // 2.Ability to fetch all books in the library, sorted by title in ascending order, followed by author in descending order.
        public void GetBooksSortedByTitleAuthor1()
        {
            IEnumerable<Book> titleAuthorSortQuery = from book in books
                                                     orderby book.Title 
                                                     orderby book.Author descending
                                                     select book;

            Console.WriteLine("List of books, sorted by title in ascending, followed by author  in descending order [EXPRESSION SYNTAX]");
            Console.WriteLine("Title \t\t Author");

            foreach (Book objBook in titleAuthorSortQuery)
            {
                Console.WriteLine($"{objBook.Title}\t {objBook.Author}");
            }

        }
        // STEP 2 - Repeat the above the queries using method syntax
        public void GetBooksSortedByTitleAuthor2()
        {
            IEnumerable<Book> titleAuthorSortQuery = books.OrderBy(b => b.Title);
            books.OrderByDescending(b => b.Author);
            Console.WriteLine("\n\n List of books, sorted by title in ascending order [METHOD SYNTAX]");
            Console.WriteLine("Title");

            foreach (Book objBook in titleAuthorSortQuery)
            {
                Console.WriteLine($"{objBook.Title}\t {objBook.Author}");
            }

        }

        // STEP 1 - Write a bunch of queries using expression syntax
        // 3.Ability to fetch all books written by a specific author

        public void GetBooksWrittenByAuthor1()
        {
            IEnumerable<Book> WrittenByAuthorQuery = (IEnumerable<Book>)(from book in books
                                                                         where book.Author == "Chinua Achebe"
                                                                         select books);

            Console.WriteLine("\n\n List of books written by Chinua Achebe [EXPRESSION SYNTAX]");
            Console.WriteLine("Author");

            foreach (Book objBook in WrittenByAuthorQuery)
            {
                Console.WriteLine($"{objBook.Author}");
            }
        }
            // STEP 2 - Repeat the above the queries using method syntax
            // 3.Ability to fetch all books written by a specific author

          public void GetBooksWrittenByAuthor2()
            {
                IEnumerable<Book> Query = books
                    .Where(b => b.Author == "Chinua Achebe");

                Console.WriteLine("\n\n List of books written by Chinua Achebe [METHOD SYNTAX]");
                Console.WriteLine("Author");

                foreach (Book objBook in Query)
                {
                    Console.WriteLine($"{objBook.Author}");
                }

            }

        // STEP 1 - Write a bunch of queries using expression syntax
        //4.Ability to fetch the title and author of any book whose title or author name contains a given string value. The return values should be in uppercase.

        public void GetBooksByTitleAuthorStrToUpper1()
        {
            IEnumerable<Book> titleAuthorStrToUpperQuery = (from book in books
                                                           where book.Author == "Chinua Achebe" || book.Title == "Things Fall Apart"
                                                           select book);

            Console.WriteLine("books, whose title or author name contains a given string value[EXPRESSION SYNTAX]");
            Console.WriteLine("Title \t\t Author");

            foreach (Book objBook in titleAuthorStrToUpperQuery)
            {
                Console.WriteLine($"{objBook.Title.ToUpper()}\t {objBook.Author.ToUpper()}");
            }

        }


        // STEP 2 - Repeat the above the queries using method syntax
        //4.Ability to fetch the title and author of any book whose title or author name contains a given string value. The return values should be in uppercase.
       
        public void GetBooksByTitleAuthorStrToUpper2()
        {
            IEnumerable<Book> Query = books
                    .Where(b => b.Title == "Things fall Apart");

            Console.WriteLine("books, whose title or author name contains a given string value[EXPRESSION SYNTAX]");
            Console.WriteLine("Title \t\t Author");

            foreach (Book objBook in Query)
            {
                Console.WriteLine($"{objBook.Title.ToUpper()}\t {objBook.Author.ToUpper()} ");
            }


        }

        public void BookCountExpression1() 
        {
            IEnumerable<IGrouping<string, Book>> numberOfBooksWrittenQuery = from book in books
                                                                        group book by book.Author;

            Console.WriteLine("\n\nNumber of books written by author.[Expression Method]");
            Console.WriteLine("BookCount");

            foreach (var objGroup in numberOfBooksWrittenQuery)
            {
                Console.WriteLine($"{objGroup.Key} :{objGroup.Count()}");
            }


        }
    }

}


