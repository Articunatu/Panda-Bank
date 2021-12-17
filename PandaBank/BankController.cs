using System;
using System.Collections.Generic;
using System.Text;

namespace PandaBank
{
    struct BankController
    {
        internal void Start()
        {
            Admin a = new Admin();
            a.AdminSetup();
            a.UserName = "Admin"; a.Password = "1234";
            List<Customer> ListOfCustomers = a.ListOfCustomers;
            LoginUs(a, ListOfCustomers);
        }

        private static void LoginUs(Admin a, List<Customer> ListOfCustomers)
        {
            bool logintry = true;
            while (logintry)
            {
                for (int i = 0; i <= 2; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Användarnamn: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string userAnswer = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Lösenord: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string userPass = "";

                    ///Stolen from CraigTP
                    ConsoleKey keyPassword;
                    do
                    {
                        var hiddenPassword = Console.ReadKey(intercept: true); ///Hides the input keys in the console
                        keyPassword = hiddenPassword.Key;

                        if (keyPassword == ConsoleKey.Backspace && userPass.Length > 0)
                        {
                            Console.Write("\b \b");     ///Can use backspace while typing a password 
                            userPass = userPass[0..^1]; ///Sets the chars in the password to their correct indexes
                        }
                        else if (!char.IsControl(hiddenPassword.KeyChar)) ///Stops ENTER/ESCAPE/etc. keys from being part of the password 
                        {
                            Console.Write("*");
                            userPass += hiddenPassword.KeyChar;
                        }
                    } while (keyPassword != ConsoleKey.Enter);

                    if (userAnswer == a.UserName && userPass == a.Password)
                    {
                        SignInAdmin(a, ListOfCustomers);
                        break;
                    }

                    LoginUser result = ListOfCustomers.Find(result => result.UserName == userAnswer);
                    LoginUser result1 = ListOfCustomers.Find(result => result.Password == userPass);
                    if (result == null || result1 == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nFel användarnamn eller lösenord, skriv in ett nytt!");
                        if (i == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Du har nått maxgräns försök!");
                            Environment.Exit(0);
                        }
                    }

                    else if (result.UserName == userAnswer && result.Password == userPass)
                    {
                        Customer resultCust = (Customer)result;
                        SignInMetod(a, resultCust, ListOfCustomers);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Fel användarnamn eller lösenord, skriv in ett nytt:");
                        if (i == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Du har nått maxgräns försök!");
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        private static void SignInMetod(Admin a, Customer loginUser, List<Customer> customers)
        {

            bool Online = true;
            while (Online)
            {
                Timer();
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(@"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$**$$$$$$$$$**$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$^ ^$$$$$$F *   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$     z$$$$$$L   ^$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$    e$$$$$$$$$e  J$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$eee$$$$$$$$$$$$$e$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$b$$$$$$$$$$$$$$$$$$*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$)$$$$P*e^$$$F$r*$$$$F*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$d$$$$  z$$$$^  $$$$%  $3$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$*""^*$$$  .$$$$$$ z$$$*   ^$e*$$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$^     *$$ee$$$$$$$$$$*^     $$$C$$$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$.      ' * **$$'*$$""       $$$$e*$$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$b           $b.$$           $$$$$b'$$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$c.         ""'            $$$$$$$^$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$e..                     $$$$$$$$^$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$eeee..            J$$$$$$$$b'$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$r          z$$$$$$$$$$r$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$'         z$$$$$**$$$$$^$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$*'          z$$$P'   ^*$$$ $$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$*'           .d$$$$       $$$ $$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$'           .e$$$$$F       3$$ $$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$.         .d$$$$$$$         $PJ$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$eeeeeeed$*""""**""            $\$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$                  $d$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$.                 $$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$e.              d$$$$$$$$$$$$$$$$$$$$$$$
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$eeeeeee$$$$$$$$$$$$$$$$$$$$$$$$$
");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n");
                Console.WriteLine("Välkommen till PandaBanken");
                int chosenOption;
                Console.WriteLine("[1]  Visa Konton");
                Console.WriteLine("[2]  Överför Pengar Mellan Egna Konton");
                Console.WriteLine("[3]  Överför Pengar Till Andra Användare");
                Console.WriteLine("[4]  Skapa Konto");
                Console.WriteLine("[5]  Sätt In Pengar");
                Console.WriteLine("[6]  Ta Ut Pengar");
                Console.WriteLine("[7]  Låna Pengar");
                Console.WriteLine("[8]  Visa transaktioner");
                Console.WriteLine("[9]  Byt lösenord");
                Console.WriteLine("[10] Logga ut");
                Console.Write("");
                Int32.TryParse(Console.ReadLine(), out chosenOption);
                Console.WriteLine();

                switch (chosenOption)
                {
                    case 1:
                        loginUser.ShoweAccounts();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        loginUser.ShoweAccounts();
                        loginUser.TransferAccounts();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        loginUser.TransferMoneyToUser(customers);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        loginUser.CreateAccount();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        loginUser.DepositMoney();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        loginUser.WithdrawMoney();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        loginUser.Loan();
                        Console.Clear();
                        break;
                    case 8:
                        loginUser.ShowTransactions();
                        //foreach (var item in queuedTransactions)
                        //{
                        //    Console.WriteLine(item.SavedTransfer());
                        //}
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 9:
                        loginUser.ChangePassword();
                        Console.Clear();
                        break;
                    case 10:
                        Console.Clear();
                        LoginUs(a, customers);
                        break;
                    default: Console.WriteLine("Var snäll och välj ett giltigt alternativ!"); break;
                }
            }
        }

        private static void SignInAdmin(Admin a, List<Customer> customers)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" /$$$$$$$                            /$$                /$$$$$$$                      /$$                          ");
            Console.WriteLine("| $$__  $$                           |$$               | $$__  $$                    | $$                          ");
            Console.WriteLine("| $$   |$$   /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$     | $$  |$$   /$$$$$$  /$$$$$$$ | $$   /$$  /$$$$$$  /$$$$$$$ ");
            Console.WriteLine("| $$$$$$$/|  ___  $$| $$__  $$ /$$__  $$ | ____ $$     | $$$$$$$  | ____ $$| $$__  $$| $$  /$$/ /$$__  $$| $$__  $$");
            Console.WriteLine("| $$____ /  /$$$$$$$| $$  | $$| $$  | $$  /$$$$$$$     | $$__  $$  /$$$$$$$| $$  | $$| $$$$$$/ | $$$$$$$$| $$  | $$");
            Console.WriteLine("| $$       /$$__  $$| $$  | $$| $$  | $$ /$$__  $$     | $$  | $$ /$$__  $$| $$  | $$| $$_  $$ | $$_____/| $$  | $$");
            Console.WriteLine("| $$       | $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$     | $$$$$$$/|  $$$$$$$| $$  | $$| $$ |  $$|  $$$$$$$| $$  | $$");
            Console.WriteLine("|__/       |_______/ |__/  |__/ |_______/ |_______/    |_______/  |_______/|__/  |__/|__/  |__/ |_______/|__/  |__/");
            Console.WriteLine();
            
            Console.WriteLine("Välkommen Admin, vad vill du göra?");
            Console.WriteLine("[1] Se en lista över alla användare");
            Console.WriteLine("[2] Skapa en nya användare");
            Console.WriteLine("[3] Uppdatera penningvärdet för valuta");
            Console.WriteLine("[4] Logga ut.");
            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    a.ShowCustomers();
                    Console.ReadKey();
                    Console.Clear();
                    SignInAdmin(a, customers);
                    break;
                case 2:
                    a.CreateCustomer();
                    Console.Clear();
                    SignInAdmin(a, customers);
                    break;
                case 3:
                    a.UpdateCurrency();
                    Console.Clear();
                    SignInAdmin(a, customers);
                    break;
                case 4:
                    Console.Clear();
                    LoginUs(a, customers);
                    break;
                case 5:
                    a.UpdateCurrency();
                    break;
                default:
                    Console.WriteLine("Var snäll och välj ett giltigt alternativ!");
                    SignInAdmin(a, customers);
                    break;
            }
        }

        public static Queue<Transcation> queuedTransactions = new Queue<Transcation>();

        public static Queue<Calculation> queuedCalculations = new Queue<Calculation>();

        private static void Timer()
        {
            if (queuedTransactions.Count > 0)
            {
                int lengthQueue = queuedTransactions.Count;
                for (int i = 0; i < lengthQueue; i++)
                {
                    if (queuedTransactions.Peek().TimeOfTransfer.AddSeconds(15) <= DateTime.Now)
                    {
                        queuedTransactions.Peek().User.ListTransaction(queuedTransactions.Dequeue());
                        if (queuedCalculations.Count > 0)
                        {
                            queuedCalculations.Dequeue().SetCalculatedBalance();
                        }
                    }
                }
            }
            else { }
        }
    }
}