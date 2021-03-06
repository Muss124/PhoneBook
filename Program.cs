﻿using System;
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
            Console.WriteLine("Welcome!");
            Console.WriteLine("This app is an interactive phone book.");
            Console.WriteLine("For list of available commands type 'help'");
            while(true)
            {
                string commandInput = Console.ReadLine();
                if (commandInput == "exit")
                {
                    Console.WriteLine("Bye-bye!");
                    break;
                }
                else if (commandInput == "add")
                {
                    Console.Clear();
                    Console.WriteLine("Adding new record");
                    Console.WriteLine("*****************");
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
                    PhoneBookRecord newRecord = new PhoneBookRecord(surname, name, lastname, phone, country, birthday, organization, position, note);
                    ourPhoneBook.AddNewRecord(newRecord);
                    Console.Clear();
                    Console.WriteLine("Record was saved");
                    Console.WriteLine("Waiting for command");
                }
                else if (commandInput == "delete")
                {
                    Console.Clear();
                    Console.WriteLine("Delete record");
                    Console.WriteLine("*************");
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
                                ourPhoneBook.DeleteRecord(num);
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
                else if (commandInput == "edit")
                {
                    Console.Clear();
                    Console.WriteLine("Editinig record");
                    Console.WriteLine("***************");
                    Console.WriteLine("First you need to choose record to edit.");
                    Console.WriteLine("Type order number of record you want to edit. Type 'exit' if you want to go back");
                    string input;
                    int num = -1;                    
                    while(true)
                    {
                        input = Console.ReadLine();
                        if (input == "exit")
                        {
                            Console.Clear();
                            Console.WriteLine("Waiting for command");
                            break;
                        }
                        else
                        {
                            if (!(Int32.TryParse(input, out num)))
                            {
                                Console.WriteLine("Can't understand number you wrote. Try again");
                            }
                            else
                            {
                                if (ourPhoneBook.CheckIndex(num))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Editing record {0}", num); 
                                    Console.WriteLine("******************");
                                    Console.WriteLine("Second you need to edit fields of this record.");
                                    Console.WriteLine("You will see what was record and then would be able to type a new information");
                                    Console.WriteLine("Leave string empty if you don't want to change current field");  
                                    PhoneBookRecord currentRecord = ourPhoneBook.ExtractPhoneBookRecord(num);
                                    // asd
                                    Console.WriteLine("Surname:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Surname);                                    
                                    string surname = Console.ReadLine();
                                    if (surname != "")
                                    {
                                        currentRecord.Surname = surname;
                                    }
                                    Console.WriteLine("Name:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Name);
                                    string name = Console.ReadLine();
                                    if (name != "")
                                    {
                                        currentRecord.Name = name;
                                    }                  
                                    Console.WriteLine("Lastname:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Lastname);
                                    string lastname = Console.ReadLine(); 
                                    if (lastname != "")
                                    {
                                        currentRecord.Lastname = lastname;
                                    }    
                                    Console.WriteLine("Phone:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Phone);
                                    string phoneStr;
                                    long phone;
                                    while(true)
                                    {
                                        phoneStr = Console.ReadLine();
                                        if (phoneStr == "")
                                        {
                                            break;
                                        }
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
                                                currentRecord.Phone = phone;
                                                break;
                                            }
                                        }
                                    }
                                    Console.WriteLine("Country:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Country);
                                    string country = Console.ReadLine();
                                    if (country != "")
                                    {
                                        currentRecord.Country = country;
                                    } 
                                    Console.WriteLine("Birthday:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Birthday);
                                    string birthday = Console.ReadLine(); 
                                    if (birthday != "")
                                    {
                                        currentRecord.Birthday = birthday;
                                    } 
                                    Console.WriteLine("Organization:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Organization);
                                    string organization = Console.ReadLine(); 
                                    if (organization != "")
                                    {
                                        currentRecord.Organization = organization;
                                    } 
                                    Console.WriteLine("Position:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Position);
                                    string position = Console.ReadLine(); 
                                    if (position != "")
                                    {
                                        currentRecord.Position = position;
                                    } 
                                    Console.WriteLine("Note:");
                                    Console.WriteLine("\"{0}\"", currentRecord.Note);
                                    string note = Console.ReadLine(); 
                                    if (note != "")
                                    {
                                        currentRecord.Note = note;
                                    } 
                                    ourPhoneBook.EditRecord(num, currentRecord);
                                    Console.Clear();
                                    Console.WriteLine("Record number {0} was edited", num);
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
                    
                    
                }
                else if (commandInput == "print")
                {
                    Console.Clear();
                    Console.WriteLine("Printing record info");
                    Console.WriteLine("********************");
                    Console.WriteLine("Type order number of record you want to print. Type 'exit' if you want to go back.");
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
                                Console.WriteLine("Printing information about record number {0}", num);     
                                PhoneBookRecord currentRecord = ourPhoneBook.ExtractPhoneBookRecord(num);                                
                                Console.WriteLine("Surname - {0}", currentRecord.Surname);
                                Console.WriteLine("Name - {0}", currentRecord.Name);                                
                                Console.WriteLine("Lastname - {0}", currentRecord.Lastname);
                                Console.WriteLine("Phone - {0}", currentRecord.Phone);
                                Console.WriteLine("Birthday - {0}", currentRecord.Birthday);
                                Console.WriteLine("Contry - {0}", currentRecord.Country);
                                Console.WriteLine("Organization - {0}", currentRecord.Organization);
                                Console.WriteLine("Position - {0}", currentRecord.Position);
                                Console.WriteLine("Note - {0}", currentRecord.Note);
                                Console.WriteLine("Press enter to continue");
                                input = Console.ReadLine();
                                Console.Clear();
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
                else if (commandInput == "print all")
                {
                    Console.Clear();
                    ourPhoneBook.PrintAllRecords();
                    Console.WriteLine("Press enter to continue");
                    string input = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Waiting for command");
                }
                else if (commandInput == "help")
                {
                    Console.Clear();
                    Console.WriteLine("Available comands:");
                    Console.WriteLine("add - add new record to phone book");
                    Console.WriteLine("edit - edit existing record in phone book");
                    Console.WriteLine("delete - delete existing record in phone book");
                    Console.WriteLine("print - print full information about one record");
                    Console.WriteLine("print all - print short information about all records");
                    Console.WriteLine("exit - quit program");
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine("Press enter to continue");
                    string input = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Waiting for command");
                }
                else
                {
                    Console.WriteLine("I don't know such command");
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
        public void EditRecord(int index, PhoneBookRecord record)
        {
            this.allRecords[index - 1] = record;
        }
        public void DeleteRecord(int num)
        {
            this.allRecords.Remove(this.allRecords[num - 1]);
        }
        public void PrintAllRecords()
        {
            if (this.allRecords.Count == 0)
            {
                Console.WriteLine("There is no records in phonebook");
                Console.WriteLine("********************************");
            }
            else
            {
                Console.WriteLine("All records in phonebook");
                Console.WriteLine("************************");            
                foreach(var record in this.allRecords)
                {
                    Console.WriteLine(record.ToString());
                    Console.WriteLine("************************");
                }
            }
            
        }
        public bool CheckIndex(int num)
        {
            if (this.allRecords.Count() >= num && num >= 1)
            {
                return true;
            }
            return false;
        }
        public PhoneBookRecord ExtractPhoneBookRecord(int index)
        {
            if (this.allRecords.Count() >= index && index >= 1)
            {
                return this.allRecords[index - 1];
            }
            return null;
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

        public PhoneBookRecord(string surname, string name, string lastname, long phone, string country, string birthday, string organization, string position, string note )
        {
            Surname = surname;
            Name = name;
            Lastname = lastname;
            Phone = phone;
            Country = country;
            Birthday = birthday;
            Organization = organization;
            Position = position;
            Note = note;
        }

        public override string ToString()
        {
            string result = $"Surname - {Surname}\nName - {Name}\nPhone nuber - {Phone}";
            return result;
        }
        
    }
}
