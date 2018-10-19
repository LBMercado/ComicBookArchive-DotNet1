using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ComicArchive.Business_Logic
{
    public class Bookmark
    {
        /// <summary>
        /// a representation of a comic book bookmark
        /// </summary>
        /// <param name="maxPage">
        /// maximum number of pages for the comic book
        /// </param>
        public Bookmark(int maxPage)
        {
            pageNum = new List<int>();
            MaxPage = maxPage;
        }

        public void AddPageNum(int pageNum)
        {
            if (!this.pageNum.Contains(pageNum) &&
                pageNum <= MaxPage && 
                pageNum > 0)
            {
                this.pageNum.Add(pageNum);
                this.pageNum.Sort();
            }
        }

        public void DelPageNum(int pageNum)
        {
            if (this.pageNum.Contains(pageNum))
            {
                this.pageNum.Remove(pageNum);
                this.pageNum.Sort();
            }
        }

        public int[] GetPageNums()
        {
            return pageNum.ToArray();
        }

        //data members
        private List<int> pageNum;

        //properties
        public int MaxPage { get; private set; }
    }
}
