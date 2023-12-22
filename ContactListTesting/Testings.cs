using ContactListLab.Model;
using ContactListLab.Presenter;
using Moq;
using NUnit.Framework;
namespace ContactListTesting;

// юнит тесты
public class Tests
{
    [Test]
    public void AddContact_ShouldAddtoList()
    {
        var moq = new Mock<IMyDatabase>();
        moq.Setup(r => r.LoadContacts()).Returns(new List<Contact>());

        var contactList = new ContactList(moq.Object);
        
        contactList.AddContact("test", "test2", "test3", "test4");
        var contactfromlist = contactList.GetContacts().First();
        
        Assert.AreEqual("test", contactfromlist.Name);
        Assert.AreEqual("test2", contactfromlist.Surname);
        Assert.AreEqual("test3", contactfromlist.PhoneNumber);
        Assert.AreEqual("test4", contactfromlist.Email);
    }

    [Test]
    public void AddContact_DbHasThis()
    {
        var moq = new Mock<IMyDatabase>();
        moq.Setup(r => r.LoadContacts()).Returns(new List<Contact>());
        var contactList = new ContactList(moq.Object);

        Assert.IsEmpty(moq.Object.LoadContacts());

        contactList.AddContact("test", "test2", "test3", "test4");

        Assert.IsNotEmpty(moq.Object.LoadContacts());

    }
}