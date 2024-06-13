using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts_Manager
{
    public class Program
    {
        public static List<string> contactsList = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ContactsManager();
        }


        public static void ContactsManager()
        {
            string choice = string.Empty;

            while (choice.ToUpper() != "E")
            {
                Console.WriteLine("Enter your choice: \nA: for AddContact  \nR: for RemoveContact  \nV: for ViewAllContacts \nE: for Exit");
                choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "A":
                        Console.WriteLine("Enter the contact name:");
                        string contactToAdd = Console.ReadLine();
                        try
                        {
                            AddContact(contactToAdd);
                            Console.WriteLine($"Contact '{contactToAdd}' added successfully.");
                            Console.WriteLine("Updated Contacts:");
                            ViewAllContacts();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "R":
                        Console.WriteLine("Enter the contact name to Remove:");
                        string contactToRemove = Console.ReadLine();
                        try
                        {
                            RemoveContact(contactToRemove);
                            Console.WriteLine($"Contact '{contactToRemove}' removed successfully.");
                            Console.WriteLine("Updated Contacts:");
                            ViewAllContacts();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "V":
                        if (contactsList.Count == 0)
                        {
                            Console.WriteLine("The contacts list is empty.");
                        }
                        else
                        {
                            Console.WriteLine("All Contacts:");
                            ViewAllContacts();
                        }
                        break;

                    case "E":
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static List<string> AddContact(string contact)
        {
            if (string.IsNullOrEmpty(contact))
                throw new ArgumentException("Contact cannot be empty.");

            if (contactsList.Contains(contact))
                throw new ArgumentException("Contact already exists.");

            contactsList.Add(contact);
            return contactsList;
        }

        public static List<string> RemoveContact(string contact)
        {
            if (!contactsList.Remove(contact))
                throw new ArgumentException("Contact does not exist.");

            return contactsList;
        }

        public static List<string> ViewAllContacts()
        {
            foreach (string contact in contactsList)
            {
                Console.WriteLine(contact);
            }
            return contactsList;
        }


        // Using in Tests
        public static void RemoveAllContacts()
        {
            contactsList.Clear();
        }


    }
}
