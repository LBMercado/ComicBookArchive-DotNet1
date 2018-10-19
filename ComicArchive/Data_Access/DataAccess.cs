using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Diagnostics;

namespace ComicArchive.Data_Access
{
    public class DataAccess
    {
        //General class for setting XML files

        //data members
        protected const string root = "Data";
        protected string fileName;
        protected string filePath;

        /// <summary>
        /// Provides a means of setting XML files.
        /// </summary>
        /// <param name="fileName">
        /// The path to the XML file.
        /// </param>
        public DataAccess(string fileName)
        {
            this.fileName = fileName;
            filePath = Path.Combine(root, fileName);
        }

        /// <summary>
        /// returns the name of the XML file.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetFileName()
        {
            return fileName;
        }

        /// <summary>
        /// Set the path to the XML file.
        /// </summary>
        /// <param name="fileName">
        /// The path to the XML file.
        /// </param>
        public void SetFileName(string fileName)
        {
            this.fileName = fileName;
            filePath = Path.Combine(root, fileName);
        }

        /// <summary>
        /// Checks if the specified XML file exists.
        /// </summary>
        /// <returns>
        /// true if it exists, otherwise, it returns false.
        /// </returns>
        /// <exception cref="FileNotFoundException">
        public bool PathIsValid()
        {
            try
            {
                XDocument.Load(filePath);
            }
            catch (FileNotFoundException exc)
            {
                Trace.WriteLine("Error: " + exc.Message + "\nFile load based on path: <" + filePath + "> failed.");
                return false;
            }
            catch(DirectoryNotFoundException exc)
            {
                Trace.WriteLine("Error: " + exc.Message + "\nDirectory not found: <" + root + "> failed.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Creates the Data directory if it doesn't exist yet,
        /// and initializes an XML file within it.
        /// </summary>
        public void CreateDataDirectory()
        {
            XDocument xdocument;
            Directory.CreateDirectory(root);

            xdocument = new XDocument(new XElement("Records"));
            xdocument.Save(filePath);
        }

        /// <summary>
        /// Removes the XML record that is within the data directory
        /// </summary>
        /// <returns>
        /// true if successful, false otherwise
        /// </returns>
        public bool RemoveDataRecord()
        {
            try
            {
                File.Delete(filePath);
            }
            catch(DirectoryNotFoundException exc)
            {
                Trace.WriteLine("Directory specified by filePath: <" + filePath + "> is invalid.");
                return false;
            }
            catch(UnauthorizedAccessException exc)
            {
                Trace.WriteLine("File specified by filePath: <" + filePath + "> cannot be access.\n Permission denied.");
                return false;
            }
            return true;
        }
    }
}
