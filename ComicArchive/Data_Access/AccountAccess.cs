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

namespace ComicArchive.Data_Access
{
    class AccountAccess : DataAccess
    {
        //Specialized class for accessing XML accounts
        //May include: account access, modification, verification, and encryption properties

        //data members
        private string username, password;
        private int identifier;

        /// <summary>
        /// Provides a means of setting and accessing an XML accounts file.
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
            }
            else
            {
                Trace.WriteLine("Directory with name = " + "<" + root + ">" + " does not exist, trying to create directory.");
                try
                {
                    CreateDataDirectory();
                    //create super admin
                    CreateSuperAdmin();
                    Count = 0;
                }
                catch (FileNotFoundException exc)
                {
                    Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account verification.");
                    throw exc;
                }
            }

            // id format:
            // first 4 digits = year
            // last 6 digits = account number
            username = "";
            password = "";
        }

        /// <summary>
        /// Provides a means of setting and accessing an XML accounts file.
        /// </summary>
        /// <param name="acctfilePath">
        /// Path of the XML accounts file.
        /// </param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public AccountAccess(string acctfilePath, string username, string password) : base(acctfilePath)
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
            }
            else
            {
                Trace.WriteLine("Directory with name = " + "<" + root + ">" + " does not exist, trying to create directory.");
                try
                {
                    CreateDataDirectory();
                    //create super admin
                    CreateSuperAdmin();
                    Count = 0;
                }
                catch (FileNotFoundException exc)
                {
                    Trace.WriteLine("Set Path = " + "<" + filePath + ">" + " is invalid, cannot proceed with account verification.");
                    throw exc;
                }
            }

            // id format:
            // first 4 digits = year
            // last 6 digits = account number
            this.username = username;
            this.password = username;
        }

        /// <summary>
        /// Set the account credentials.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void SetAccount(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Verify if the account is already existing in the XML accounts file.
        /// </summary>
        /// <returns>
        /// true if it exists, otherwise, it returns false.
        /// </returns>
        /// <exception cref="FileNotFoundException"></exception>
        public bool AccountExists()
        {
            //check if path specified exists, throw an error if it is not valid
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get first element
                    XElement userNameRead = account.Element("Username");
                    if (userNameRead.Value == username)
                    {
                        return true;
                    }
                }
                return false;
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
        /// Verify if the account username and password matches an existing account in the XML accounts file.
        /// </summary>
        /// <returns>
        /// true if the set username and password have an exact match, otherwise, false
        /// </returns>
        public bool IsValidAccount()
        {
            //check if path specified exists, throw an error if it is not valid
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement userNameRead = account.Element("Username");
                    XElement passWordRead = account.Element("Password");
                    if (userNameRead.Value == username &&
                        passWordRead.Value == password)
                    {
                        return true;
                    }
                }
                return false;
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
        /// Gets the actual account of the set account
        /// </summary>
        /// <returns>
        /// the actual admin if successful, null otherwise
        /// </returns>
        public User GetUserAccount()
        {
            //check if path specified exists, throw an error if it is not valid
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement idRead = account.Element("ID");
                    XElement userNameRead = account.Element("Username");
                    XElement passWordRead = account.Element("Password");

                    //check if id does not have 1000 as its first 4 digits
                    //the 1000 indicates an admin, any other will be a user
                    if (userNameRead.Value == username &&
                        passWordRead.Value == password &&
                        idRead.Value.Substring(0, 4) != "1000")
                    {
                        User user = new User(Convert.ToInt32(idRead.Value));
                        {
                            user.Username = userNameRead.Value;
                            user.Password = passWordRead.Value;
                        }
                        return user;
                    }
                }
                return null;
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
        /// Gets the actual account of the set account
        /// </summary>
        /// <returns>
        /// the actual admin if successful, null otherwise
        /// </returns>
        public Admin GetAdminAccount()
        {
            //check if path specified exists, throw an error if it is not valid
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement idRead = account.Element("ID");
                    XElement userNameRead = account.Element("Username");
                    XElement passWordRead = account.Element("Password");

                    //check if id has 1000 as its first 4 digits
                    //the 1000 indicates an admin, any other will be a user
                    if (userNameRead.Value == username &&
                        passWordRead.Value == password &&
                        idRead.Value.Substring(0, 4) == "1000")
                    {
                        Admin admin = new Admin(Convert.ToInt32(idRead.Value));
                        {
                            admin.Username = userNameRead.Value;
                            admin.Password = passWordRead.Value;
                        }
                        return admin;
                    }
                }
                return null;
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
        /// Writes or overwrites the set user account to the XML accounts file.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void WriteUserAccount()
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
        /// Writes or overwrites the set admin account to the XML accounts file.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void WriteAdminAccount()
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
        /// This creates the super admin within the accounts file.
        /// </summary>
        private void CreateSuperAdmin()
        {
            string oldUsername = username;
            string oldPassword = password;
            
            username = "admin_super";
            password = "letmein";
            WriteAdminAccount();

            username = oldUsername;
            password = oldPassword;
        }

        /// <summary>
        /// Get total number of accounts in the XML file
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Get number of admin accounts in the XML file
        /// </summary>
        public int AdminCount { get; private set; }
        /// <summary>
        /// Get number of user accounts in the XML file
        /// </summary>
        public int UserCount { get; private set; }
    }
}
