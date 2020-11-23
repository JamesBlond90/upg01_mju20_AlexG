using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Inlamning_2_ra_kod
{
    class Person
    {
        public string namn, adress, telefon, email;
        public Person(string N, string A, string T, string E)
        {
            namn = N; adress = A; telefon = T; email = E;
        }

        public Person()
        {
            Console.WriteLine("Lägger till ny person");
            Console.Write("  1. ange namn:    ");
            namn = Console.ReadLine();
            Console.Write("  2. ange adress:  ");
            adress = Console.ReadLine();
            Console.Write("  3. ange telefon: ");
            telefon = Console.ReadLine();
            Console.Write("  4. ange email:   ");
            email = Console.ReadLine();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> Dict = new List<Person>();
            string filePath = @"C:\Users\alexg\source\repos\VG\VG\address.list";
            Console.Write("Laddar adresslistan ... ");
            using (StreamReader fileStream = new StreamReader(filePath))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();
                    string[] word = line.Split('#');
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    Dict.Add(P);
                }
            }
            Console.WriteLine("klart!");
            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
            string command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                // string userInput = Console.ReadLine().ToLower();
                string[] abook = command.Split(' ');
                switch (abook[0])
                {
                    case "sluta":
                        Quit(Dict, abook);
                        break;
                    case "ny":
                        NewEntry(Dict, abook);
                        break;
                    case "ta bort":
                        Remove(Dict, abook);
                        break;
                    case "visa":
                        Show(Dict, abook);
                        break;
                    case "ändra":
                        Change(Dict, abook);
                        break;
                }
            } while (command != "sluta");
        }

        static void Quit(List<Person> Dict, string[] abook)
        {
            Console.WriteLine("Hej då!");
        }

        static void NewEntry(List<Person> Dict, string[] abook)
        {
           Dict.Add(new Person());
        }

        static void Remove(List<Person> Dict, string[] abook)
        {
            Console.Write("Vem vill du ta bort (ange namn): ");
            string wanttoremove = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].namn == wanttoremove) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", wanttoremove);
            }
            else
            {
                Dict.RemoveAt(found);
            }
        }

        static void Show(List<Person> Dict, string[] abook)
        {
            for (int i = 0; i < Dict.Count(); i++)
            {
                Person P = Dict[i];
                Console.WriteLine("{0}, {1}, {2}, {3}", P.namn, P.adress, P.telefon, P.email);
            }
        }

        static void Change(List<Person> Dict, string[] abook)
        {
            Console.Write("Vem vill du ändra (ange namn): ");
            string wanttochange = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].namn == wanttochange) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", wanttochange);
            }
            else
            {
                Console.Write("Vad vill du ändra (namn, adress, telefon eller email): ");
                string spacestochange = Console.ReadLine();
                Console.Write("Vad vill du ändra {0} på {1} till: ", spacestochange, wanttochange);
                string newvalue = Console.ReadLine();
                switch (spacestochange)
                {
                    case "namn": Dict[found].namn = newvalue; break;
                    case "adress": Dict[found].adress = newvalue; break;
                    case "telefon": Dict[found].telefon = newvalue; break;
                    case "email": Dict[found].email = newvalue; break;
                    default: break;
                }
            }
        }
    }
}