using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Diagnostics;
using System.IO;
using ComicArchive.Business_Logic;
using ComicArchive.Exceptions;

namespace ComicArchive.Data_Access
{
    public class AccountAccess : DataAccess
    {
        //Specialized class for accessing XML accounts
        //May include: account access, modification, verification, and encryption properties

        //data members
        protected User[] userList;
        protected Admin[] adminList;
        private int identifier;
        // identifier:
        // first 4 digits = year
        // last 6 digits = account number

        /// <summary>
        /// Provides a means of setting and accessing an XML accounts file.
        /// Only writes/reads/modifies the username, password, and id members for the User/Admin
        /// </summary>
        /// <param name="acctfilePath">
        /// Path of the XML accounts file.
        /// </param>
        /// <exception cref="FileNotFoundException"></exception>
        public AccountAccess(string acctfilePath) : base(acctfilePath)
        {
            identifier = DateTime.Now.Year;
            //count number of accounts in XML file
            if (PathIsValid())
            {
                XDocument xdocument = XDocument.Load(filePath);

                //count number of user accounts (excluding admins)
                Func<XElement, bool> isUserId = delegate (XElement id) { return int.Parse(id.Value) / (int)Math.Pow(10, 6) != 1000; };
                UserCount = xdocument.XPathSelectElements("//ID").Count(isUserId);

                //count number of admin accounts
                Func<XElement, bool> isAdminId = delegate (XElement id) { return int.Parse(id.Value) / (int)Math.Pow(10, 6) == 1000; };
                AdminCount = xdocument.XPathSelectElements("//ID").Count(isAdminId);

                //count total number of accounts
                Count = UserCount + AdminCount;

                //fill the user and admin lists
                userList = ReadAllUserAccounts();
                adminList = ReadAllAdminAccounts();
            }
            else
            {
                Trace.WriteLine("Directory with name = " + "<" + root + ">" + " does not exist, trying to create directory.");
                try
                {
                    Count = UserCount = AdminCount = 0;
                    CreateDataDirectory();
                    //create super admin
                    CreateSuperAdmin();

                    //fill the admin list
                    adminList = ReadAllAdminAccounts();
                }
                catch (FileNotFoundException exc)
                {
                    Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account verification.");
                    throw exc;
                }
            }
        }

        /// <summary>
        /// creates the data directory if it doesn't exist yet
        /// and initializes an accounts xml file within it
        /// </summary>
        public new void CreateDataDirectory()
        {
            if (!PathIsValid())
            {
                XDocument xdocument;
                Directory.CreateDirectory(root);

                xdocument = new XDocument(new XElement("Accounts"));
                xdocument.Save(filePath);
            }
        }

        /// <summary>
        /// Verify if the account is already existing in the XML accounts file
        /// based on the given username
        /// </summary>
        /// <returns>
        /// true if it exists, otherwise, it returns false.
        /// </returns>
        public bool AccountExists(string username)
        {
            return userList.Any(user => user.Username == username) ||
                adminList.Any(admin => admin.Username == username);
        }

        /// <summary>
        /// Verify if the account is already existing in the XML accounts file
        /// based on the given id
        /// </summary>
        /// <returns>
        /// true if it exists, otherwise, it returns false.
        /// </returns>
        public bool AccountExists(int id)
        {
            //check in userList if id exists
            return userList.Any(user => user.Id == id) ||
                adminList.Any(admin => admin.Id == id);
        }

        /// <summary>
        /// Verify if the account username and password matches an existing account in the XML accounts file
        /// based on the given username and password
        /// </summary>
        /// <returns>
        /// true if the set username and password have an exact match, otherwise, false
        /// </returns>
        public bool IsValidAccount(string username, string password)
        {
            //check in user list first if username exists
            if (userList.Any(user => user.Username == username))
            {
                var account = userList.Where(user => user.Username == username).Single();

                //check if password of user is a match
                if (account.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //must be an admin, check in admin list
            else
            {
                if (adminList.Any(admin => admin.Username == username))
                {
                    var adminAccount = adminList.Where(admin => admin.Username == username).Single();
                    //else check if the password matches then decide from there
                    if (adminAccount.Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                //if still null, then it does not exist, it is an invalid account
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Verify if the account username and password matches an Admin account in the XML accounts file
        /// based on the given username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// true if the given username and password have an exact Admin account match, otherwise, false
        /// </returns>
        public bool IsAdminAccount(string username, string password)
        {
            //check if in admin list
            if (adminList.Any(admin => admin.Username == username))
            {
                var adminAccount = adminList.Where(admin => admin.Username == username).Single();
                //else check if the password matches then decide from there
                if (adminAccount.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //if still null, then it does not exist, it is an invalid account
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the User instance in the XML accounts file
        /// based on the given username and password
        /// </summary>
        /// <returns>
        /// User object if matching User username and password found, null otherwise
        /// </returns>
        public User GetUserAccount(string username, string password)
        {
            if (IsValidAccount(username, password))
            {
                return userList.Where(user => user.Username == username).SingleOrDefault();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the User instance in the XML accounts file
        /// based on the given id
        /// </summary>
        /// <returns>
        /// User object if matching User ID found, null otherwise
        /// </returns>
        /// <exception cref="FileNotFoundException"></exception>
        public User GetUserAccount(int id)
        {
            return userList.Where(user => user.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// Gets the Admin instance in the XML accounts file
        /// based on the given username and password
        /// </summary>
        /// <returns>
        /// Admin object if matching Admin ID found, null otherwise
        /// </returns>
        public Admin GetAdminAccount(string username, string password)
        {
            if (IsValidAccount(username, password))
            {
                return adminList.Where(admin => admin.Username == username).SingleOrDefault();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the Admin instance in the XML accounts file
        /// based on the given id
        /// </summary>
        /// <returns>
        /// Admin object if matching Admin ID found, null otherwise
        /// </returns>
        public Admin GetAdminAccount(int id)
        {
            return adminList.Where(admin => admin.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// Writes a User account to the XML accounts file
        /// based on the given username and password.
        /// Updates the password if username already exists.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void WriteUserAccount(string username, string password)
        {
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get first element
                    XElement userNameRead = account.Element("Username");
                    if (userNameRead.Value == username)
                    {
                        //Account is existing
                        account.Element("Password").Value = password;
                        xDocument.Save(filePath);
                        return;
                    }
                }

                //Account is unique

                int userId = identifier * (int)Math.Pow(10, 6) + UserCount;

                XElement newAcct = new XElement(
                    "Account",
                        new XElement("ID", userId.ToString()),
                        new XElement("Username", username),
                        new XElement("Password", password)
                        );

                xDocument.Root.Add(newAcct);
                xDocument.Save(filePath);
                UserCount++;
                Count++;

                //reload user list to reflect changes
                userList = ReadAllUserAccounts();
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account verification.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account verification."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// Writes an Admin account to the XML accounts file
        /// based on the given username and password
        /// Updates the password if username already exists.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void WriteAdminAccount(string username, string password)
        {
            //If the username already exists, this will overwrite the existing password of that account
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get first element
                    XElement userNameRead = account.Element("Username");
                    if (userNameRead.Value == username)
                    {
                        //Account is existing
                        account.Element("Password").Value = password;
                        xDocument.Save(filePath);
                        return;
                    }
                }

                //Account is unique

                int adminId = 1000 * (int)Math.Pow(10,6) + AdminCount;

                XElement newAcct = new XElement(
                    "Account",
                        new XElement("ID", adminId),
                        new XElement("Username", username),
                        new XElement("Password", password)
                        );

                xDocument.Root.Add(newAcct);
                xDocument.Save(filePath);
                AdminCount++;
                Count++;

                //reload admin list to reflect changes
                adminList = ReadAllAdminAccounts();
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account verification.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account verification."
                    );
                throw exc;
            }

        }

        /// <summary>
        /// Removes the User/Admin account in the XML accounts file
        /// based on the given username and password
        /// </summary>
        /// <returns>
        /// true if successful, false if invalid combination of username and password
        /// </returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        public bool RemoveAccount(string username, string password)
        {
            if (PathIsValid())
            {
                //delete only if valid credentials
                if (IsValidAccount(username, password))
                {
                    XDocument xDocument = XDocument.Load(filePath);

                    foreach (XElement account in xDocument.Descendants("Account"))
                    {
                        //get required elements
                        XElement userNameRead = account.Element("Username");
                        XElement idRead = account.Element("ID");

                        if (userNameRead.Value == username)
                        {
                            //remove top node <Account> that has this username
                            account.Remove();
                            xDocument.Save(filePath);

                            //check if admin or user, decrement accordingly
                            //check if id does not have 1000 as its first 4 digits
                            //the 1000 indicates an admin, any other will be a user
                            if (idRead.Value.Substring(0, 4) == "1000")
                            {
                                AdminCount--;
                                //reload user list to reflect changes
                                userList = ReadAllUserAccounts();
                            }
                            else
                            {
                                UserCount--;
                                //reload admin list to reflect changes
                                adminList = ReadAllAdminAccounts();
                            }
                            Count--;
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    Trace.WriteLine("User/Admin with username: <" + username + "> and password: <" + password +">, does not exist in the XML file.");
                    UserDoesNotExistException exc = new UserDoesNotExistException
                        (
                        "User/Admin with username: <" + username + "> and password: <" + password + ">, does not exist in the XML file."
                        );
                    throw exc;
                }
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid. Cannot proceed with account removal.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " is invalid or set account does not exist.\nCannot proceed with account removal."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// Removes the User/Admin account in the XML accounts file
        /// based on the given id
        /// </summary>
        /// <returns>
        ///  true if successful, false if invalid id
        /// </returns>
        /// <param name="id"></param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        public bool RemoveAccount(int id)
        {
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement idRead = account.Element("ID");

                    if (idRead.Value == id.ToString())
                    {
                        //remove top node <Account> that has this username
                        account.Remove();
                        xDocument.Save(filePath);

                        //check if admin or user, decrement accordingly
                        //check if id does not have 1000 as its first 4 digits
                        //the 1000 indicates an admin, any other will be a user
                        if (idRead.Value.Substring(0, 4) == "1000")
                        {
                            AdminCount--;
                            //reload user list to reflect changes
                            account.Remove();
                            xDocument.Save(filePath);
                            userList = ReadAllUserAccounts();
                        }
                        else
                        {
                            UserCount--;
                            //reload admin list to reflect changes
                            account.Remove();
                            xDocument.Save(filePath);
                            adminList = ReadAllAdminAccounts();
                        }
                        Count--;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid. Cannot proceed with account removal.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " is invalid or set account does not exist.\nCannot proceed with account removal."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// Updates the User/Admin account in the XML accounts file
        /// based on the given id
        /// </summary>
        /// <param name="id">
        /// id of the User/Admin to update
        /// </param>
        /// <returns>
        /// true if successful, false otherwise
        /// </returns>
        public bool UpdateAccount(int id, string newUsername, string newPassword)
        {
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement userNameRead = account.Element("Username");
                    XElement passWordRead = account.Element("Password");
                    XElement idRead = account.Element("ID");

                    //update account username and password with same userId
                    if (idRead.Value == id.ToString())
                    {
                        //must not replace super admin username
                        if (userNameRead.Value != "admin_super")
                            userNameRead.Value = newUsername;
                        passWordRead.Value = newPassword;
                        xDocument.Save(filePath);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid. Cannot proceed with account removal.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " is invalid or set account does not exist.\nCannot proceed with account removal."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// This creates the super admin within the accounts file.
        /// </summary>
        private void CreateSuperAdmin()
        {   
            string super_username = "admin_super";
            string super_password = "letmein";
            WriteAdminAccount(super_username, super_password);
        }

        /// <summary>
        /// reads all the User accounts from the accounts XML file
        /// </summary>
        /// <returns>
        /// array of User objects
        /// </returns>
        /// <exception cref="FileNotFoundException"></exception>
        public User[] ReadAllUserAccounts()
        {
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);
                User[] userList = new User[UserCount];
                int index = 0;

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement idRead = account.Element("ID");
                    XElement userNameRead = account.Element("Username");
                    XElement passWordRead = account.Element("Password");

                    //check if id does not have 1000 as its first 4 digits
                    //the 1000 indicates an admin, any other will be a user
                    if (idRead.Value.Substring(0, 4) != "1000")
                    {
                        userList[index] = new User(Convert.ToInt32(idRead.Value));
                        {
                            userList[index].Username = userNameRead.Value;
                            userList[index].Password = passWordRead.Value;
                        }
                        index++;
                    }
                }
                return userList;
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account access.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account access."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// reads all the Admin accounts from the accounts XML file
        /// </summary>
        /// <returns>
        /// array of Admin objects
        /// </returns>
        public Admin[] ReadAllAdminAccounts()
        {
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);
                Admin[] adminList = new Admin[AdminCount];
                int index = 0;

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement idRead = account.Element("ID");
                    XElement userNameRead = account.Element("Username");
                    XElement passWordRead = account.Element("Password");

                    //check if id has 1000 as its first 4 digits
                    //the 1000 indicates an admin, any other will be a user
                    if (idRead.Value.Substring(0, 4) == "1000")
                    {
                        adminList[index] = new Admin(Convert.ToInt32(idRead.Value));
                        {
                            adminList[index].Username = userNameRead.Value;
                            adminList[index].Password = passWordRead.Value;
                        }
                        index++;
                    }
                }
                return adminList;
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account access.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account access."
                    );
                throw exc;
            }
        }

        /// <summary>
        /// total number of accounts in the XML file
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// number of admin accounts in the XML file
        /// </summary>
        public int AdminCount { get; private set; }
        /// <summary>
        /// number of user accounts in the XML file
        /// </summary>
        public int UserCount { get; private set; }
    }
}
