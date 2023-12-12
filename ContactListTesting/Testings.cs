using ContactListLab.Presenter;
using NUnit.Framework;
namespace ContactListTesting;

// юнит тесты
public class Tests
{
    [Test]
        public void AddContact_ContactDoesNotExist_ContactAddedSuccessfully()
        {
            // Arrange
            ContactList contactList = new ContactList();
            string name = "John";
            string surname = "Doe";
            string phone = "+123456789";
            string email = "john.doe@example.com";

            // Act
            contactList.AddContact(name, surname, phone, email);

            // Assert
            Assert.AreEqual(1, contactList.GetContacts().Count);
        }

        [Test]
        public void AddContact_ContactAlreadyExists_ContactNotAdded()
        {
            // Arrange
            ContactList contactList = new ContactList();
            string name = "John";
            string surname = "Doe";
            string phone = "+123456789";
            string email = "john.doe@example.com";

            // Add the contact initially
            contactList.AddContact(name, surname, phone, email);

            // Act
            contactList.AddContact(name, surname, phone, email);

            // Assert
            Assert.AreEqual(1, contactList.GetContacts().Count);
        }

        [Test]
        public void SearchContacts_SearchByName_ContactFound()
        {
            // Arrange
            ContactList contactList = new ContactList();
            string name = "John";
            string surname = "Doe";
            string phone = "+123456789";
            string email = "john.doe@example.com";
            contactList.AddContact(name, surname, phone, email);

            // Act
            var result = contactList.SearchContacts(1, name);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(name, result[0].Name);
            Assert.AreEqual(surname, result[0].Surname);
        }

        [Test]
        public void SearchContacts_InvalidChoice_ReturnsNull()
        {
            // Arrange
            ContactList contactList = new ContactList();

            // Act
            var result = contactList.SearchContacts(10, "");

            // Assert
            Assert.IsNull(result);
        }

        
}