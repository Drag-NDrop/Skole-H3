using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using Xunit;


namespace ATM.Tests
{
    public class ATMTests
    {

        // Testing to search up an account, that does not exist. Attempting to align with the single responsibility principle.
        // None of the accounts would return from the ATM; as none of them exists.
        [Theory]
        [InlineData(1234567, 2242)]
        [InlineData(9999998, 9999)]
        [InlineData(1231232, 5555)]
        public void ShouldFailFetchingAccountDoesNotExist(int accountNumber, short pin)
        {
            ATM liveAtm = new ATM();
            Assert.Throws<Exception>(() => liveAtm.RetrieveAccount(accountNumber, pin));
        }


        // Testing to retrieve an account, using a wrong pin. Attempting to align with the single responsibility principle.
        [Theory]
        [InlineData(1111111, 2243)]
        public void ShouldFailWrongPin(int accountNumber, short pin)
        {
            // Arrange 
            ATM liveAtm = new ATM();
            
            // Act / Assert
            Assert.Throws<Exception>(() => liveAtm.RetrieveAccount(accountNumber, pin));
        }

        // Testing to retrieve an account, using a wrong pin. Attempting to align with the single responsibility principle.
        [Theory]
        [InlineData(1111111, 2242)]

        public void ShouldFetchAccountCorrectPin(int accountNumber, short pin)
        {
            // Arrange
            ATM liveAtm = new ATM();
            // Act
            Card expectedCard = liveAtm.RetrieveAccount(accountNumber, pin);
            // Assert
            Assert.True(expectedCard.AccountNumber == accountNumber);
        }
    }
}
