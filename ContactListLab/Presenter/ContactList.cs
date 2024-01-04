using ContactListLab.Model;

namespace ContactListLab.Presenter;

// список контактов 
public class ContactList : IContactList
{
    private List<Contact> contacts;

    public ContactList(IMyDatabase db)
    {
        //contacts = db.LoadContacts();
    }

    public List<Contact> GetContacts()
    {
        return contacts;
    }
    
    public void ViewAllContacts()
    {
        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found.");
            return;
        }
        Console.WriteLine("All contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public List<Contact> SearchContacts(int search, string searchString)
    {
        switch (search)
        {
            case 1:
                return SearchByName(searchString);
            case 2:
                return SearchBySurname(searchString);
            case 3:
                return SearchByNameAndSurname(searchString);
            case 4:
                return SearchByPhone(searchString);
            case 5:
                return SearchByEmail(searchString);
            default:
                Console.WriteLine("Invalid choice. Try again.");
                return null;
        }
    }

    private List<Contact> SearchByName(string searchString)
    {
        List<Contact> fcontacts = new List<Contact>();
        Console.WriteLine("Enter the name to search for:");

        foreach (var contact in contacts)
        {
            if (contact.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }
    
    private List<Contact> SearchBySurname(string searchString)
    {
        List<Contact> fcontacts = new List<Contact>();
        Console.WriteLine("Enter the surname to search for:");
        

        foreach (var contact in contacts)
        {
            if (contact.Surname.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }
    
    private List<Contact> SearchByNameAndSurname(string searchString)
    {
        List<Contact> fcontacts = new List<Contact>();
        Console.WriteLine("Enter the name and surname to search for (separated by a space):");
        string[] searchStrings = searchString.Split(' ');
        foreach (var contact in contacts)
        {
            if (contact.Name.Contains(searchStrings[0], StringComparison.OrdinalIgnoreCase) && contact.Surname.Contains(searchStrings[1], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }
    
    private List<Contact> SearchByPhone(string searchString)
    {
        List<Contact> fcontacts = new List<Contact>();
        Console.WriteLine("Enter the phone number to search for:");

        foreach (var contact in contacts)
        {
            if (contact.PhoneNumber.Contains(searchString))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }
    
    private List<Contact> SearchByEmail(string searchString)
    {
        List<Contact> fcontacts = new List<Contact>();
        Console.WriteLine("Enter the e-mail to search for:");

        foreach (var contact in contacts)
        {
            if (contact.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(contact);
                fcontacts.Add(contact);
            }
        }
        return fcontacts;
    }

    public void AddContact(string name, string surname, string phoneNumber, string email)
    {
        // Проверяем, есть ли уже контакт с такими же данными
        if (contacts.Any(c => c.Name == name && c.Surname == surname && c.PhoneNumber == phoneNumber && c.Email == email))
        {
            Console.WriteLine("Contact already exists.");
        }
        else
        {
            // Если контакт не найден, добавляем новый
            Contact newContact = new Contact(name, surname, phoneNumber, email);
            contacts.Add(newContact);
            Console.WriteLine("Contact created.");
        }
    }


    
}