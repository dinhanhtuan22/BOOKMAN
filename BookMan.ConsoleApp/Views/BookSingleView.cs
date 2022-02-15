using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    using Framework;
    /// <summary>
    /// class để hiện thị một cuốn sách
    /// </summary>
    internal class BookSingleView : ViewBase<Book>
    {
        /// <summary>
        /// Đây là hàm tạo, sẽ được gọi đầu tiên khi tạo object
        /// </summary>
        /// <param name="model">Cuốn sách cụ thể sẽ được hiển thị</param>
        public BookSingleView(Book model):base(model)
        { }

        /// <summary>
        /// Thực hiện in thông tin ra màn hình console
        /// </summary>
        public override void Render()
        {
            if(Model == null)
            {
                ViewHelp.WriteLine("No book found. Sorry!", ConsoleColor.Red);
                return; //kết thúc phương thức Render
            }
            ViewHelp.WriteLine("Book detail information", ConsoleColor.Green);

            Console.WriteLine($"Authors:     {Model.Authors}");
            Console.WriteLine($"Title:       {Model.Title}");
            Console.WriteLine($"Publisher:   {Model.Publisher}");
            Console.WriteLine($"Year:        {Model.Year}");
            Console.WriteLine($"Edition:     {Model.Edition}");
            Console.WriteLine($"Isbn:        {Model.Isbn}");
            Console.WriteLine($"Tags:        {Model.Tags}");
            Console.WriteLine($"Description: {Model.Description}");
            Console.WriteLine($"Rating:      {Model.Rating}");
            Console.WriteLine($"Reading:     {Model.Reading}");
            Console.WriteLine($"File:        {Model.File}");
            Console.WriteLine($"File Name:   {Model.FileName}");
        }        
    }
}
