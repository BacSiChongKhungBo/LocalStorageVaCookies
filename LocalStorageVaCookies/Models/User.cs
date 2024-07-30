﻿using System.ComponentModel.DataAnnotations;

namespace LocalStorageVaCookies.Models
{
    public class User
    {
        public User(int uId, string userName, string password)
        {
            UId = uId;
            UserName = userName;
            Password = password;
        }

        [Key]
        public int UId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
