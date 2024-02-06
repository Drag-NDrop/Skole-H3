using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using Xunit;

namespace ATM.Tests
{

    public class CardTests
    {

        // The card class is a simple class that represents a bank card. It has a number, a holder and a balance.
        // The card class has two methods, InsertMoney and WithdrawMoney, that are used to change the balance of the card.
        // The card class has a constructor that takes the number, the holder and the balance of the card as arguments.
        // We are now testing the constructor:
        [Theory]
        [InlineData(123456789,"Erik Borup", 100000)]
        [InlineData(9999998, "Johhny Brian", 0)]
        [InlineData(1231232, "Homer Simpson", 500)]
        public void ShouldCreateCardValidData(int accountNumber, string accountHolder, decimal balance)
        {
            // Arrage / Act
            Card card = new Card(accountNumber, accountHolder, balance);
            
            //Assert
            Assert.True(card != null);
        }


        // Testing the InsertMoney method. Attempting to align with the single responsibility principle. Not involving ValidatePin & RetrieveCard on purpose.
        [Theory]
        [InlineData(1111111, 2242, 55555)]
        [InlineData(2222222, 5555, 666)]
        [InlineData(3333333, 9999, 1337)]

        public void ShouldInsertMoney(int accountNumber, short pin, decimal moneyToInsert)
        {
            //Arrange
            ATM liveAtm = new ATM();
            Card card = liveAtm.RetrieveAccount(accountNumber, pin);
            //Act
            decimal balance = card.Balance;
            card.InsertMoney(accountNumber, moneyToInsert);

            //Assert
            Assert.Equal(balance + moneyToInsert, card.Balance);
        }

        // Testing the WithdrawMoney method. Attempting to align with the single responsibility principle. Not involving ValidatePin & RetrieveCard on purpose.
        [Theory]
        [InlineData(1111111, 2242, 500)]
        [InlineData(2222222, 5555, 999)]
        [InlineData(3333333, 9999, 1337)]
       
        public void ShouldWithdrawMoney(int accountNumber, short pin, decimal moneyToWithdraw)
        {
            //Arrange
            ATM liveAtm = new ATM();
            Card card = liveAtm.RetrieveAccount(accountNumber, pin);

            //Act
            decimal balance = card.Balance;
            card.WithdrawMoney(accountNumber, moneyToWithdraw);

            //Assert
            Assert.Equal(balance - moneyToWithdraw, card.Balance);
        }

        
    }
}
