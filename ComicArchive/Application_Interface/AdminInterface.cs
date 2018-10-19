using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicArchive.Business_Logic;
using ComicArchive.Data_Access;

namespace ComicArchive.Application_Interface
{
    public class AdminInterface
    {
        //constants
        private const string accountFileName = @"accounts.xml";
        private const string cbRecordsFileName = @"cbInfo.xml";
        private const string cbResourceDirectory = @"Resources/comicbooks";
        private const string tempDirectory = @"temp";
        //data members
        private ExtendedAccountAccess accountManager;
        private ComicAccess comicManager;
        private Admin loggedInAdmin;

        /// <summary>
        /// implements the Admin logic of the application
        /// </summary>
        /// <param name="loggedInAdmin">
        /// the admin who has currently logged in to the application
        /// </param>
        /// <param name="tempDirectory">
        /// directory for temporary application cache
        /// </param>
        public AdminInterface(Admin loggedInAdmin, string tempDirectory = tempDirectory)
        {
            this.loggedInAdmin = loggedInAdmin;
            accountManager = new ExtendedAccountAccess(accountFileName);
            comicManager = new ComicAccess(cbRecordsFileName, tempDirectory);
        }

        /// <summary>
        /// change the password of the logged in admin
        /// </summary>
        /// <param name="newPassword"></param>
        public void ChangeLoggedAdminPassword(string newPassword)
        {
            accountManager.WriteAdminAccount(loggedInAdmin.Username, newPassword);
        }

        /// <summary>
        /// change the username of the logged in admin
        /// </summary>
        /// <param name="newUsername"></param>
        /// <returns></returns>
        public bool ChangeLoggedAdminUsername(string newUsername)
        {
            if (accountManager.AccountExists(newUsername))
            {
                return false;
            }
            else
            {
                accountManager.UpdateAccount(loggedInAdmin.Id, newUsername, loggedInAdmin.Password);
                return true;
            }
        }

        public User[] GetListOfUsers()
        {
            return accountManager.ReadAllUserAccounts();
        }

        public Admin[] GetListOfAdmins()
        {
            return accountManager.ReadAllAdminAccounts();
        }

        /// <summary>
        /// creates a new User in the application
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// true if successful, false if username is already used
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

        /// <summary>
        /// modifies the existing user (username and password only)
        /// </summary>
        /// <param name="modifiedUser"></param>
        /// <returns>
        /// true if successful, false if username is already used or id is invalid
        /// </returns>
        public bool ModifyUser(User modifiedUser)
        {
            return accountManager.UpdateAccount(
                modifiedUser.Id, 
                modifiedUser.Username,
                modifiedUser.Password);
        }

        /// <summary>
        /// deletes the existing user
        /// </summary>
        /// <param name="userToDelete"></param>
        /// <returns>
        /// true if successful, false if userToDelete is invalid
        /// </returns>
        public bool DeleteUser(User userToDelete)
        {
            return accountManager.RemoveAccount(userToDelete.Id);
        }

        public ComicBook[] GetListOfAvailableComics()
        {
            return comicManager.GetComicBookList().ToArray();
        }

        /// <summary>
        /// edits the existing comic book
        /// </summary>
        /// <param name="modifiedComicBook"></param>
        /// <returns>
        /// true if successful, false if invalid comic book supplied
        /// </returns>
        public bool EditComicBook(ComicBook modifiedComicBook)
        {
            return comicManager.UpdateComicBookRecord(modifiedComicBook);
        }

        /// <summary>
        /// deletes the existing comic book
        /// </summary>
        /// <param name="comicBookToDelete"></param>
        /// <returns></returns>
        public bool DeleteComicBook(ComicBook comicBookToDelete)
        {
            return comicManager.RemoveComicBookRecord(comicBookToDelete.GetArchivePath());
        }

        /// <summary>
        /// imports a new comic book based on the path to the cbz/cbr comic archive to the application
        /// </summary>
        /// <param name="archivePath">
        /// path with complete filename to the cbz/cbr comic archive
        /// </param>
        /// <returns>
        /// true if successful, false if invalid archivePath
        /// </returns>
        public bool ImportComicBook(string archivePath)
        {
            if (File.Exists(archivePath) &&
                ComicArchiveChecker.IsComicArchiveExtension(Path.GetExtension(archivePath)))
            {
                //create comic book resource directory if it hasn't been yet
                string resourceDirectory = Path.Combine(Directory.GetCurrentDirectory(), cbResourceDirectory);
                Directory.CreateDirectory(resourceDirectory);

                //copy archive to comic book resource directory
                string copyCbPath = Path.Combine(resourceDirectory, Path.GetFileName(archivePath));
                if (!File.Exists(copyCbPath))
                    File.Copy(archivePath, copyCbPath);
                comicManager.InitializeNewComicBook(archivePath);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
