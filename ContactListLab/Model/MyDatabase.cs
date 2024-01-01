using ContactListLab.AppContext;
using ContactListLab.Presenter;
using Microsoft.EntityFrameworkCore;

namespace ContactListLab.Model;

public class MyDatabase : IMyDatabase
{
    private readonly MyContext _context;

    public MyDatabase(MyContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> LoadContacts()
    {
        var contacts = await _context.Contacts.ToListAsync();

        var groupedContacts = contacts
            .Select(contactDto => new Contact(contactDto.name, contactDto.surname, contactDto.phoneNumber, contactDto.email))
            .GroupBy(c => c.Name)
            .Select(group => group.First()) 
            .ToList();

        return groupedContacts;
    }


    public async void SaveContacts(ContactList contacts)
    {
        _context.Contacts.RemoveRange(_context.Contacts);
        await _context.SaveChangesAsync();

        var _tasks = contacts.GetContacts();
        
        var localTasks = _tasks.Select(x => ConvertToDTO(x)).ToList();
        _context.Contacts.AddRangeAsync(localTasks);
        await _context.SaveChangesAsync();
    }
    
    private ContactDto ConvertToDTO(Contact t)
    {
        var res = new ContactDto(t);
        return res;
    }
}