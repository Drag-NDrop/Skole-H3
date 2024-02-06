using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Card
    {
        public int AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }
        public short Pin { get; set; }
        public int escrowLimit { get; set; } = 0;

        public Card(int accountNumber, string accountHolder, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = balance;
        }
        public Card(int accountNumber, string accountHolder, decimal balance, short pin)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = balance;
            Pin = pin;
        }

        public void InsertMoney(int accountNumber, decimal moneyToInsert)
        {
            if (AccountNumber == accountNumber)
            {
                Balance += moneyToInsert;
            }
        }

        public void WithdrawMoney(int accountNumber, decimal moneyToWithdraw)
        {
            if (AccountNumber == accountNumber)
            {
                Balance -= moneyToWithdraw;
            }
        }

    }
}
