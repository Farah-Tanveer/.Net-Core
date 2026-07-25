//Day 12 — Dictionary

//A Dictionary stores data as key-value pairs. Think of it like a real dictionary
//you look up a word (key) and get its meaning (value). Keys must be unique.

//NOTES
// Dictionary<keyType, valueType>
//Dictionary<string, int> ages = new Dictionary<string, int>();

//// Add
//ages.Add("Farah", 20);
//ages.Add("Sara", 22);
//ages.Add("Zara", 19);

//// Read
//Console.WriteLine(ages["Farah"]); // 20

//// Update
//ages["Farah"] = 21;

//// Delete
//ages.Remove("Sara");

//// Check if key exists — always do this before accessing
//if (ages.ContainsKey("Zara"))
//    Console.WriteLine(ages["Zara"]);

//// Count
//Console.WriteLine(ages.Count); // 2



//------Exercise--------
// Build a simple Phone Book console app
// Use Dictionary<string, string> to store name → phone number

// Menu:
// 1. Add contact
// 2. Search contact by name
// 3. Update contact number
// 4. Delete contact
// 5. Display all contacts
// 6. Exit

// Requirements:
// Check if contact already exists before adding
// Check if contact exists before updating or deleting
// Use TryGetValue for searching
// Display all contacts sorted alphabetically by name
// Hint: contacts.Keys.OrderBy(k => k)

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
            string updateName=Console.ReadLine().ToLower();
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