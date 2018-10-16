using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Business_Logic
{
    class User
    {
        protected bool isAdmin;

        public User(int id)
        {
            Id = id;
            isAdmin = false;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; }

        public bool IsAdmin { get; }
    }
}
