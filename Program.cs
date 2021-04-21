using System;
using Enums;
using Models;
using System.Collections.Generic;
using System.Threading;
namespace dotnet_Csharp_console_app_bank
{
	class Program
	{
		static List<Account> listAccounts = new List<Account>();
		static void Main(string[] args)
		{
			string userChoice = GetUserChoice();
			do
			{
				switch (userChoice)
				{
					case "1":
						ListAccounts();
						break;
					case "2":
						AddAccount();
						break;
					case "3":
						Transfer();
						break;
					case "4":
						Withdraw();
						break;
					case "5":
						Deposit();
						break;
					case "D":
						DelAccount();
						break;
					case "C":
						Console.Clear();
						break;
					case "X":
						continue;
					default:						
						Console.WriteLine("You typed \"{0}\"\n", userChoice);
						Console.WriteLine("invalid option. choose one of the alternatives below:".ToUpper());
						Console.WriteLine("\t\t\t1\n\t\t\t2\n\t\t\t3\n\t\t\t4\n\t\t\t5\n\t\t\tD\t\t\t\n\t\t\tC\n\n\t\t\tOR\n\n\t\t\tX\n");
						break;
				}
				userChoice = GetUserChoice();
			}
			while (userChoice != "X");
			Console.Clear();						
			for (int i = 3; i > 0; i--)
			{
				Console.WriteLine("\n");
				Console.WriteLine();
				Console.WriteLine("Thank you for using our services. Check back often!");
				Console.WriteLine();
				Console.WriteLine("		Closing in {0} seconds.", i);
				Thread.Sleep(1000);
				Console.Clear();
			}
		}
		private static void DelAccount()
		{
			Console.Write("Enter Customer Name to Delete: ");
			string inputName = Console.ReadLine();
			bool foundAccount = false;
			foreach (Account account in listAccounts)
			{
				if(account.Name.Equals(inputName))
				{
					foundAccount = true;
					if(account.Fund > 0)
					{
						Console.WriteLine("you cannot delete your account. your account has a positive FUNDS. withdraw all money or make a transfer to another account".ToUpper());
						break;
					}
					else
					{
						listAccounts.Remove(account);
						Console.WriteLine("the account has been deleted".ToUpper());
						break;
					}
				}
			}
			if(!foundAccount)
				Console.WriteLine("the account does not exist".ToUpper());
		}
		private static void Withdraw()
		{
			Console.Write("Enter the account number: ");
			int indexAccount = int.Parse(Console.ReadLine());
			Console.Write("Enter the amount you wish to withdraw: ");
			double amount = double.Parse(Console.ReadLine());
            listAccounts[indexAccount].Withdraw(amount);
		}
		private static void Deposit()
		{
			Console.Write("Enter the account number: ");
			int indexAccount = int.Parse(Console.ReadLine());
			Console.Write("Enter the amount you wish to deposit: ");
			double amount = double.Parse(Console.ReadLine());
			listAccounts[indexAccount].Deposit(amount);
		}
		private static void Transfer()
		{
			Console.Write("Enter the Origin account number: ");
			int indexAccountOrigin = int.Parse(Console.ReadLine());
			Console.Write("Enter the Target account number: ");
			int indexAccountTarget = int.Parse(Console.ReadLine());
			Console.Write("Enter the amount you wish to withdraw: ");
			double amount = double.Parse(Console.ReadLine());
			listAccounts[indexAccountOrigin].Transfer(amount, listAccounts[indexAccountTarget]);
		}
		private static void AddAccount()
		{
			Console.WriteLine("Add new Account");
			Console.Write("Enter 1 for CPF or 2 for CNPJ: ");
			int inputAccountType = int.Parse(Console.ReadLine());
			Console.Write("Enter Customer Name: ");
			string inputName = Console.ReadLine();
			Console.Write("Enter the opening Balance: ");
			double inputFund = double.Parse(Console.ReadLine());
			Console.Write("Enter the initial Credit: ");
			double inputCredit = double.Parse(Console.ReadLine());
			Account newAccount = new Account(AccountType: (AccountType) inputAccountType, fund: inputFund, credit: inputCredit, name: inputName);
			listAccounts.Add(newAccount);
		}
		private static void ListAccounts()
		{
			Console.WriteLine("Accounts List");
			if (listAccounts.Count == 0)
			{
				Console.WriteLine("No Account registered.");
				return;
			}
			for (int i = 0; i < listAccounts.Count; i++)
			{
				Account account = listAccounts[i];
				Console.Write("id {0} - ", i); // Fake ID
				Console.WriteLine(account);
			}
		}
		private static string GetUserChoice()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank at your service!!!");
			Console.WriteLine("Enter the desired option:");
			Console.WriteLine();
			Console.WriteLine("1 - List Accounts");
			Console.WriteLine("2 - Add new Account");
			Console.WriteLine("3 - Transfer");
			Console.WriteLine("4 - Withdraw");
			Console.WriteLine("5 - Deposit");
			Console.WriteLine("D - Delete Account");
			Console.WriteLine("C - Clear Screen");
			Console.WriteLine("X - Get out!");
			Console.WriteLine();
			string userChoice = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userChoice;
		}
	}
}
