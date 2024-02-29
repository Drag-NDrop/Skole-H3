using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashingMethods
{
    internal class User
    {
        string _username;
        string _initialPasswordHash;
        string _salt; // This is the salt in Base64 encoded format
        string _passwordHash; // This is the hashed password in Base64
        readonly int _iterations = 10000;
        HashingMethods hashingMethods = new HashingMethods();
        
        public User(string username, string password)
        {
            this._username = username;
            this._salt = hashingMethods.CreateSalt(32);
            this._initialPasswordHash = hashingMethods.CreateSHA512Hash(password);
            this._passwordHash = hashingMethods.Create2898PBKDF2Hash(this._initialPasswordHash, this._salt, _iterations);
            //this._passwordHash = Create2898PBKDF2Hash(password, this.salt);
        }

        public string Username
        {
            get
            {
                return _username;
            }

            private set
            {
                _username = value;
            }
        }

        public string InitialPasswordHash
        {
            get
            {
                return this._initialPasswordHash;
            }

            private set
            {
                this._initialPasswordHash = value;
            }
        }

        public string Salt
        {
            get
            {
                return _salt;
            }

            private set
            {
                _salt = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return _passwordHash;
            }

            private set
            {
                _passwordHash = value;
            }
        }

        public int Iterations {
            get
            {
                return _iterations;
            }
                     
        } 
        public bool VerifyPassword(string password)
        {
            string hashedPassword = hashingMethods.Create2898PBKDF2Hash(hashingMethods.CreateSHA512Hash(password), this._salt, _iterations);
            return hashedPassword == this.PasswordHash;
        }
    }
}
