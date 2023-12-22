using ContactListLab.AppContext;
using ContactListLab.Presenter;

namespace ContactListLab.Model;

public class MyDatabase : IMyDatabase
{
    private readonly MyContext _context;

    public MyDatabase(MyContext context)
    {
        _context = context;
    }

    public List<Contact> LoadContacts()
    {
        var contacts = _context.Contacts.ToList();

        var groupedContacts = contacts
            .Select(contactDto => new Contact(contactDto.name, contactDto.surname, contactDto.phoneNumber, contactDto.email))
            .GroupBy(c => c.Name)
            .Select(group => group.First()) 
            .ToList();

        return groupedContacts;
    }


    public void SaveContacts(ContactList contacts)
    {
        _context.Contacts.RemoveRange(_context.Contacts);
        _context.SaveChanges();

        var _tasks = contacts.GetContacts();
        
        var localTasks = _tasks.Select(x => ConvertToDTO(x)).ToList();
        _context.Contacts.AddRange(localTasks);
    }
    
    private ContactDto ConvertToDTO(Contact t)
    {
        var res = new ContactDto();
        res.name = t.Name;
        res.surname = t.Surname;
        res.phoneNumber = t.PhoneNumber;
        res.email = t.Email;
            
        return res;
    }
}