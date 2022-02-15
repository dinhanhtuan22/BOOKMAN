using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Controllers
{
    using DataServices;
    using Framework;
    using Views;
    using Models;
    using System.IO;
    using System.Diagnostics;
    /// <summary>
    /// Class điều khiển thực hiện các chức năng liên quan đến file (mặc định pdf), thư mục
    /// </summary>
    internal class ShellController : ControllerBase
    {
        protected Repository Repository;
        public ShellController(IDataAccess context)
        {
            Repository = new Repository(context);
        }
        /// <summary>
        /// Lấy thông tin file theo phần mở rộng trong folder
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="ext">phần mở rộng, mặc định là pdf</param>
        public void Shell(string folder, string ext = "*.pdf")
        {
            if(!Directory.Exists(folder))
            {
                Error("Folder not found!");
                return;
            }
            var files = Directory.GetFiles(folder, ext ?? "*.pdf", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                Repository.Insert(new Book { Title = Path.GetFileNameWithoutExtension(f), File = f });
            }
            if(files.Length>0)
            {
                Success($"{files.Length} item(s) found!");
                return;
            }
            Inform("No item found!", "SORRY!");
        }
        /// <summary>
        /// Mở file bằng chương trình mặc định của máy client
        /// </summary>
        /// <param name="id"></param>
        public void Read(int id)
        {
            var book = Repository.Select(id);
            if(book ==null)
            {
                Error("Book not found1");
                return;
            }
            if(!File.Exists(book.File))
            {
                Error("File not found!");
                return;
            }
            Process.Start(book.File);
            Success($"You are reading the book '{book.Title}'");
        }
        /// <summary>
        /// Xóa toàn bộ dữ liệu
        /// </summary>
        /// <param name="process">True/False</param>
        public void Clear(bool process = false)
        {
            if(!process)
            {
                Confirm("Do you want to clear the shell?", "DO CLEAR");
                return;
            }
            Repository.Clear();
            Inform("The shell has been cleared!");
        }
        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        public void Save()
        {
            Repository.SaveChanges();
            Success("Data save!");
        }
    }
}
