using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Woto_novoe.Navigation
{
    internal class PageParticulars
    {
        public string Title { get; set; }
        public Page Page { get; set; }

        public PageParticulars(string title, Page page)
        {
            Title = title;
            Page = page;
        }
    }
}
