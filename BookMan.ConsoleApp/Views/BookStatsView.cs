
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Framework;
    using Models;
    /// <summary>
    /// In danh sách theo nhóm
    /// </summary>
    internal class BookStatsView : ViewBase<IEnumerable<IGrouping<string, Book>>>
    {
        public BookStatsView(IEnumerable<IGrouping<string, Book>> model) : base(model)
        {
            
        }
        /// <summary>
        /// In danh sách theo nhóm ra màn hình
        /// </summary>
        public override void Render()
        {
            foreach (var groupBook in Model)
            {
                ViewHelp.WriteLine($"# {groupBook.Key}", ConsoleColor.Magenta);
                foreach (var book in groupBook)
                {
                    ViewHelp.Write($"[{book.Id}]", ConsoleColor.Yellow);
                    ViewHelp.WriteLine(book.Title, book.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
                }

            }
        }
    }
}
