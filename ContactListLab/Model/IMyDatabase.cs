using ContactListLab.Presenter;

namespace ContactListLab.Model;

public interface IMyDatabase
{
    Task<List<Contact>> LoadContacts();
    void SaveContacts(ContactList contacts);
    
}