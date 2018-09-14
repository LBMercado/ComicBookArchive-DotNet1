using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Diagnostics;

namespace ComicArchive
{
    class DataAccess
    {
        //General class for accessing databases
        
        public DataAccess(string datPath)
        {
            datPath = root + datPath;
        }

        public string GetDatPath()
        {
            return datPath;
        }

        public void SetDatPath(string dataPath)
        {
            datPath = root + dataPath;
        }

        public bool PathIsValid()
        {
            try
            {
                XDocument.Load(datPath);
            }
            catch (FileNotFoundException exc)
            {
                Trace.WriteLine("Error: " + exc.Message + "\nFile load based on path: <" + datPath + "> failed.");
                return false;
            }
            return true;
        }

        public void CreateDatPath()
        {
            XDocument xdocument;
            Directory.CreateDirectory(root);
            if (!PathIsValid())
            {
                xdocument = new XDocument(new XElement("Accounts"));
                xdocument.Save(datPath);
            }
        }

        protected const string root = "Data/";
        protected string datPath;
    }

    class AccountAccess : DataAccess
    {
        //Specialized class for accessing account databases
        //May include: account access, modification, verification, and encryption properties

        public AccountAccess(string acctPath, string username, string password): base(acctPath)
        {
            datPath = root + acctPath;
            usern = username;
            passw = password;
        }
        
        public void SetAccount(string username, string password)
        {
            usern = username;
            passw = password;
        }

        public bool AccountExists()
        {
            //Check in database if account exists. 
            //Return true if it does; otherwise, return false
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(datPath);

                foreach(XElement account in xDocument.Descendants("Account"))
                {
                    //get first element
                    XElement userNameRead = account.Element("UserName");
                    if (userNameRead.Value == usern)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + datPath + ">" + " is invalid, cannot proceed with account verification.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + datPath + ">" + " is invalid, cannot proceed with account verification."
                    );
                throw exc;
            }
        }

        public void WriteAccount()
        {
            //Write account into database
            //If the username already exists, this will overwrite the existing password of that account
            if (PathIsValid())
            {
                XDocument xDocument = XDocument.Load(datPath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get first element
                    XElement userNameRead = account.Element("UserName");
                    if (userNameRead.Value == usern)
                    {
                        //Account is existing
                        account.Element("PassWord").Value = passw;
                        return;
                    }
                }
                //Account is unique
                XElement newAcct = new XElement(
                    "Account",
                        new XElement("UserName", usern),
                        new XElement("PassWord", passw));

                xDocument.Root.Add(newAcct);
                xDocument.Save(datPath);
            }
            else
            {
                Trace.WriteLine("Set Path = " + "<" + datPath + ">" + " is invalid, cannot proceed with account verification.");
                FileNotFoundException exc = new FileNotFoundException
                    (
                    "Set Path = " + "<" + datPath + ">" + " is invalid, cannot proceed with account verification."
                    );
                throw exc;
            }

        }

        private string usern, passw;
    }
}
