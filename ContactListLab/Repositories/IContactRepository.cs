using ContactListLab.Model;
using ContactListLab.Presenter;

namespace ContactListLab.Repositories;

public interface IContactRepository
{
    Task<List<ContactDto>> ViewAllContacts();
    Task<List<ContactDto>> SearchContacts(int search, string searchString);
    Task AddContact(ContactDto contact);
}