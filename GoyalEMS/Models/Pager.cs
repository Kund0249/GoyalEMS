using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoyalEMS.Models
{
    public class Pager
    {
        public Pager(int totalcount, int RowPerPage = 5, int CurrentPage = 1)
        {
            int count = 0;
            TotalCount = totalcount;
            int rem = totalcount % RowPerPage;
            TotalPage = totalcount / RowPerPage;
            if (rem > 0)
                TotalPage++;

            Pages = new List<Pages>();
            int RemainingPage = TotalPage - CurrentPage;
            for (int i = 1; i <= TotalPage; i++)
            {
                if (i < CurrentPage && RemainingPage >= 3)
                    continue;
                else if (i < CurrentPage && RemainingPage == 2)
                    continue;
                else if (i < (CurrentPage - 1) && RemainingPage == 1)
                    continue;
                else if (i < (CurrentPage - 2) && RemainingPage == 0)
                    continue;

                if (count == 3)
                    break;

                Pages.Add(new Models.Pages()
                {
                    PageNumber = i
                });
                count++;
            }

            this.CurrentPage = CurrentPage;
        }

        private int _CurrentPage { get; set; }
        public int CurrentPage
        {
            get { return _CurrentPage; }
            private set
            {
                _CurrentPage = value;

                if (_CurrentPage > 1)
                {
                    IsFirst = true;
                    IsPrevious = true;
                }
                else
                {
                    IsFirst = false;
                    IsPrevious = false;
                }


                if (_CurrentPage >= TotalPage)
                {
                    IsLast = false;
                    IsNext = false;
                }
                else
                {
                    IsLast = true;
                    IsNext = true;
                }
            }
        }
        public int TotalCount { get; }
        public int TotalPage { get; set; }
        public List<Pages> Pages { get; }

        public bool IsFirst { get; private set; }
        public bool IsLast { get; private set; }
        public bool IsPrevious { get; private set; }
        public bool IsNext { get; private set; }

    }

    public class Pages
    {
        public int PageNumber { get; set; }

    }
}