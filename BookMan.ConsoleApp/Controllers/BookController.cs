using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Controllers
{
    using DataServices;
    using Framework;
    using Models;
    using Views;
    /// <summary>
    /// class điều khiển, giúp ghép nối dữ liệu với giao diện
    /// </summary>
    internal class BookController : ControllerBase
    {
        protected Repository Repository;
        public BookController(IDataAccess context)
        {
            Repository = new Repository(context);
        }
        /// <summary>
        /// Ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuốn sách
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách</param>
        public void Single(int id, string path = "")
        {
            //lấy dữ liệu qua Repository
            var model = Repository.Select(id);
            /*Code chưa sử dụng lớp ControllerBase
            //Khởi tạo view
            BookSingleView view = new BookSingleView(model);
            //Gọi phương thức Render để thực sự hiện thị ra màn hình
            if(!string.IsNullOrEmpty(path))
            {
                view.RenderToFile(path);
                return;
            }
            view.Render();
            */
            Render(new BookSingleView(model), path);
        }

        /// <summary>
        /// Kích hoạt chức năng nhập dữ liệu cho 1 cuốn sách
        /// </summary>
        public void Create(Book book = null)
        {
            //BookCreateView create = new BookCreateView();
            //create.Render();
            if (book == null)
            {
                Render(new BookCreateView());
                return;
            }
            Repository.Insert(book);
            Success("Book created!");
        }
        /// <summary>
        /// Chức năng cập nhật dữ liệu cho 1 cuốn sách
        /// </summary>
        /// /// <param name="id">mã định danh của cuốn sách</param>
        public void Update(int id, Book book = null)
        {
            //// lấy dữ liệu qua repository
            //var model = Repository.Select(id);
            ////var view = new BookUpdateView(model);
            ////view.Render();
            //Render(new BookUpdateView(model));

            if (book == null)
            {
                var model = Repository.Select(id);
                var view = new BookUpdateView(model);
                Render(view);
                return;
            }
            Repository.Update(id, book);
            Success("Book updated");
        }
        public void List(string path = "")
        {
            //lấy dữ liệu qua repository
            var model = Repository.Select();
            ////Khởi tạo view
            //BookListView view = new BookListView(model);
            //if(!string.IsNullOrEmpty(path))
            //{
            //    view.RenderToFile(path);
            //    return;
            //}
            //view.Render();
            Render(new BookListView(model), path);
        }

        public void Delete(int id, bool process = false)
        {
            if (process == false)
            {
                var b = Repository.Select(id);
                Confirm($"Do you want to delete this book ({b.Title}) ?", $"do delete?id={b.Id}");
            }
            else
            {
                Repository.Delete(id);
                Success("Book deleted!");
            }
        }

        public void Filter(string key)
        {
            var model = Repository.Select(key);
            if (model.Length == 0)
                Inform("No matched book found!");
            else
                Render(new BookListView(model));
        }
        /// <summary>
        /// Đánh dấu sách đã đọc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="read"></param>
        public void Mark(int id, bool read =true)
        {
            var book = Repository.Select(id);
            if(book == null)
            {
                Error("Book not found!");
                return;
            }
            book.Reading = read;
            Success($"The book '{book.Title}' are marked as {(read ? "READ" : "UNREAD")}");
        }
        public void ShowMarks()
        {
            var model = Repository.SelectMarked();
            var view = new BookListView(model);
            Render(view);
        }
        public void Stats()
        {
            var model = Repository.Stats();
            var view = new BookStatsView(model);
            Render(view);
        }
    }
}
