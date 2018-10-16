using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicArchive.Business_Logic
{
    class Admin : User
    {
        public Admin(int id) : base(id)
        {
            isAdmin = true;
        }
    }
}
