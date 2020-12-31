﻿using System;

namespace WebShop.Domain.Exceptions
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