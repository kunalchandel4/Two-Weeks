using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class LibraryManager
{
	private readonly LibraryDbContext _dbContext;

	public LibraryManager(LibraryDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	// Create a new book record
	public void AddBook(Book book)
	{
		_dbContext.Books.Add(book);
		_dbContext.SaveChanges();
	}

	// Retrieve a book record by ID
	public Book GetBookById(int id)
	{
		return _dbContext.Books.FirstOrDefault(b => b.Id == id);
	}

	// Retrieve all books
	public IQueryable<Book> GetAllBooks()
	{
		return _dbContext.Books;
	}

	// Update book record
	public void UpdateBook(Book updatedBook)
	{
		var existingBook = _dbContext.Books.Find(updatedBook.Id);
		if (existingBook != null)
		{
			_dbContext.Entry(existingBook).CurrentValues.SetValues(updatedBook);
			_dbContext.SaveChanges();
		}
	}

	// Delete book record
	public void DeleteBook(int id)
	{
		var book = _dbContext.Books.Find(id);
		if (book != null)
		{
			_dbContext.Books.Remove(book);
			_dbContext.SaveChanges();
		}
	}

	// Create a new patron record
	public void AddPatron(Patron patron)
	{
		_dbContext.Patrons.Add(patron);
		_dbContext.SaveChanges();
	}

	// Retrieve a patron record by ID
	public Patron GetPatronById(int id)
	{
		return _dbContext.Patrons.FirstOrDefault(p => p.Id == id);
	}

	// Retrieve all patrons
	public IQueryable<Patron> GetAllPatrons()
	{
		return _dbContext.Patrons;
	}

	// Update patron record
	public void UpdatePatron(Patron updatedPatron)
	{
		var existingPatron = _dbContext.Patrons.Find(updatedPatron.Id);
		if (existingPatron != null)
		{
			_dbContext.Entry(existingPatron).CurrentValues.SetValues(updatedPatron);
			_dbContext.SaveChanges();
		}
	}

	// Delete patron record
	public void DeletePatron(int id)
	{
		var patron = _dbContext.Patrons.Find(id);
		if (patron != null)
		{
			_dbContext.Patrons.Remove(patron);
			_dbContext.SaveChanges();
		}
	}
}
