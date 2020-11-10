using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook ourPhoneBook = new PhoneBook();
            Console.WriteLine("Welcome! This app is an interactive phone book");
            Console.WriteLine("For list of available commands type 'help'");
            while(true)
            {
                string commandInput = Console.ReadLine();
                if (commandInput == "exit")
                {
                    Console.WriteLine("Bye-bye");
                    break;
                }
                else if (commandInput == "Add")
                {
                    Console.Clear();
                    Console.WriteLine("Adding new record. You can write Surname, Name, Lastname, Phone (only digits), Country, Birthday, Organization, Position and Notes.");
                    Console.WriteLine("Surname, Name, Phone and Country are mandatory. Other can be left empty.");
                    Console.WriteLine("Write each field on a new line in requested order.");
                    Console.WriteLine("Surname:");
                    string surname;                    
                    while(true)
                    {
                        surname = Console.ReadLine();
                        if (surname == "")
                        {
                            Console.WriteLine("You can't leave Surname empty. Try again.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine("Name:");
                    string name;
                    while(true)
                    {
                        name = Console.ReadLine();
                        if (name == "")
                        {
                            Console.WriteLine("You can't leave Name empty. Try again.");
                        }
                        else
                        {
                            break;
                        }
                    }                    
                    Console.WriteLine("Lastname:");
                    string lastname = Console.ReadLine();     
                    Console.WriteLine("Phone:");
                    string phoneStr;
                    long phone;
                    while(true)
                    {
                        phoneStr = Console.ReadLine();
                        if (!Int64.TryParse(phoneStr, out phone))
                        {
                            Console.WriteLine("Can't understand such phone number. Try again.");
                        }
                        else
                        {
                            if (phone <= 0)
                            {
                                Console.WriteLine("Can't understand such phone number. Try again.");
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine("Country:");
                    string country; 
                    while(true)
                    {
                        country = Console.ReadLine(); 
                        if (country == "")
                        {
                            Console.WriteLine("You can't leave Country empty. Try again.");
                        }
                        else
                        {
                            break;
                        }
                    }  
                    Console.WriteLine("Birthday:");
                    string birthday = Console.ReadLine(); 
                    Console.WriteLine("Organization:");
                    string organization = Console.ReadLine(); 
                    Console.WriteLine("Position:");
                    string position = Console.ReadLine(); 
                    Console.WriteLine("Note:");
                    string note = Console.ReadLine(); 
                    PhoneBookRecord newRecord = new PhoneBookRecord(surname, name, lastname, phone, country, birthday, organization, note);
                    ourPhoneBook.AddNewRecord(newRecord);
                    Console.Clear();
                    Console.WriteLine("Record was saved");
                    Console.WriteLine("Waiting for command");
                }
                else if (commandInput == "Delete")
                {
                    Console.Clear();
                    Console.WriteLine("Delete record");
                    Console.WriteLine("Type order number of record you want to delete. Type 'exit' if you want to go back.");
                    string input;
                    int num;
                    while(true)
                    {
                        input = Console.ReadLine();
                        if (input == "exit")
                        {
                            Console.Clear();
                            Console.WriteLine("Waiting for command");
                            break;
                        }
                        if (!(Int32.TryParse(input, out num)))
                        {
                            Console.WriteLine("Can't understand number you wrote. Try again");
                        }
                        else
                        {
                            if (ourPhoneBook.CheckIndex(num))
                            {
                                Console.Clear();
                                Console.WriteLine("Record was succesfully removed");                                                            
                                Console.WriteLine("Waiting for command");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("There is no such index. Try again.");
                            }
                        }
                    }      
                }
                else
                {
                    Console.WriteLine("I don't know such comand");
                }
            }

        }
    }
    class PhoneBook
    {
        private List<PhoneBookRecord> allRecords = new List<PhoneBookRecord>();
        public void AddNewRecord(PhoneBookRecord record)
        {
            this.allRecords.Add(record);
        }
        public void EditRecord()
        {
            
        }
        public void DeleteRecord(int num)
        {
            this.allRecords.Remove(this.allRecords[num - 1]);
        }
        public void PrintRecord()
        {
            
        }
        public void PrintAllRecords()
        {
            
        }
        public bool CheckIndex(int num)
        {
            if (this.allRecords.Count() >= num && num >= 1)
            {
                return true;
            }
            return false;
        }
    }

    public class PhoneBookRecord
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public long Phone { get; set; }
        public string Country { get; set; }
        public string Birthday { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Note { get; set; }

        public PhoneBookRecord(string surname, string name, string lastname, long phone, string country, string birthday, string organization, string note )
        {
            Surname = surname;
            Name = name;
            Lastname = lastname;
            Phone = phone;
            Country = country;
            Birthday = birthday;
            Organization = organization;
            Note = note;
        }

        public string ToShortString()
        {
            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        
    }
}
