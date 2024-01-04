using System.Linq;
using ContactListLab.AppContext;
using ContactListLab.Model;
using ContactListLab.Presenter;
using Microsoft.EntityFrameworkCore;

namespace ContactListLab.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly MyContext _context;

    public ContactRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<List<ContactDto>> ViewAllContacts()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<List<ContactDto>> SearchContacts(int search, string searchString)
    {
        switch (search)
        {
            case 1:
                return await SearchByName(searchString);
            case 2:
                return await SearchBySurname(searchString);
            case 3:
                return await SearchByNameAndSurname(searchString);
            case 4:
                return await SearchByPhone(searchString);
            case 5:
                return await SearchByEmail(searchString);
            default:
                throw new InvalidOperationException("Invalid search type.");
        }
    }

    private async Task<List<ContactDto>> SearchByName(string searchString)
    {
        return await _context.Contacts
            .Where(contact => contact.name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    private async Task<List<ContactDto>> SearchBySurname(string searchString)
    {
        return await _context.Contacts
            .Where(contact => contact.surname.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    private async Task<List<ContactDto>> SearchByNameAndSurname(string searchString)
    {
        string[] searchStrings = searchString.Split(' ');
        return await _context.Contacts
            .Where(contact => contact.name.Contains(searchStrings[0], StringComparison.OrdinalIgnoreCase) &&
                              contact.surname.Contains(searchStrings[1], StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    private async Task<List<ContactDto>> SearchByPhone(string searchString)
    {
        return await _context.Contacts
            .Where(contact => contact.phoneNumber.Contains(searchString))
            .ToListAsync();
    }

    private async Task<List<ContactDto>> SearchByEmail(string searchString)
    {
        return await _context.Contacts
            .Where(contact => contact.email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }
    
    public async Task AddContact(ContactDto contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
    }
}
