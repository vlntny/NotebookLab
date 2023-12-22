using ContactListLab.Presenter;

namespace ContactListLab.Model;

public interface IMyDatabase
{
    List<Contact> LoadContacts();
    void SaveContacts(ContactList contacts);
    
}