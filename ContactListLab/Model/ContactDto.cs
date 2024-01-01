using ContactListLab.Presenter;

namespace ContactListLab.Model;

public class ContactDto
{
    public ulong id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set;  }

    public ContactDto(Contact t)
    {
        name = t.Name;
        surname = t.Surname;
        phoneNumber = t.PhoneNumber;
        email = t.Email;
    }
}