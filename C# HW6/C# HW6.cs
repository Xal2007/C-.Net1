ReadingList ReadingList = new ReadingList();

ReadingList.add_book(new Book("Eugene Onegin", "Pushkin.A"));
ReadingList.add_book(new Book("War and Peace", "Tolstoy L."));
 
Console.WriteLine("Reading List:");
Console.Write("\n");
ReadingList.print_listofbooks();

 
Book book_to_find = new Book("Eugene Onegin", "Pushkin.A");
Console.WriteLine(" ");
if (ReadingList.ContainsBook(book_to_find))
{
    Console.WriteLine($"'{book_to_find}' is in the list");
}
else 
{
    Console.WriteLine($"'{book_to_find}' is not in the list");
}
 
ReadingList.remove_book(book_to_find);
Console.WriteLine("\nAfter removing 'Eugene Onegin':");
Console.Write("\n");
ReadingList.print_listofbooks();
 
Console.WriteLine($"\nBook at index 0: {ReadingList[0]}");
 
ReadingList += new Book("Collected Tales", "Gogol N.");
Console.WriteLine("\nAfter adding 'Collected Tales':");
Console.Write("\n");
ReadingList.print_listofbooks();

ReadingList -= new Book("Collected Tales", "Gogol N.");
Console.WriteLine("\nAfter removing 'Collected Tales':");
Console.Write("\n");
ReadingList.print_listofbooks();

class Book
{
    public string Name { get; set; }
    public string Author { get; set; }

    public Book(string name, string author)
    {
        Name = name;
        Author = author;
    }

    public override string ToString()
    {
        return $"{Name} by {Author}";
    }
}

class ReadingList
{
    private List<Book> books = new List<Book>();

    public void add_book(Book book)
    {
        books.Add(book);
    }

    public bool remove_book(Book book)
    {
        return books.Remove(book);
    }

    public bool ContainsBook(Book book)
    {
        return books.Contains(book);
    }

    public void print_listofbooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public Book this[int index]
    {
        get { return books[index]; }
        set { books[index] = value; }
    }

    public static ReadingList operator +(ReadingList list, Book book)
    {
        list.add_book(book);
        return list;
    }

    public static ReadingList operator -(ReadingList list, Book book)
    {
        list.remove_book(book);
        return list;
    }
}

