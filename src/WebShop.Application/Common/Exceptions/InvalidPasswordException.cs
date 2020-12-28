using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Input;
using WebShop.Domain.Entities;

namespace WebShop.Application.Common.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public InvalidPasswordException(string username,string password)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordException(string message, string username, string password) : base(message)
        {
            Username = username;
            Password = password;
        }

        public InvalidPasswordException(string message, string username, string password, Exception innerException) : base(message, innerException)
        {
            Username = username;
            Password = password;
        }
    }
}
