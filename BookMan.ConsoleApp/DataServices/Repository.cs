using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    /// <summary>
    /// Lớp hỗ trợ quản lý dữ liệu
    /// 1. Quản lý sách/giá sách
    /// 2. Thực hiện truy xuất đến nguồn cơ sở dữ liệu (file)
    /// </summary>
    public class Repository
    {
        protected readonly IDataAccess _context;
        public Repository(IDataAccess context)
        {
            _context = context;
            _context.Load();
        }
        /// <summary>
        /// Lưu thông tin vào file
        /// </summary>
        public void SaveChanges() => _context.SaveChanges();
        public List<Book> Books => _context.Books;
        /// <summary>
        /// Chọn tất cả các cuốn sách
        /// </summary>
        /// <returns></returns>
        public Book[] Select() => _context.Books.ToArray();
        /// <summary>
        /// Chọn 1 cuốn sách theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book Select(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }
        /// <summary>
        /// Chọn các sách có các thông tin chứa từ khóa (Key)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Book[] Select(string key)
        {
            var k = key.ToLower();
            return _context.Books.Where(b =>
                    b.Title.ToLower().Contains(k) ||
                    b.Authors.ToLower().Contains(k) ||
                    b.Publisher.ToLower().Contains(k) ||
                    b.Tags.ToLower().Contains(k) ||
                    b.Description.ToLower().Contains(k)).ToArray();
        }
        /// <summary>
        /// Thêm một cuốn sách
        /// </summary>
        /// <param name="book"></param>
        public void Insert(Book book)
        {
            var id = _context.Books.Count == 0 ? 1 : _context.Books.Max(b => b.Id) + 1;
            book.Id = id;
            _context.Books.Add(book);
        }
        /// <summary>
        /// Xóa một cuốn sách
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var b = Select(id);
            if (b == null) return false;
            _context.Books.Remove(b);
            return true;
        }
        /// <summary>
        /// Cập nhật thông tin sách
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Update(int id, Book book)
        {
            var b = Select(id);
            if (b == null) return false;
            b.Authors = book.Authors;
            b.Description = book.Description;
            b.Title = book.Title;
            b.Publisher = book.Publisher;
            b.Isbn = book.Isbn;
            b.Rating = book.Rating;
            b.Reading = book.Reading;
            b.File = book.File;
            b.Year = book.Year;
            b.Edition = book.Edition;
            b.Tags = book.Tags;
            return true;
        }
        /// <summary>
        /// Chọn các sách đang đọc
        /// </summary>
        /// <returns></returns>
        public Book[] SelectMarked()
        {
            return _context.Books.Where(b => b.Reading == true).ToArray();
        }
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        public void Clear()
        {
            _context.Books.Clear();
        }

        /// <summary>
        /// Nhóm dữ liệu sách theo tên thư mục chứa file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string,Book>> Stats(string key = "folder")
        {
            return _context.Books.GroupBy(b => System.IO.Path.GetDirectoryName(b.File));
        }
    }

}
