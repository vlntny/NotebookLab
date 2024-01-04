using ContactListLab.Presenter;
using ReactiveUI;

namespace ContactListLab.Model;

public class ContactDto : ReactiveObject
{
    public ulong id { get; set; }
    public string _name;
    public string _surname;
    public string _phoneNumber;
    public string _email;
    
    public string name
    {
        get { return _name; }
        set
        {
            this.RaiseAndSetIfChanged(ref _name, value);
        }
    }
    
    public string surname
    {
        get { return _surname; }
        set
        {
            this.RaiseAndSetIfChanged(ref _surname, value);
        }
    }
    
    public string phoneNumber
    {
        get { return _phoneNumber; }
        set
        {
            this.RaiseAndSetIfChanged(ref _phoneNumber, value);
        }
    }
    
    public string email
    {
        get { return _email; }
        set
        {
            this.RaiseAndSetIfChanged(ref _email, value);
        }
    }


    public ContactDto(Contact t)
    {
        name = t.Name;
        surname = t.Surname;
        phoneNumber = t.PhoneNumber;
        email = t.Email;
    }
    
    public ContactDto(){}
}