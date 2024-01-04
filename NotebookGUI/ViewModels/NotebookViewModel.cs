using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using ContactListLab.AppContext;
using ContactListLab.Model;
using DynamicData;
using ReactiveUI;

namespace NotebookGUI.ViewModels;

public class NotebookViewModel : ViewModelBase
{
    private string _name = "Valya";
    private string _surname = "Bolotova";
    private string _phone = "112";
    private string _email = "@gmail.com";
    
    private MyContext _context;
    private MyDatabase _database;

    public ObservableCollection<ContactDto> ContactList { get; set; } = new ObservableCollection<ContactDto>();
    
    public bool _IsEditMode;
    public bool IsEditMode
    {
        get { return _IsEditMode; }
        set
        {
            this.RaiseAndSetIfChanged(ref _IsEditMode, value);
        }
    }
    
    private ContactDto _selectedContact;
    public ContactDto SelectedContact
    {
        get => _selectedContact;
        set
        { 
            this.RaiseAndSetIfChanged(ref _selectedContact, value);
            
            if (_selectedContact != null)
            {
                Name = _selectedContact.name;
                Surname = _selectedContact.surname;
                PhoneNumber = _selectedContact.phoneNumber;
                Email = _selectedContact.email;
            }
        } 
    }
    
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Surname
    {
        get => _surname;
        set => this.RaiseAndSetIfChanged(ref _surname, value);
    }
    
    public string PhoneNumber
    {
        get => _phone;
        set => this.RaiseAndSetIfChanged(ref _phone, value);
    }
    
    public string Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }

    public NotebookViewModel()
    {
        _context = new MyContext();
        _database = new MyDatabase(_context);
        var contacts = _context.Contacts.ToList();
        ContactList.AddRange(contacts);
    }

    public void EnableEditing()
    {
        IsEditMode = true;
        SelectedContact = null;
        Name = "";
        Surname = "";
        PhoneNumber = "";
        Email = "";
    }

    public void SaveNewContact()
    {
        var contact = new ContactDto
        {
            name = Name,
            surname = Surname,
            phoneNumber = PhoneNumber,
            email = Email,
            id = (ulong) (ContactList.Count() + 1)
        };
        
        ContactList.Add(contact);
        
        IsEditMode = false;
        _database.SaveContacts(ContactList);
    }
    
}