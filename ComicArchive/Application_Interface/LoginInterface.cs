using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicArchive.Business_Logic;
using ComicArchive.Data_Access;

namespace ComicArchive.Application_Interface
{
    public class LoginInterface
    {
        //constants
        private const string accountFileName = "accounts.xml";

        //data members
        private AccountAccess accountManager;

        /// <summary>
        /// implements the login logic of the application
        /// </summary>
        public LoginInterface()
        {
            accountManager = new AccountAccess(accountFileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>
        /// true if username exists in database, false otherwise
        /// </returns>
        public bool IsValidUsername(string username)
        {
            return accountManager.AccountExists(username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// true if valid user login details, false otherwise
        /// </returns>
        public bool IsValidUserLogin(string username, string password)
        {
            if (accountManager.IsValidAccount(username, password))
            {
                if (accountManager.GetUserAccount(username, password) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// true if valid admin login details, false otherwise
        /// </returns>
        public bool IsValidAdminLogin(string username, string password)
        {
            if (accountManager.IsValidAccount(username, password))
            {
                if (accountManager.GetAdminAccount(username, password) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// true if successful, false if username already exists
        /// </returns>
        public bool CreateUser(string username, string password)
        {
            if (accountManager.AccountExists(username))
            {
                return false;
            }
            else
            {
                accountManager.WriteUserAccount(username, password);
                return true;
            }
        }
    }
}
