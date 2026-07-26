//Day 13 — File I/O in C#

//File I/O lets you read and write data to actual files on disk. Right now your phonebook disappears when the program closes —
//File I/O fixes that. This is also directly relevant to logging, config files, and data export in real .NET projects.

// WriteAllText — creates file if not exists, overwrites if exists
File.WriteAllText("data.txt", "Hello Farah!");

// AppendAllText — adds to existing file without overwriting
File.AppendAllText("data.txt", "\nNew line added");

// WriteAllLines — writes a list of strings, one per line
string[] lines = { "Farah", "Sara", "Zara" };
File.WriteAllLines("names.txt", lines);

// ReadAllText — reads entire file as one string
string content = File.ReadAllText("data.txt");
Console.WriteLine(content);

// ReadAllLines — reads file into string array, one element per line
string[] lines1 = File.ReadAllLines("names.txt");
foreach (string line in lines1)
    Console.WriteLine(line);

// ReadAllLines into a List
List<string> names = new List<string>(File.ReadAllLines("names.txt"));

// When program starts:
// Load contacts from "phonebook.txt" into the dictionary
// If file doesn't exist yet, start with empty dictionary

// When program exits (case 6):
// Save all contacts back to "phonebook.txt"
// Format: "name,phoneNumber" — one contact per line

// Requirements:
// Loading must handle missing file gracefully
// Saving must overwrite the file completely with current data
// After saving print "Contacts saved successfully"
// Test by adding a contact, exiting, reopening — contact should still be there



Dictionary<string, string> phoneBook = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
phoneBook.Add("Ali", "0300");
phoneBook.Add("Ahmad", "0301");
phoneBook.Add("Asad", "0302");
phoneBook.Add("Alia", "0303");
phoneBook.Add("Aleena", "0304");
bool running = true;
while (running)
{
    Console.WriteLine("-------WELCOME TO------");
    Console.WriteLine("Phone Book console app");
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Add contact");
    Console.WriteLine("2. Search contact by name");
    Console.WriteLine("3. Update contact number");
    Console.WriteLine("4. Delete contact");
    Console.WriteLine("5. Display all contacts");
    Console.WriteLine("6. Exit");
    int choice;
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Console.WriteLine("Adding a contact");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter number: ");
            string phoneNo = Console.ReadLine();
            if (phoneBook.ContainsKey(name))
                Console.WriteLine("Contact already exists.");
            else
            {
                phoneBook.Add(name, phoneNo);
                Console.WriteLine("Added " + name + "!");
            }
            break;
        case 2:
            Console.WriteLine("Enter name to search: ");
            string searchName = Console.ReadLine().ToLower();

            bool found = false;
            foreach (var contact in phoneBook)
            {
                if (contact.Key.ToLower() == searchName)
                {
                    Console.WriteLine($"Found: {contact.Key} — {contact.Value}");
                    found = true;
                    break;
                }
            }
            if (!found)
                Console.WriteLine("Contact not found.");
            break;
        case 3:
            Console.WriteLine("Enter contact name to update: ");
            string updateName = Console.ReadLine().ToLower();
            if (phoneBook.ContainsKey(updateName))
            {
                Console.WriteLine("Enter new phoneNo: ");
                string Updatedphone = Console.ReadLine();
                phoneBook[updateName] = Updatedphone;
                Console.WriteLine("Updated " + updateName + "!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }

            break;
        case 4:
            Console.WriteLine("Enter contact name to delete: ");
            string delcontact = Console.ReadLine();

            if (phoneBook.ContainsKey(delcontact))
            {
                phoneBook.Remove(delcontact);
                Console.WriteLine("Removed " + delcontact);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
            break;
        case 5:
            Console.WriteLine("------Displaying all contacts--------");
            foreach (string key in phoneBook.Keys.OrderBy(k => k))
            {
                Console.WriteLine($"{key}: {phoneBook[key]}");
            }
            break;
        case 6:
            Console.WriteLine("Exiting...");
            running = false;
            break;
        default:
            Console.WriteLine("Please enter a valid choice: ");
            break;

    }

}
