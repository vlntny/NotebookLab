namespace ContactListLab.Presenter;

// интерфейс записной книжки
public interface IContactList
{
    void ViewAllContacts();
    List<Contact> SearchContacts(int search, string searchString);
    void AddContact(string name, string surname, string phoneNumber, string email);
    List<Contact> GetContacts();
}