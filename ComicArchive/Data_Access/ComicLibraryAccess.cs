using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ComicArchive.Business_Logic;
using System.Xml.Linq;
using System.IO;

namespace ComicArchive.Data_Access
{
    public class ComicLibraryAccess: AccountAccess
    {
        //data members
        private User[] userList;

        public ComicLibraryAccess(string acctFilePath) : base(acctFilePath)
        {
            userList = GetAllUserAccounts();
        }

        /// <summary>
        /// reads all the User accounts from the accounts XML file, including their comic libraries
        /// </summary>
        /// <returns>
        /// array of User objects
        /// </returns>
        public new User[] GetAllUserAccounts()
        {
            if (PathIsValid())
            {

                XDocument xDocument = XDocument.Load(filePath);
                userList = new User[UserCount];
                int index = 0;

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement id_element = account.Element("ID");
                    XElement username_element = account.Element("Username");
                    XElement password_element = account.Element("Password");
                    XElement libraryHead_element = account.Element("MyComicLibrary");

                    //check if id does not have 1000 as its first 4 digits
                    //the 1000 indicates an admin, any other will be a user
                    if (id_element.Value.Substring(0, 4) != "1000")
                    {
                        userList[index] = new User(Convert.ToInt32(id_element.Value));
                        {
                            userList[index].Username = username_element.Value;
                            userList[index].Password = password_element.Value;

                            ComicLibrary cbLib = new ComicLibrary();
                            //check foreach book imported in library
                            if (libraryHead_element != null &&
                                libraryHead_element.Descendants("MySavedComicBook") != null)
                            {
                                foreach (var savedCb_element in libraryHead_element.Descendants("MySavedComicBook"))
                                {
                                    //get all required elements for this saved comic book
                                    XElement archivePath_element = savedCb_element.Element("ArchivePath");
                                    XElement bookMark_element = savedCb_element.Element("Bookmark");
                                    XElement lastViewed_element = savedCb_element.Element("Last_Viewed");
                                    XElement rating_element = savedCb_element.Element("MyRating");

                                    //set all required data
                                    //set all required data : use ComicAccess to get ComicBook instance of archivePath
                                    ComicAccess ca = new ComicAccess();
                                    ComicBook public_cb = ca.GetComicBook(archivePath_element.Value);
                                    //obtained ComicBook is common to all, get the ComicBook for this user
                                    UserComicBook private_cb = UserComicBook.MorphToUserComicBook(public_cb);
                                    private_cb.LastViewed = DateTime.Parse(lastViewed_element.Value);
                                    private_cb.RateComicBook(float.Parse(rating_element.Value));

                                    //get all required elements : get bookmark for this saved comic book
                                    XElement bookMark_maxPages_element = bookMark_element.Element("MaxPages");
                                    XElement bookmark_pageNum_element = bookMark_element.Element("PageNum");
                                    Bookmark bm = new Bookmark(int.Parse(bookMark_maxPages_element.Value));
                                    //check if there are any bookmarked pages
                                    if (bookmark_pageNum_element.Value != "")
                                    {
                                        foreach (var pageNum in bookmark_pageNum_element.Value.Split(','))
                                        {
                                            bm.AddPageNum(int.Parse(pageNum));
                                        }
                                    }
                                    //set bookmark to user's saved comic book
                                    private_cb.BookMark = bm;

                                    //add user's saved comic book to user's comic library
                                    cbLib.AddComicBook(private_cb);
                                }
                                userList[index].MyComicLibrary = cbLib;
                            }
                            index++;
                        }
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
        /// returns the comic library associated with the provided id
        /// </summary>
        /// <param name="id">
        /// unique identifier for the User
        /// </param>
        /// <returns>
        /// ComicLibrary if User with id exists, null otherwise
        /// </returns>
        public ComicLibrary GetComicLibrary(int id)
        {
            if (GetUserAccount(id) != null)
            {
                return userList.Where(user => user.Id == id).Single().MyComicLibrary;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// writes/overwrites the ComicLibrary associated with the provided id and new comicLib
        /// </summary>
        /// <param name="id">
        /// unique identifier for the User
        /// </param>
        /// <param name="comicLib">
        /// The user's own comicLibrary
        /// </param>
        /// <returns>
        /// true if user Id exists, false otherwise
        /// </returns>
        public bool WriteComicLibrary(int id, ComicLibrary comicLib)
        {
            if (GetUserAccount(id) != null)
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement id_element = account.Element("ID");
                    XElement libraryHead_element = account.Element("MyComicLibrary");

                    //check if id does not have 1000 as its first 4 digits
                    //the 1000 indicates an admin, any other will be a user
                    if (id_element.Value.Substring(0, 4) != "1000")
                    {
                        if (libraryHead_element != null)
                            libraryHead_element.Remove();

                        //define a new library head for this user
                        libraryHead_element = new XElement("MyComicLibrary");

                        //set each imported book in library
                        foreach (var lib in comicLib.GetAllComicBooks())
                        {
                            XElement MySavedComicBook_element = new XElement("MySavedComicBook");

                            XElement archivePath_element = new XElement("ArchivePath", lib.GetArchivePath());
                            XElement bookMark_element = new XElement("Bookmark");
                            XElement lastViewed_element = new XElement("Last_Viewed", lib.LastViewed.ToShortDateString());
                            XElement rating_element = new XElement("MyRating", lib.Rating);

                            XElement bookMark_maxPages_element = new XElement("MaxPages", lib.BookMark.MaxPage);
                            XElement bookmark_pageNum_element = new XElement("PageNum", string.Join(",", lib.BookMark.GetPageNums()));
                            bookMark_element.Add(bookMark_maxPages_element, bookmark_pageNum_element);

                            MySavedComicBook_element.Add(archivePath_element, bookMark_element, lastViewed_element, rating_element);
                            libraryHead_element.Add(MySavedComicBook_element);
                        }

                        //attach the element to this user
                        account.Add(libraryHead_element);

                        //reload records to reflect changes made
                        userList = GetAllUserAccounts();

                        xDocument.Save(filePath);

                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// resets the ComicLibrary associated with the provided id
        /// </summary>
        /// <param name="id">
        /// unique identifier for the User
        /// </param>
        /// <returns>
        /// true if user Id exists, false otherwise
        /// </returns>
        public bool DeleteComicLibrary(int id)
        {
            if (GetUserAccount(id) != null)
            {
                XDocument xDocument = XDocument.Load(filePath);

                foreach (XElement account in xDocument.Descendants("Account"))
                {
                    //get required elements
                    XElement id_element = account.Element("ID");
                    XElement libraryHead_element = account.Element("MyComicLibrary");

                    //check if id does not have 1000 as its first 4 digits
                    //the 1000 indicates an admin, any other will be a user
                    if (id_element.Value.Substring(0, 4) != "1000")
                    {
                        //delete the library head associated with this user
                        libraryHead_element = new XElement("MyComicLibrary");

                        if (libraryHead_element != null)
                            libraryHead_element.Remove();
                        //reload records to reflect changes made

                        userList = GetAllUserAccounts();

                        xDocument.Save(filePath);

                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
