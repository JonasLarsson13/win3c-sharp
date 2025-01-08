using MainApp.Models;
using MainApp.Services;
using MainApp.Utilities;

namespace MainApp;

public class Menu
{
    private readonly ContactService _contactService = new ContactService(new FileService());

    public void ShowMenu()
    {
        var isRunning = true;

        do
        {
            Console.Clear();
            Console.WriteLine("-------- CONTACT LIST --------");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("Q. Exit Application");
            Console.WriteLine("------------------------------");
            Console.Write("Enter your choice: ");

            var option = Console.ReadLine()!;
            
            switch (option.ToLower())
            {
                case "1":
                    ShowAddContact();
                    break;

                case "2":
                    ShowAllContacts();
                    break;

                case "q":
                    Console.Clear();
                    OutputDialog("Press any key to exit the application.");
                    isRunning = false;
                    break;

                default:
                    OutputDialog("Invalid option. Press any key to try again.");
                    break;
            }
        } while (isRunning);
    }

    private void ShowAddContact()
    {
        var contact = new Contact();
        
        Console.Clear();
        Console.WriteLine("-------- NEW CONTACT --------");
        Console.Write("Enter First Name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter Last Name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter Email Address: ");
        contact.Email = Console.ReadLine()!;
        while (!Validator.IsValidEmail(contact.Email))
        {
            Console.Write("Invalid email. Please enter a valid email address: ");
            contact.Email = Console.ReadLine()!;
        }
        
        Console.Write("Enter Phone Number: ");
        contact.Phone = Console.ReadLine()!;
        while (!Validator.IsValidPhone(contact.Phone))
        {
            Console.Write("Invalid phone number. Please enter a valid phone number: ");
            contact.Phone = Console.ReadLine()!;
        }
        
        Console.Write("Enter Street: ");
        contact.Address = Console.ReadLine()!;
        
        Console.Write("Enter Zip Code: ");
        contact.ZipCode = Console.ReadLine()!;
        while (!Validator.IsValidZipCode(contact.ZipCode))
        {
            Console.Write("Invalid zip code. Please enter a valid zip code: ");
            contact.ZipCode = Console.ReadLine()!;
        }
        
        Console.Write("Enter City: ");
        contact.City = Console.ReadLine()!;

        _contactService.CreateContact(contact);
        Console.Clear();
        Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} was successfully added!");
        Console.WriteLine("Press any key to go back.");
        Console.ReadKey();
    }

    private void ShowAllContacts()
    {
        var contacts = _contactService.GetAllContacts().ToList();
        Console.Clear();
        Console.WriteLine("-------- CONTACT LIST --------");

        if (contacts.Count == 0)
        {
            OutputDialog("No contacts found. Press any key to go back.");
            return;
        }
    
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Id: {contact.Id}");
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Address: {contact.Address}");
            Console.WriteLine($"Zip: {contact.ZipCode}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine($"Created: {contact.CreatedDate}");
            Console.WriteLine("------------------------------");
        }
        Console.WriteLine("Press any key to go back.");
        Console.ReadKey();
    }
    
    private static void OutputDialog(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
    }
}