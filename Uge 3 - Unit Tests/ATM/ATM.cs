using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATM
    {
        public List<Card> Cards { get; set; } = new List<Card> {
            new Card(1111111,"Erik Borup", 100000, 2242),
            new Card(2222222, "Homer Simpson", 500,5555),
            new Card(3333333, "Johhny Brian", 10,  9999)
        };

        public Card RetrieveAccount(int accountNumber, short pin)
        {
                Card existingCard = Cards.Find(c => c.AccountNumber == accountNumber);
                if (existingCard != null)
                {
                    if(ValidatePin(existingCard, pin) == true) { return existingCard; }
                    else { throw new Exception("Invalid pin"); }
                }
                else {
                    throw new Exception("Invalid account number");
                }
        }
        private bool ValidatePin(Card existingCard, short pin)
        {
            if (existingCard.Pin != pin)
            {
                throw new Exception("Invalid pin");
            }
            return true;
        }
    }
}
