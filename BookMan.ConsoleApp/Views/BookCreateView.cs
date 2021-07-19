using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Framework;
    /// <summary>
    /// class thêm một cuốn sách mới
    /// </summary>
    internal class BookCreateView : ViewBase
    {
        public BookCreateView()
        {

        }

        /// <summary>
        /// Yêu cầu người dùng nhập từng thông tin và lưu lại thông tin đó
        /// </summary>
        public override void Render()
        {
            ViewHelp.WriteLine("CREATE A NEW BOOK", ConsoleColor.Green);

            var title = ViewHelp.InputString("Title");
            var authors = ViewHelp.InputString("Authors");
            var publisher = ViewHelp.InputString("Publisher");
            var year = ViewHelp.InputInt("Year");
            var edition = ViewHelp.InputInt("Edition");
            var tags = ViewHelp.InputString("Tags");
            var description = ViewHelp.InputString("Description");
            var rate = ViewHelp.InputInt("Rate");
            var reading = ViewHelp.InputBool("Reading");
            var file = ViewHelp.InputString("File");

            var request = "do create ? " +
                $"title = {title}" +
                $" & authors = {authors}" +
                $" & publiser = {publisher}" +
                $" & year = {year}" +
                $" & edition = {edition}" +
                $" & tags = {tags}" +
                $" & description = {description}" +
                $" & rate = {rate}" +
                $" & reading = {reading}" +
                $" & file = {file}";
            Router.Forward(request);

            Console.WriteLine();
        }
    }
}
