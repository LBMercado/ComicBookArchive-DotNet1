using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Business_Logic
{
    public class User
    {
        public User(int id)
        {
            Id = id;
            IsAdmin = false;
            MyComicLibrary = new ComicLibrary();
        }

        //properties
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; }
        public bool IsAdmin { get; protected set; }
        public ComicLibrary MyComicLibrary { get; set; }
    }
}