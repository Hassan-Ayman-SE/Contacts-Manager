using System;
using System.Collections.Generic;
using Xunit;
using Contacts_Manager;
namespace Contacts_ManagerTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddContact_ShouldAddNewContact()
        {
            // Arrange
            // To ensure starting with a clean slate
            Program.RemoveAllContacts(); 
            string contactName = "John Doe";

            // Act
            var result = Program.AddContact(contactName);

            // Assert
            Assert.Contains(contactName, result);
        }

        [Fact]
        public void AddContact_ShouldThrowException_WhenAddingDuplicateContact()
        {
            // Arrange
            Program.RemoveAllContacts();
            string contactName = "Jane Doe";
            Program.AddContact(contactName);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Program.AddContact(contactName));
        }

        [Fact]
        public void RemoveContact_ShouldRemoveExistingContact()
        {
            // Arrange
            Program.RemoveAllContacts();
            string contactName = "John Smith";
            Program.AddContact(contactName);

            // Act
            var result = Program.RemoveContact(contactName);

            // Assert
            Assert.DoesNotContain(contactName, result);
        }

        [Fact]
        public void RemoveContact_ShouldThrowException_WhenContactDoesNotExist()
        {
            // Arrange
            Program.RemoveAllContacts();
            string contactName = "Nonexistent Contact";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Program.RemoveContact(contactName));
        }

        [Fact]
        public void ViewAllContacts_ShouldReturnAllContacts()
        {
            // Arrange
            Program.RemoveAllContacts();
            string contactName1 = "Alice";
            string contactName2 = "Bob";
            Program.AddContact(contactName1);
            Program.AddContact(contactName2);

            // Act
            var result = Program.ViewAllContacts();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(contactName1, result);
            Assert.Contains(contactName2, result);
        }
    }
}