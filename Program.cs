using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pd2task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Credential> users = new List<Credential>();
            string path = "D:\\cs\\PRACTICE\\pd2task1\\textfile.txt";
            int option;
            do
            {
                readData(path, users);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();
                    if (name == "admin" & password == "admin")
                    {
                        admin();
                    }
                    else
                    {
                        signIn(name, password, users);
                    }
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string password = Console.ReadLine();

                    signUp(path, name, password);
                }
            }
            while (option < 3);
            Console.Read();
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. Signup");
            Console.WriteLine("3. Exit");
            option = int.Parse(Console.ReadLine());
            return option;

        }
        static void readData(string path, List<Credential> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Credential info = new Credential();
                    info.name = parseData(record, 1);
                    info.password = parseData(record, 2);
                    users.Add(info);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                    comma++;
                else if (comma == field)
                    item = item + record[x];
            }
            return item;
        }
        static void signIn(string n, string p, List<Credential> users)
        {
            bool flag = false;
            for (int x = 0; x < users.Count; x++)
            {
                if (n == users[x].name && p == users[x].password)
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        static void admin()
        {

            Console.Clear();
            int adminOption = 0;
            Console.SetCursorPosition(55, 20);
            Console.Write("   1. MANAGE STUDENT");
            Console.SetCursorPosition(55, 21);
            Console.Write("   2. MANAGE TEACHER");
            Console.SetCursorPosition(55, 22);
            Console.Write("   3. VIEW FEEDBACK.");
            Console.SetCursorPosition(55, 23);
            Console.Write("   4. MAKE AN ANNOUNCEMENT.");
            Console.SetCursorPosition(55, 24);
            Console.Write("   5. LOGOUT.");
            Console.SetCursorPosition(55, 25);
            Console.Write("   6. EXIT.");
            adminOption = int.Parse(Console.ReadLine());
            if (adminOption == 1)
            {
                manageStudent();
            }
            else if (adminOption == 6)
            {
                return;
            }

        }
        static void manageStudent()
        {
            Console.Clear();
            int x = 55, y = 18;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("   1. ENTER STUDENT DATA.");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("   2. SHOW STUDENT DATA.");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("   3. SEARCH STUDENT DATA.");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("   4. UPDATE STUDENT DATA.");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("   5. DELETE STUDENT DATA.");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("   6. GO BACK.");
        }
        static void enterStudentDataByAdmin()
        {
            Console.Clear();
            int x1 = 55, y1 = 18;
            int choice1;
            Console.SetCursorPosition(x1, y1);
            Console.WriteLine("How many students do you want to enter? ");
            choice1 =int.Parse( Console.ReadLine());

        }
    }
}
