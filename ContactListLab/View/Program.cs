using ContactListLab.Presenter;

// консольное взаимодействие (записная книжка)
class Program
{
    static void Main()
    {
        ContactList contactList = new ContactList();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. View all contacts");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. New contact");
            Console.WriteLine("4. Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    contactList.ViewAllContacts();
                    break;
                case "2":
                    SearchMenu(contactList);
                    break;
                case "3":
                    AddContactMenu(contactList);
                    break;
                case "4":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void SearchMenu(ContactList contactList)
    {
        Console.WriteLine("\nSearch by");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Surname");
        Console.WriteLine("3. Name and Surname");
        Console.WriteLine("4. Phone");
        Console.WriteLine("5. E-mail");

        Console.Write("> ");
        string searchChoice = Console.ReadLine();

        if (int.TryParse(searchChoice, out int searchNumber) && searchNumber >= 1 && searchNumber <= 5)
        {
            Console.WriteLine("Enter the search string:");
            Console.Write("> ");
            string searchString = Console.ReadLine();

            List<Contact> searchResults = contactList.SearchContacts(searchNumber, searchString);

            if (searchResults != null && searchResults.Count > 0)
            {
                Console.WriteLine("Results ({0}):", searchResults.Count);
                foreach (var contact in searchResults)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Try again.");
        }
    }


    static void AddContactMenu(ContactList contactList)
    {
        Console.WriteLine("\nNew contact");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Surname: ");
        string surname = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("E-mail: ");
        string email = Console.ReadLine();

        contactList.AddContact(name, surname, phone, email);
    }
}
