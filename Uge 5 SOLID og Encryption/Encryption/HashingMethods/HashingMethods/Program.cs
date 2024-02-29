using System.Threading.Channels;

namespace HashingMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region PBKDF2 process-flow explanation
            /*
            Console.WriteLine("Instead of using a database, I'm using a custom user-object, which will store the required values,");
            Console.WriteLine("as i progress through my explanation.");
            Console.WriteLine("Simulating user creation process...");
            Console.WriteLine("I will now take you through the PBKDF2 process. Consider the below user/password pair:");
            Console.WriteLine("Username: admin");
            Console.WriteLine("Password: admin");
            Console.WriteLine("During this process, we instantiate a User object, which constructor takes in a username and password.");
            User user = new User("admin", "admin");
            Console.WriteLine("The user object is created, and the password is hashed using the PBKDF2 algorithm.");
            
            Console.WriteLine("First we generated a random salt...");
            Console.WriteLine("Salt: " + user.Salt);

            Console.WriteLine("Then we hashed the cleartext password using SHA512");
            Console.WriteLine("Hash: " + user.InitialPasswordHash);

            Console.WriteLine("Then we hashed the password using the salt, in a PBKDF2 algorithm. With 10.000 iterations(loops).");
            Console.WriteLine("Our final hash: " + user.PasswordHash);

            Console.WriteLine("Then, to test that the hash matches every time, we can try and verify a recalculation using the generated hash");
            Console.WriteLine("The verification process is done by hashing the cleartext password, and then hashing it using the salt, and then comparing the hashes.");
            Console.WriteLine("Is the user allowed to connect with the password \"admin\"?: " + user.VerifyPassword("admin").ToString());
            Console.WriteLine("Then we try to recalculate with a different password.");
            Console.WriteLine("Is the user allowed to connect with the password: \"BadPassword1234@\": " + user.VerifyPassword("").ToString());

            */
            #endregion




            #region SHA512 & HMACSHA512 hashing
            /*
            

            
            Console.WriteLine("Hashing functions!");
            int key = 32;
            string input = "Hello World!";
            int cipherAlhabetLength = 62;
            string keyString = "123";
            HashingMethods.PrintSHA512Hash(input);
            Console.WriteLine("This string is irreversible, and possible to recompute, if given enough time, for example in a bruteforce scenario.");
            Console.WriteLine("Entropy details:");
            Console.WriteLine("Character length of secret message: 12");
            Console.WriteLine("The cipher alphabet you would need is A-Z both capitalized as well as uncapitalized, including alphanumeric symbols.");
            Console.WriteLine("Numbers of characters in the the a-z alphabet: 26");
            Console.WriteLine("Say we include the 10 most common alphanumeric characters: !@#%&/-_?=");
            Console.WriteLine($"The total number of characters in the cipher alphabet used in this explanation is {cipherAlhabetLength.ToString()}:(26 * 2 + 10 = 62)");
            Console.WriteLine("The amount of tries it could potentially take to crack this password, is: " + (Math.Pow(cipherAlhabetLength, 12).ToString()));
            // The enthropy is calculated by the formula: log2(number of characters in the cipher alphabet) * number of characters in the secret message
            Console.WriteLine("The entropy of the password is: " + HashingMethods.CalculatePasswordEntropy(input, cipherAlhabetLength));

            Console.WriteLine("===========================================================================");
            Console.WriteLine();
            Console.WriteLine("HMACSHA512 hash of the text: " + input);
            Console.WriteLine(HashingMethods.PrintHMACSHA512Hash(input, keyString));
            Console.WriteLine("This string is irreversible, and possible to recompute, if given enough time, for example in a bruteforce scenario.");
            Console.WriteLine("The key difference here, is that you will need a key as well, to recompute it. Otherwise, you will have to bruteforce the key as well");
            Console.WriteLine("Take into the account, the above explanation, and now add a key to it. To simplify, say the key length is 1.");
            Console.WriteLine("The amount of tries it could potentially take to crack this password, is: " + (Math.Pow(cipherAlhabetLength, 12) * Math.Pow(cipherAlhabetLength, 1)).ToString());
            Console.WriteLine("The entropy of the password is: " + HashingMethods.CalculatePasswordEntropy(input, cipherAlhabetLength) + HashingMethods.CalculatePasswordEntropy(keyString, cipherAlhabetLength));
            Console.WriteLine("Now lets say the key can contain integers, and has a total of 3 in length, this would be 3^10.");
            double keysize = Math.Pow(10, 3);
            Console.WriteLine("The entropy of the password is: " + Math.Pow(HashingMethods.CalculatePasswordEntropy(input, cipherAlhabetLength), keysize));
            Console.WriteLine("Quite insane a difference, right?");
            */
            #endregion

        }
    }
}
