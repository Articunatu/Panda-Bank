# Panda-Bank


The Panda-Bank is a school project. The program is coded in C# in .NET. It´s a program that are suppose to be like a bank system.

There are seven different classes, including the Main program class and two partial classes. 
## Classes
The classes names are; Program.Cs, BankController, LoginUser, Admin, Accounts, Customer and Customer2. 

### Program
In the Program class we invoke the BankController, meaning where the whole program starts. 

### BankController 
The bankController class is where we keep the different key components to our program; our LoginUs, where the log in function is stored. Our SignInMetod, where the user menu is displayed and our SignInAdmin, where admins menu is displayed. We also keep part of the Timer method here. 

### LoginUser
This is our base/parent class, where we keep the strings for UserName and Password and also the decimal array for the Currency rate. 

### Admin 
Admin inherits from the base class LoginUser. Here is where we store the List of Customers and also where we add value to the list of Accounts. Here we also keep the different admin methods, so the ShowCustomer method; where a list of all customers and their accounts are printed out, CreateCustomers method; where the admin can create a customer and finally the UpdateCurrency method; where the admin manually has to update the currency daily. 

### Accounts
Here we keep our variabels for Name, Balance, Currency and IsSavings in a constructor to highten the safety. We also keep two different structs; Transaction and Calculation, that are both needed for the timer function. 

### Customer
Customer inherits from the base class and is also a partial class. Here is where we invoke the list of Accounts, though the value is added in the admin class. We keep the ShowAccounts method, where all the currently logged in users' accounts are printed out. The TransferAccounts method, where one can transfer money from one account to another. The TransferMoneyToUser method, where one can transfer money to another user. The enum Currency, that holds the four different currencies we currently use; SEK, USD, GBP and EUR. The CreateAccount method, where one can create a new account, choose currency for said account and decide if the account willl be a normal one or a savings account. And lastly we keep the ExchangeRate method, where if one tranfers money between accounts with different currencies, the equivalent amount will be transfered conditionally with the currency value. 

### Customer2
Customer 2 inherits from the base class and is the other partial class. Here is where we have the list of Transactions, also connected with the timer. We aditionally keep the SaveTransaction, the SaveCalculations and the ListTransaction methods that also are involved with the timer function. The other methods kept in this class are; ShowTransactions which shows all the made transactions, the obsolete CreateSavingsAccount which was added into the CreateAccount method, DepositMoney which allows the user to deposit money and see the interset amount they'll have in a year, the WithdrawMoney method, the InterestMoney method, the Loan method which allows the user to take out a loan five times their combined accounts balance and then informs of how much one will have to pay back yearly, and lastly we have the ChangePassword method where the user can change their password with specific limitations; has to have eight characters whereas at least one has to be a number and a letter.


[Here is our board](https://trello.com/b/MATS4rhJ/gruppprojekt), we used a mixture of Kanban, Scrum and XP of the agile Workmethods.

[Here is our UML chart](https://lucid.app/lucidchart/57bebeee-fdc6-4bce-b75e-869f5b7751cc/edit?invitationId=inv_a81b3d19-a3c3-4718-b67b-3611e985996d)
, where we have a rough layout of how the code was to be built, meaning where all the methods where to be placed.
