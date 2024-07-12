using System;
using System.Collections.Generic;
using System.Linq;
using Project2;
using QuizApplication.Models;

namespace Project2
{
    // Handles user registration, login, and password change
    public class UserService
    {
        private List<User> users = new List<User>();

        public bool IsUsernameTaken(string username)
        {
            return users.Any(u => u.Username == username);
        }

        public User Register(string username, string password)
        {
            if (IsUsernameTaken(username))
            {
                throw new Exception("Username already exists. Please choose a different username.");
            }

            var user = new User { Username = username, Password = password };
            users.Add(user);
            return user;
        }

        public User Login(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public void ChangePassword(User user, string newPassword)
        {
            user.Password = newPassword;
        }
    }
}
