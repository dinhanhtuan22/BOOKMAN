using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    using Framework;
    internal class BookListView : ViewBase<Book[]>
    {
        public BookListView(Book[] model) : base(model)
        { }


        /// <summary>
        /// In danh sách ra console
        /// </summary>
        public override void Render()
        {
            if (Model.Length == 0)
            {
                ViewHelp.WriteLine("No list book", ConsoleColor.Yellow);
                return;
            }

            ViewHelp.WriteLine("LIST BOOK INFORMATION", ConsoleColor.Green);
            foreach (Book b in Model)                           
            {
                ViewHelp.Write($"[{b.Id}]", ConsoleColor.Yellow);
                ViewHelp.WriteLine($"{b.Title}", b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);                
            }
            ViewHelp.WriteLine($"{Model.Length} item(s)", ConsoleColor.Green);
        }


    }
}
