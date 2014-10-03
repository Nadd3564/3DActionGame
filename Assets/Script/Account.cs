using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle
{
	public class Account
	{
		private decimal balance;
		private decimal minimumBalance = 10m;
		
		public decimal MinimumBalance
		{
			get{ return minimumBalance; }
		}

		public void Deposit(decimal amount)
		{
			balance += amount;
		}
		
		public void Withdraw(decimal amount)
		{
			balance -= amount;
		}
		
		public void TransferFunds(Account destination, decimal amount)
		{
			if(balance-amount < minimumBalance)
				throw new DifferentStringException();

			destination.Deposit(amount);
			Withdraw(amount);
		}
		
		public decimal Balance
		{
			get { return balance; }
		}
	}
}