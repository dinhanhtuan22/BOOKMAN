
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Framework;
    using Models;
    internal class BookStatsView : ViewBase<IEnumerable<IGrouping<string, Book>>>
    {
        public BookStatsView(IEnumerable<IGrouping<string, Book>> model) : base(model)
        {
        }
        public override void Render()
        {
            foreach (var groupBook in Model)
            {
                ViewHelp.WriteLine($"# {groupBook.Key}", ConsoleColor.Magenta);
                foreach (var b in groupBook)
                {
                    ViewHelp.Write($"[{b.Id}]", ConsoleColor.Yellow);
                    ViewHelp.WriteLine(b.Title, b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
                }

            }
        }
    }
}
