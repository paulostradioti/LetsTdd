using System;
using System.ComponentModel.DataAnnotations;

namespace LetsTdd.Domain
{
    public class BankAccount
    {
        public double Balance { get; private set; }

        public BankAccount()
        {
            Balance = 25;
        }

        public double Withdraw(double amount)
        {
            if (Balance < amount)
                throw new InvalidOperationException("Insufficient Balance");

            if (amount < 0)
                throw new ArgumentException("Invalid Amount", nameof(amount));

            Balance -= amount;

            return Balance;
        }
    }
}
