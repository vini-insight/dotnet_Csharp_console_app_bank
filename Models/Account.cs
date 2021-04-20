using System;
using Enums;

namespace Models
{
	public class Account
	{
		// Atributos
		private AccountType AccountType { get; set; }
		public double Fund { get; private set; }
		private double Credit { get; set; }
		public string Name { get; private set; }

		// Métodos
		public Account(AccountType AccountType, double fund, double credit, string name)
		{
			this.AccountType = AccountType;
			this.Fund = fund;
			this.Credit = credit;
			this.Name = name;
		}

		public bool Withdraw(double amount)
		{
            // Sufficient funds validation
            if(this.Fund - amount < (this.Credit *-1))
			{
                Console.WriteLine("Insufficient Funds!");
                return false;
            }
            this.Fund -= amount;
            Console.WriteLine("The current fund of the {0} account is {1}", this.Name, this.Fund);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting
            return true;
		}

		public void Deposit(double amount)
		{
			this.Fund += amount;
            Console.WriteLine("The current fund of the {0} account is {1}", this.Name, this.Fund);
		}

		public void Transfer(double amount, Account targetAccount)
		{
			if(this.Withdraw(amount))
				targetAccount.Deposit(amount);
		}

        public override string ToString()
		{
			return "AccountType " + this.AccountType + " | " + "Name " + this.Name + " | " + "Funds " + this.Fund + " | " + "Credits " + this.Credit;
		}
	}
}