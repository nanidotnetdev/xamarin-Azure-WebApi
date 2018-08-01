using SQLite;
using System;

namespace POC2_UI.Models
{
    public class User
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MobileNumber { get; set; }
    }
}