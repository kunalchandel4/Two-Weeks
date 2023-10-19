using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        using (var dbContext = new LibraryDbContext())
        {
            var libraryManager = new LibraryManager(dbContext);

            while (true)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Add Patron");
                Console.WriteLine("6. View All Patrons");
                Console.WriteLine("7. Update Patron");
                Console.WriteLine("8. Delete Patron");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            // Add Book
                            var newBook = ReadBookDetails();
                            if (newBook != null)
                            {
                                libraryManager.AddBook(newBook);
                                Console.WriteLine("Book added successfully.");
                            }
                            break;

                        case 2:
                            // View All Books
                            var books = libraryManager.GetAllBooks();
                            Console.WriteLine("List of Books:");
                            foreach (var book in books)
                            {
                                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                            }
                            break;

                        case 3:
                            // Update Book
                            Console.Write("Enter the ID of the book to update: ");
                            if (int.TryParse(Console.ReadLine(), out int bookId))
                            {
                                var existingBook = libraryManager.GetBookById(bookId);
                                if (existingBook != null)
                                {
                                    var updatedBook = ReadBookDetails();
                                    if (updatedBook != null)
                                    {
                                        updatedBook.Id = bookId;
                                        libraryManager.UpdateBook(updatedBook);
                                        Console.WriteLine("Book updated successfully.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Book not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            break;

                        case 4:
                            // Delete Book
                            Console.Write("Enter the ID of the book to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int bookIdToDelete))
                            {
                                var bookToDelete = libraryManager.GetBookById(bookIdToDelete);
                                if (bookToDelete != null)
                                {
                                    libraryManager.DeleteBook(bookIdToDelete);
                                    Console.WriteLine("Book deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Book not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            break;

                        case 5:
                            // Add Patron
                            var newPatron = ReadPatronDetails();
                            if (newPatron != null)
                            {
                                libraryManager.AddPatron(newPatron);
                                Console.WriteLine("Patron added successfully.");
                            }
                            break;

                        case 6:
                            // View All Patrons
                            var patrons = libraryManager.GetAllPatrons();
                            Console.WriteLine("List of Patrons:");
                            foreach (var patron in patrons)
                            {
                                Console.WriteLine($"ID: {patron.Id}, Name: {patron.Name}, Contact: {patron.ContactInformation}");
                            }
                            break;

                        case 7:
                            // Update Patron
                            Console.Write("Enter the ID of the patron to update: ");
                            if (int.TryParse(Console.ReadLine(), out int patronId))
                            {
                                var existingPatron = libraryManager.GetPatronById(patronId);
                                if (existingPatron != null)
                                {
                                    var updatedPatron = ReadPatronDetails();
                                    if (updatedPatron != null)
                                    {
                                        updatedPatron.Id = patronId;
                                        libraryManager.UpdatePatron(updatedPatron);
                                        Console.WriteLine("Patron updated successfully.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Patron not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            break;

                        case 8:
                            // Delete Patron
                            Console.Write("Enter the ID of the patron to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int patronIdToDelete))
                            {
                                var patronToDelete = libraryManager.GetPatronById(patronIdToDelete);
                                if (patronToDelete != null)
                                {
                                    libraryManager.DeletePatron(patronIdToDelete);
                                    Console.WriteLine("Patron deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Patron not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            break;

                        case 9:
                            // Exit
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }
    }

    private static Book ReadBookDetails()
    {
        Console.Write("Title: ");
        var title = Console.ReadLine();

        Console.Write("Author: ");
        var author = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Title and author are required fields. Book not added.");
            return null;
        }

        Console.Write("Publication Date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime publicationDate))
        {
            return new Book
            {
                Title = title,
                Author = author,
                PublicationDate = publicationDate
            };
        }
        else
        {
            Console.WriteLine("Invalid date format. Book not added.");
            return null;
        }
    }

    private static Patron ReadPatronDetails()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();

        Console.Write("Contact Information: ");
        var contactInformation = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(contactInformation))
        {
            Console.WriteLine("Name and contact information are required fields. Patron not added.");
            return null;
        }

        return new Patron
        {
            Name = name,
            ContactInformation = contactInformation
        };
    }
}
