using System;
using System.Collections.Generic;


namespace Project2
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Result> Results { get; set; } = new List<Result>();
        
    }
}
